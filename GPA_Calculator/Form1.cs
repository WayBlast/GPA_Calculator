namespace GPA_Calculator
{
    public partial class Form1 : Form
    {
        Dictionary<string, (decimal ects, string grade)> courseMap = new Dictionary<string, (decimal ects, string grade)>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value >= 0 && courseNameBox.Text != "")
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
        }

        private void clearAllBtn_Click(object sender, EventArgs e)
        {
            Dictionary<string, (decimal ects, string grade)> courseMap = new Dictionary<string, (decimal ects, string grade)>();

            List<string> courses = new List<string>();
            List<string> course_points = new List<string>();
            List<string> course_grades = new List<string>();

            coursesLbx.DataSource = null;
            coursesLbx.DataSource = courses;

            pointsLbx.DataSource = null;
            pointsLbx.DataSource = course_points;

            gradeLbx.DataSource = null;
            gradeLbx.DataSource = course_grades;

        }

        private void updateGPA()
        {   
            if (courseMap.Keys == null)
            {
                gpaResultLbl.Text = ":)";
                
            } else
            {
                int n = 0;
                foreach (var pair in courseMap)
                {

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
