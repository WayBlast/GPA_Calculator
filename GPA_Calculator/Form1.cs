using Microsoft.Data.Sqlite;
using System.Linq;

namespace GPA_Calculator
{
    public partial class Form1 : Form
    {
        Dictionary<string, (decimal ects, string grade)> courseMap = new Dictionary<string, (decimal ects, string grade)>();
        SqliteConnection connection;
        (string, string, string, string, string, string, string) grades = ("(-3)", "(00)", "(02)", "(4)", "(7)", "(10)", "(12)");

        public Form1()
        {
            InitializeComponent();
            gradeSelector.SelectedIndex = 4;
            sortAscDescBox.SelectedIndex = 0;
            sortVariableBox.SelectedIndex = 0;

            targetGPAUpDown.Visible = false;
            planBtn.Visible = false;
            targetLbl.Visible = false;
            maxBtn.Visible = false;
            minBtn.Visible = false;
            clearPlansBtn.Visible = false;
            button1.Visible = false;    


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
            (decimal, decimal) newResults = calculateGpa(courseMap);
            decimal new_gpa = newResults.Item1;
            decimal total_ects = newResults.Item2;

            gpaResultLbl.Text = $"GPA = {Math.Round(new_gpa, 2)}";
            totalECTSLbl.Text = $"Total ECTS = {total_ects}";

        }

        private (decimal, decimal) calculateGpa(Dictionary<string, (decimal ects, string grade)> courses)
        {
            if (courseMap.Count == 0)
            {
                gpaResultLbl.Text = "GPA = :)";

            }
            else
            {
                decimal sum_of_top = 0;
                decimal sum_of_bottom = 0;
                decimal sum_of_ects = 0;

                foreach (var pair in courses)
                {
                    sum_of_ects = sum_of_ects + pair.Value.ects;
                    if (pair.Value.grade != " ")
                    {

                        sum_of_top = sum_of_top + (pair.Value.ects * decimal.Parse(pair.Value.grade.Trim('(', ')')));
                        sum_of_bottom = sum_of_bottom + pair.Value.ects;
                    }
                }

                if (sum_of_bottom != 0)
                {
                    decimal new_gpa = sum_of_top / sum_of_bottom;
                    return (new_gpa, sum_of_ects);

                }
            }
            return (0, 0);
        }

        private void coursesLbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pointsLbx.SelectedIndex != null && gradeLbx.SelectedIndex != null)
            {
                pointsLbx.SelectedIndex = coursesLbx.SelectedIndex;
                gradeLbx.SelectedIndex = coursesLbx.SelectedIndex;
            }

        }

        private void pointsLbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (coursesLbx.SelectedIndex != null && gradeLbx.SelectedIndex != null)
            {
                coursesLbx.SelectedIndex = pointsLbx.SelectedIndex;
                gradeLbx.SelectedIndex = pointsLbx.SelectedIndex;

            }
        }

        private void gradeLbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pointsLbx.SelectedIndex != null && coursesLbx.SelectedIndex != null)
            {
                pointsLbx.SelectedIndex = gradeLbx.SelectedIndex;
                coursesLbx.SelectedIndex = gradeLbx.SelectedIndex;
            }

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

                        foreach (var pair in courseMap.Where(p => p.Value.grade != " " &&
                                                                !(p.Value.grade.StartsWith("(")))
                                                       .OrderByDescending(p => decimal.Parse(p.Value.grade)))
                        {
                            course_names.Add(pair.Key);
                            course_points.Add($"{pair.Value.ects}");
                            course_grades.Add($"{pair.Value.grade}");
                        }
                        foreach (var pair in courseMap.Where(p => (p.Value.grade.StartsWith("(")))
                                                       .OrderByDescending(p => decimal.Parse(p.Value.grade.Trim('(', ')'))))
                        {
                            course_names.Add(pair.Key);
                            course_points.Add($"{pair.Value.ects}");
                            course_grades.Add($"{pair.Value.grade}");
                        }
                        foreach (var pair in courseMap.Where(p => p.Value.grade == " "))
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

                        foreach (var pair in courseMap.Where(p => p.Value.grade != " " &&
                                                                !(p.Value.grade.StartsWith("(")))
                                                       .OrderBy(p => decimal.Parse(p.Value.grade)))
                        {
                            course_names.Add(pair.Key);
                            course_points.Add($"{pair.Value.ects}");
                            course_grades.Add($"{pair.Value.grade}");
                        }
                        foreach (var pair in courseMap.Where(p => (p.Value.grade.StartsWith("(")))
                                                       .OrderBy(p => decimal.Parse(p.Value.grade.Trim('(', ')'))))
                        {
                            course_names.Add(pair.Key);
                            course_points.Add($"{pair.Value.ects}");
                            course_grades.Add($"{pair.Value.grade}");
                        }
                        foreach (var pair in courseMap.Where(p => p.Value.grade == " "))
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

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlBox.Text = "Edit";

            targetGPAUpDown.Visible = false;
            planBtn.Visible = false;
            targetLbl.Visible = false;
            maxBtn.Visible = false;
            minBtn.Visible = false;
            clearPlansBtn.Visible = false;

            deleteCourseBtn.Visible = true;
            clearAllBtn.Visible = true;
            sortBtn.Visible = true;
            sortAscDescBox.Visible = true;
            sortVariableBox.Visible = true;
            addCourseBtn.Enabled = true;
            courseNameBox.Enabled = true;
            numericUpDown1.Enabled = true;
            gradeSelector.Enabled = true;
            button1.Enabled = true;
            checkBox1.Enabled = true;


        }

        private void planToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlBox.Text = "Plan";

            deleteCourseBtn.Visible = false;
            clearAllBtn.Visible = false;
            sortBtn.Visible = false;
            sortAscDescBox.Visible = false;
            sortVariableBox.Visible = false;
            addCourseBtn.Enabled = false;
            courseNameBox.Enabled = false;
            numericUpDown1.Enabled = false;
            gradeSelector.Enabled = false;
            button1.Enabled = false;
            checkBox1.Enabled = false;


            targetGPAUpDown.Visible = true;
            planBtn.Visible = true;
            targetLbl.Visible = true;
            maxBtn.Visible = true;
            minBtn.Visible = true;
            clearPlansBtn.Visible = true;
        }

        private void planBtn_Click(object sender, EventArgs e)
        {
            planMinimumRoute();

        }

        private void planMinimumRoute()
        {
            var progression = new List<string> { " ", "(-3)", "(00)", "(02)", "(4)", "(7)", "(10)", "(12)" };
            Dictionary<string, (decimal ects, string grade)> courseCopy = new Dictionary<string, (decimal, string)>(courseMap);
            bool targetReached = false;
            bool targetUnreachable = false;

            while (!targetReached && !targetUnreachable)
            {
                // Check if all upgradeable courses are already at max
                if (courseCopy.Values.All(v => !v.grade.StartsWith("(") && v.grade != " " || v.grade == "(12)"))
                {
                    MessageBox.Show("Target GPA not reachable :(");
                    targetUnreachable = true;
                    break;
                }
                else if (decimal.Parse(gpaResultLbl.Text.Trim('G', 'P', 'A', ' ', '=')) >= targetGPAUpDown.Value)
                {
                    MessageBox.Show("Target GPA already reached ;)");
                    targetUnreachable = true;
                    break;
                }

                // Get all upgradeable courses, sorted by their current grade level (lowest first)
                // so we spread grades evenly rather than piling onto one course
                var upgradeables = courseCopy
                    .Where(p => p.Value.grade == " " && p.Value.ects != 0 || p.Value.grade.StartsWith("(") && p.Value.grade != "(12)")
                    .OrderBy(p => progression.IndexOf(p.Value.grade))
                    .ThenByDescending(p => p.Value.ects)
                    .ToList();

                foreach (var pair in upgradeables)
                {
                    int idx = progression.IndexOf(pair.Value.grade);
                    if (idx >= 0 && idx < progression.Count - 1)
                    {
                        courseCopy[pair.Key] = (pair.Value.ects, progression[idx + 1]);

                        if (calculateGpa(courseCopy).Item1 >= targetGPAUpDown.Value)
                        {
                            targetReached = true;
                            break;
                        }
                    }
                }
            }

            if (targetReached)
            {
                MessageBox.Show("Target GPA is reachable!");
                courseMap = new Dictionary<string, (decimal ects, string grade)>(courseCopy);

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

        private void maxBtn_Click(object sender, EventArgs e)
        {
            var progression = new List<string> { " ", "(-3)", "(00)", "(02)", "(4)", "(7)", "(10)", "(12)" };
            Dictionary<string, (decimal ects, string grade)> courseCopy = new Dictionary<string, (decimal, string)>(courseMap);

            var upgradeables = courseCopy
                    .Where(p => p.Value.grade == " " && p.Value.ects != 0 || p.Value.grade.StartsWith("(") && p.Value.grade != "(12)")
                    .OrderBy(p => progression.IndexOf(p.Value.grade))
                    .ThenByDescending(p => p.Value.ects)
                    .ToList();

            foreach (var pair in upgradeables)
            {
                courseCopy[pair.Key] = (pair.Value.ects, "(12)");

            }

            MessageBox.Show("Calculating max possible GPA");
            courseMap = new Dictionary<string, (decimal ects, string grade)>(courseCopy);

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

        private void minBtn_Click(object sender, EventArgs e)
        {
            var progression = new List<string> { " ", "(-3)", "(00)", "(02)", "(4)", "(7)", "(10)", "(12)" };
            Dictionary<string, (decimal ects, string grade)> courseCopy = new Dictionary<string, (decimal, string)>(courseMap);

            var previous = courseCopy
                    .Where(p => p.Value.grade.StartsWith("("))
                    .OrderBy(p => progression.IndexOf(p.Value.grade))
                    .ThenByDescending(p => p.Value.ects)
                    .ToList();

            foreach (var pair in previous)
            {
                courseCopy[pair.Key] = (pair.Value.ects, " ");

            }

            var upgradeables = courseCopy
                    .Where(p => p.Value.grade == " " && p.Value.ects != 0 || p.Value.grade.StartsWith("(") && p.Value.grade != "(12)")
                    .OrderBy(p => progression.IndexOf(p.Value.grade))
                    .ThenByDescending(p => p.Value.ects)
                    .ToList();

            foreach (var pair in upgradeables)
            {
                courseCopy[pair.Key] = (pair.Value.ects, "(02)");

            }

            MessageBox.Show("Calculating minimum possible (passing) GPA");
            courseMap = new Dictionary<string, (decimal ects, string grade)>(courseCopy);

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

        private void button1_Click_1(object sender, EventArgs e)
        {
            var progression = new List<string> { " ", "(-3)", "(00)", "(02)", "(4)", "(7)", "(10)", "(12)" };
            Dictionary<string, (decimal ects, string grade)> courseCopy = new Dictionary<string, (decimal, string)>(courseMap);

            var upgradeables = courseCopy
                    .Where(p => p.Value.grade.StartsWith("("))
                    .OrderBy(p => progression.IndexOf(p.Value.grade))
                    .ThenByDescending(p => p.Value.ects)
                    .ToList();

            foreach (var pair in upgradeables)
            {
                courseCopy[pair.Key] = (pair.Value.ects, " ");

            }

            MessageBox.Show("Clearing plans...");
            courseMap = new Dictionary<string, (decimal ects, string grade)>(courseCopy);

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

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                addCourseBtn.Visible = false;
                button1.Visible = true;
            }
            else
            {
                addCourseBtn.Visible = true;
                button1.Visible = false;
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (courseMap.Count != 0)
            {
               
                string name = courseNameBox.Text;
                decimal ects = numericUpDown1.Value;
                string grade = gradeSelector.Text;

                string oldname = coursesLbx.SelectedItem.ToString();
                decimal oldects = courseMap[oldname].ects;
                string oldgrade = courseMap[oldname].grade;

                courseMap.Remove(coursesLbx.SelectedItem.ToString());
                if (!courseMap.ContainsKey(name))
                {
                    
                    courseMap.Add(name, (ects, grade));

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
                } else
                {
                    MessageBox.Show("Course already exists!");
                    courseMap.Add(oldname, (oldects, oldgrade));
                }
                

            }
            else
            {
                MessageBox.Show("Nothing to modify...");
            }
        }
    }
}