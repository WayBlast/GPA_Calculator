namespace GPA_Calculator
{
    public partial class Form1 : Form
    {
        Dictionary<string, (decimal ects, string grade)> courseMap = new Dictionary<string, (decimal ects, string grade)>();

        public Form1()
        {
            InitializeComponent();
            gradeSelector.SelectedIndex = 4;

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

        private void clearAllBtn_Click(object sender, EventArgs e)
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

                if (sum_of_bottom != 0) {
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

        
    }
}
