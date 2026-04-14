namespace GPA_Calculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            courseNameBox = new TextBox();
            addCourseBtn = new Button();
            coursesLbx = new ListBox();
            numericUpDown1 = new NumericUpDown();
            gpaResultLbl = new Label();
            deleteCourseBtn = new Button();
            clearAllBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            label3 = new Label();
            gradeSelector = new ComboBox();
            pointsLbx = new ListBox();
            gradeLbx = new ListBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // courseNameBox
            // 
            courseNameBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            courseNameBox.Location = new Point(12, 56);
            courseNameBox.Name = "courseNameBox";
            courseNameBox.Size = new Size(170, 29);
            courseNameBox.TabIndex = 0;
            // 
            // addCourseBtn
            // 
            addCourseBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addCourseBtn.Location = new Point(298, 54);
            addCourseBtn.Name = "addCourseBtn";
            addCourseBtn.Size = new Size(48, 31);
            addCourseBtn.TabIndex = 2;
            addCourseBtn.Text = "Add";
            addCourseBtn.UseVisualStyleBackColor = true;
            addCourseBtn.Click += button1_Click;
            // 
            // coursesLbx
            // 
            coursesLbx.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            coursesLbx.FormattingEnabled = true;
            coursesLbx.ItemHeight = 21;
            coursesLbx.Location = new Point(12, 91);
            coursesLbx.Name = "coursesLbx";
            coursesLbx.Size = new Size(180, 277);
            coursesLbx.TabIndex = 3;
            coursesLbx.Click += coursesLbx_Click;
            coursesLbx.SelectedIndexChanged += coursesLbx_SelectedIndexChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numericUpDown1.Location = new Point(188, 56);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(49, 29);
            numericUpDown1.TabIndex = 4;
            // 
            // gpaResultLbl
            // 
            gpaResultLbl.AutoSize = true;
            gpaResultLbl.BorderStyle = BorderStyle.FixedSingle;
            gpaResultLbl.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gpaResultLbl.Location = new Point(224, 374);
            gpaResultLbl.Name = "gpaResultLbl";
            gpaResultLbl.Size = new Size(122, 52);
            gpaResultLbl.TabIndex = 5;
            gpaResultLbl.Text = "label1";
            gpaResultLbl.TextAlign = ContentAlignment.MiddleCenter;
            
            // 
            // deleteCourseBtn
            // 
            deleteCourseBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            deleteCourseBtn.Location = new Point(12, 374);
            deleteCourseBtn.Name = "deleteCourseBtn";
            deleteCourseBtn.Size = new Size(82, 29);
            deleteCourseBtn.TabIndex = 6;
            deleteCourseBtn.Text = "Remove";
            deleteCourseBtn.UseVisualStyleBackColor = true;
            deleteCourseBtn.Click += deleteCourseBtn_Click;
            // 
            // clearAllBtn
            // 
            clearAllBtn.BackColor = Color.Transparent;
            clearAllBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clearAllBtn.ForeColor = Color.Black;
            clearAllBtn.Location = new Point(100, 374);
            clearAllBtn.Name = "clearAllBtn";
            clearAllBtn.RightToLeft = RightToLeft.No;
            clearAllBtn.Size = new Size(82, 29);
            clearAllBtn.TabIndex = 7;
            clearAllBtn.Text = "Clear All";
            clearAllBtn.UseVisualStyleBackColor = false;
            clearAllBtn.Click += clearAllBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 38);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 8;
            label1.Text = "Course Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(188, 38);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 9;
            label2.Text = "ECTS";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(359, 24);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, loadToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(100, 22);
            saveToolStripMenuItem.Text = "Save";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(100, 22);
            loadToolStripMenuItem.Text = "Load";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 20);
            aboutToolStripMenuItem.Text = "About";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(243, 38);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 12;
            label3.Text = "Grade";
            // 
            // gradeSelector
            // 
            gradeSelector.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gradeSelector.FormattingEnabled = true;
            gradeSelector.Items.AddRange(new object[] { "-3", "00", "02", "4", "7", "10", "12" });
            gradeSelector.Location = new Point(243, 56);
            gradeSelector.Name = "gradeSelector";
            gradeSelector.Size = new Size(49, 29);
            gradeSelector.TabIndex = 13;
            // 
            // pointsLbx
            // 
            pointsLbx.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pointsLbx.FormattingEnabled = true;
            pointsLbx.ItemHeight = 21;
            pointsLbx.Location = new Point(188, 91);
            pointsLbx.Name = "pointsLbx";
            pointsLbx.Size = new Size(59, 277);
            pointsLbx.TabIndex = 14;
            pointsLbx.SelectedIndexChanged += pointsLbx_SelectedIndexChanged;
            // 
            // gradeLbx
            // 
            gradeLbx.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gradeLbx.FormattingEnabled = true;
            gradeLbx.ItemHeight = 21;
            gradeLbx.Location = new Point(243, 91);
            gradeLbx.Name = "gradeLbx";
            gradeLbx.Size = new Size(103, 277);
            gradeLbx.TabIndex = 15;
            gradeLbx.SelectedIndexChanged += gradeLbx_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 450);
            Controls.Add(gradeLbx);
            Controls.Add(pointsLbx);
            Controls.Add(gradeSelector);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(clearAllBtn);
            Controls.Add(deleteCourseBtn);
            Controls.Add(gpaResultLbl);
            Controls.Add(numericUpDown1);
            Controls.Add(coursesLbx);
            Controls.Add(addCourseBtn);
            Controls.Add(courseNameBox);
            Controls.Add(menuStrip1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox courseNameBox;
        private Button addCourseBtn;
        private ListBox coursesLbx;
        private NumericUpDown numericUpDown1;
        private Label gpaResultLbl;
        private Button deleteCourseBtn;
        private Button clearAllBtn;
        private Label label1;
        private Label label2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Label label3;
        private ComboBox gradeSelector;
        private ListBox pointsLbx;
        private ListBox gradeLbx;
    }
}
