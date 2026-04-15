using Microsoft.Data.Sqlite;
using System.Linq;

namespace GPA_Calculator
{
    public partial class Form1 : Form
    {
        Dictionary<string, (decimal ects, string grade)> courseMap = new Dictionary<string, (decimal ects, string grade)>();
        SqliteConnection connection;

        public Form1()
        {
            InitializeComponent();
            gradeSelector.SelectedIndex = 4;
            sortAscDescBox.SelectedIndex = 0;
            sortVariableBox.SelectedIndex = 0;

            string connectionString = "Data Source=courses.db;";
            connection = new SqliteConnection(connectionString);
            connection.Open();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value >= 0 && courseNameBox.Text != "")
            {
                if (courseMap.ContainsKey(courseNameBox.Text))
                {
                    MessageBox.Show("Course already exists!");
                }
                else
                {
                    courseMap.Add($"{courseNameBox.Text}", (numericUpDown1.Value, gradeSelector.Text));
                    // - {numericUpDown1.Value} ECTS - Grade: {gradeSelector.Text}
                    List<string> course_names = new List<string>();
                    List<string> course_points = new List<string>();
                    List<string> course_grades = new List<string>();

                    foreach (var pair in courseMap)
                    {
                        course_names.Add(pair.Key);
                        course_points.Add($"{pair.Value.ects}");
                        course_grades.Add($"{pair.Value.grade}");

                    }
                    coursesLbx.DataSource = null;
                    coursesLbx.DataSource = course_names;

                    pointsLbx.DataSource = null;
                    pointsLbx.DataSource = course_points;

                    gradeLbx.DataSource = null;
                    gradeLbx.DataSource = course_grades;

                    updateGPA();
                }
            }


        }

        private void coursesLbx_Click(object sender, EventArgs e)
        {

        }

        private void deleteCourseBtn_Click(object sender, EventArgs e)
        {
            if (courseMap.Count != 0)
            {

                courseMap.Remove(coursesLbx.SelectedItem.ToString());

                List<string> course_names = new List<string>();
                List<string> course_points = new List<string>();
                List<string> course_grades = new List<string>();

                foreach (var pair in courseMap)
                {
                    course_names.Add(pair.Key);
                    course_points.Add($"{pair.Value.ects}");
                    course_grades.Add(pair.Value.grade);

                }
                coursesLbx.DataSource = null;
                coursesLbx.DataSource = course_names;

                pointsLbx.DataSource = null;
                pointsLbx.DataSource = course_points;

                gradeLbx.DataSource = null;
                gradeLbx.DataSource = course_grades;

                updateGPA();

            }
            else
            {
                MessageBox.Show("Nothing to remove...");
            }

        }

        private void clearAllBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to clear all?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)

            {
                courseMap = new Dictionary<string, (decimal ects, string grade)>();

                List<string> courses = new List<string>();
                List<string> course_points = new List<string>();
                List<string> course_grades = new List<string>();

                coursesLbx.DataSource = null;
                coursesLbx.DataSource = courses;

                pointsLbx.DataSource = null;
                pointsLbx.DataSource = course_points;

                gradeLbx.DataSource = null;
                gradeLbx.DataSource = course_grades;

                updateGPA();
            }
        }

        private void updateGPA()
        {
            if (courseMap.Count == 0)
            {
                gpaResultLbl.Text = "GPA = :)";

            }
            else
            {
                decimal sum_of_top = 0;
                decimal sum_of_bottom = 0;

                foreach (var pair in courseMap)
                {
                    if (pair.Value.grade != "")
                    {
                        sum_of_top = sum_of_top + (pair.Value.ects * decimal.Parse(pair.Value.grade));
                        sum_of_bottom = sum_of_bottom + pair.Value.ects;
                    }
                }

                if (sum_of_bottom != 0)
                {
                    decimal new_gpa = sum_of_top / sum_of_bottom;

                    gpaResultLbl.Text = $"GPA = {Math.Round(new_gpa, 2)}";
                }
            }

        }

        private void coursesLbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            pointsLbx.SelectedIndex = coursesLbx.SelectedIndex;
            gradeLbx.SelectedIndex = coursesLbx.SelectedIndex;
        }

        private void pointsLbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            coursesLbx.SelectedIndex = pointsLbx.SelectedIndex;
            gradeLbx.SelectedIndex = pointsLbx.SelectedIndex;
        }

        private void gradeLbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            pointsLbx.SelectedIndex = gradeLbx.SelectedIndex;
            coursesLbx.SelectedIndex = gradeLbx.SelectedIndex;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Save?\n(This will override your current save)", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {

                if (courseMap.Count != 0)
                {
                    string createTable = "CREATE TABLE IF NOT EXISTS courses (name TEXT, ects REAL, grade TEXT)";
                    SqliteCommand createCmd = new SqliteCommand(createTable, connection);
                    createCmd.ExecuteNonQuery();

                    string deleteAll = "DELETE FROM courses";
                    SqliteCommand deleteCmd = new SqliteCommand(deleteAll, connection);
                    deleteCmd.ExecuteNonQuery();

                    foreach (var pair in courseMap)
                    {
                        string insert = "INSERT INTO courses (name, ects, grade) VALUES (@name, @ects, @grade)";
                        SqliteCommand cmd = new SqliteCommand(insert, connection);
                        cmd.Parameters.AddWithValue("@name", pair.Key);
                        cmd.Parameters.AddWithValue("@ects", pair.Value.ects);
                        cmd.Parameters.AddWithValue("@grade", pair.Value.grade);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Courses have been saved!");
                }
                else
                {
                    MessageBox.Show("No courses to save!");
                }
            }

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to load?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string createTable = "CREATE TABLE IF NOT EXISTS courses (name TEXT, ects REAL, grade TEXT)";
                SqliteCommand createCmd = new SqliteCommand(createTable, connection);
                createCmd.ExecuteNonQuery();

                string count = "SELECT COUNT(*) FROM courses";
                SqliteCommand checkCmd = new SqliteCommand(count, connection);
                long rowCount = (long)checkCmd.ExecuteScalar();
                if (rowCount > 0)
                {

                    courseMap = new Dictionary<string, (decimal ects, string grade)>();

                    string select = "SELECT * FROM courses";
                    SqliteCommand cmd = new SqliteCommand(select, connection);
                    SqliteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string name = reader["name"].ToString();
                        decimal ects = decimal.Parse(reader["ects"].ToString());
                        string grade = reader["grade"].ToString();
                        courseMap.Add(name, (ects, grade));
                    }

                    List<string> course_names = new List<string>();
                    List<string> course_points = new List<string>();
                    List<string> course_grades = new List<string>();

                    foreach (var pair in courseMap)
                    {
                        course_names.Add(pair.Key);
                        course_points.Add($"{pair.Value.ects}");
                        course_grades.Add($"{pair.Value.grade}");

                    }
                    coursesLbx.DataSource = null;
                    coursesLbx.DataSource = course_names;

                    pointsLbx.DataSource = null;
                    pointsLbx.DataSource = course_points;

                    gradeLbx.DataSource = null;
                    gradeLbx.DataSource = course_grades;

                    updateGPA();
                    MessageBox.Show("Data loaded!");
                }
                else
                {
                    MessageBox.Show("No data has been saved!");
                }


            }
        }

        private void clearSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to clear your save?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string createTable = "CREATE TABLE IF NOT EXISTS courses (name TEXT, ects REAL, grade TEXT)";
                SqliteCommand createCmd = new SqliteCommand(createTable, connection);
                createCmd.ExecuteNonQuery();

                string deleteAll = "DELETE FROM courses";
                SqliteCommand deleteCmd = new SqliteCommand(deleteAll, connection);
                deleteCmd.ExecuteNonQuery();

                MessageBox.Show("Save has been cleared!");
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dette er en udregner til en lovely nose :)))");
        }

        private void sortBtn_Click(object sender, EventArgs e)
        {
            switch (sortVariableBox.SelectedIndex)
            {
                // Sort by name
                case 0:
                    // Alphabetical Order
                    if (sortAscDescBox.SelectedIndex == 0)
                    {

                        List<string> course_names = new List<string>();
                        List<string> course_points = new List<string>();
                        List<string> course_grades = new List<string>();

                        foreach (var pair in courseMap.OrderBy(p => p.Key))
                        {
                            course_names.Add(pair.Key);
                            course_points.Add($"{pair.Value.ects}");
                            course_grades.Add($"{pair.Value.grade}");
                        }

                        coursesLbx.DataSource = null;
                        coursesLbx.DataSource = course_names;

                        pointsLbx.DataSource = null;
                        pointsLbx.DataSource = course_points;

                        gradeLbx.DataSource = null;
                        gradeLbx.DataSource = course_grades;

                        updateGPA();
                        break;

                    }
                    else
                    {
                        List<string> course_names = new List<string>();
                        List<string> course_points = new List<string>();
                        List<string> course_grades = new List<string>();

                        foreach (var pair in courseMap.OrderByDescending(p => p.Key))
                        {
                            course_names.Add(pair.Key);
                            course_points.Add($"{pair.Value.ects}");
                            course_grades.Add($"{pair.Value.grade}");
                        }

                        coursesLbx.DataSource = null;
                        coursesLbx.DataSource = course_names;

                        pointsLbx.DataSource = null;
                        pointsLbx.DataSource = course_points;

                        gradeLbx.DataSource = null;
                        gradeLbx.DataSource = course_grades;

                        updateGPA();
                        break;

                    }
                // Sort by ECTS
                case 1:
                    // asc
                    if (sortAscDescBox.SelectedIndex == 0)
                    {

                        List<string> course_names = new List<string>();
                        List<string> course_points = new List<string>();
                        List<string> course_grades = new List<string>();

                        foreach (var pair in courseMap.OrderByDescending(p => p.Value.ects))
                        {
                            course_names.Add(pair.Key);
                            course_points.Add($"{pair.Value.ects}");
                            course_grades.Add($"{pair.Value.grade}");
                        }

                        coursesLbx.DataSource = null;
                        coursesLbx.DataSource = course_names;

                        pointsLbx.DataSource = null;
                        pointsLbx.DataSource = course_points;

                        gradeLbx.DataSource = null;
                        gradeLbx.DataSource = course_grades;

                        updateGPA();
                        break;

                    }
                    // desc
                    else
                    {
                        List<string> course_names = new List<string>();
                        List<string> course_points = new List<string>();
                        List<string> course_grades = new List<string>();

                        foreach (var pair in courseMap.OrderBy(p => p.Value.ects))
                        {
                            course_names.Add(pair.Key);
                            course_points.Add($"{pair.Value.ects}");
                            course_grades.Add($"{pair.Value.grade}");
                        }

                        coursesLbx.DataSource = null;
                        coursesLbx.DataSource = course_names;

                        pointsLbx.DataSource = null;
                        pointsLbx.DataSource = course_points;

                        gradeLbx.DataSource = null;
                        gradeLbx.DataSource = course_grades;

                        updateGPA();
                        break;

                    }

                // sort by grade
                case 2:
                    // asc
                    if (sortAscDescBox.SelectedIndex == 0)
                    {

                        List<string> course_names = new List<string>();
                        List<string> course_points = new List<string>();
                        List<string> course_grades = new List<string>();

                        foreach (var pair in courseMap.OrderByDescending(p => decimal.Parse(p.Value.grade)))
                        {
                            course_names.Add(pair.Key);
                            course_points.Add($"{pair.Value.ects}");
                            course_grades.Add($"{pair.Value.grade}");
                        }

                        coursesLbx.DataSource = null;
                        coursesLbx.DataSource = course_names;

                        pointsLbx.DataSource = null;
                        pointsLbx.DataSource = course_points;

                        gradeLbx.DataSource = null;
                        gradeLbx.DataSource = course_grades;

                        updateGPA();
                        break;

                    }
                    // desc
                    else
                    {
                        List<string> course_names = new List<string>();
                        List<string> course_points = new List<string>();
                        List<string> course_grades = new List<string>();

                        foreach (var pair in courseMap.OrderBy(p => decimal.Parse(p.Value.grade)))
                        {
                            course_names.Add(pair.Key);
                            course_points.Add($"{pair.Value.ects}");
                            course_grades.Add($"{pair.Value.grade}");
                        }

                        coursesLbx.DataSource = null;
                        coursesLbx.DataSource = course_names;

                        pointsLbx.DataSource = null;
                        pointsLbx.DataSource = course_points;

                        gradeLbx.DataSource = null;
                        gradeLbx.DataSource = course_grades;

                        updateGPA();
                        break;




                    }
                default:
                    break;
            }

        }
    }
}