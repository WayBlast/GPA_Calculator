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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            clearSaveToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            modeToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            planToolStripMenuItem = new ToolStripMenuItem();
            label3 = new Label();
            gradeSelector = new ComboBox();
            pointsLbx = new ListBox();
            gradeLbx = new ListBox();
            label4 = new Label();
            sortBtn = new Button();
            sortAscDescBox = new ComboBox();
            sortVariableBox = new ComboBox();
            controlBox = new GroupBox();
            clearPlansBtn = new Button();
            minBtn = new Button();
            maxBtn = new Button();
            planBtn = new Button();
            targetLbl = new Label();
            targetGPAUpDown = new NumericUpDown();
            totalECTSLbl = new Label();
            checkBox1 = new CheckBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            menuStrip1.SuspendLayout();
            controlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)targetGPAUpDown).BeginInit();
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
            addCourseBtn.BackColor = SystemColors.Control;
            addCourseBtn.FlatStyle = FlatStyle.System;
            addCourseBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addCourseBtn.Location = new Point(298, 56);
            addCourseBtn.Name = "addCourseBtn";
            addCourseBtn.Size = new Size(49, 29);
            addCourseBtn.TabIndex = 2;
            addCourseBtn.Text = "Add";
            addCourseBtn.UseVisualStyleBackColor = false;
            addCourseBtn.Click += button1_Click;
            // 
            // coursesLbx
            // 
            coursesLbx.BackColor = Color.Honeydew;
            coursesLbx.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            coursesLbx.FormattingEnabled = true;
            coursesLbx.ItemHeight = 17;
            coursesLbx.Location = new Point(12, 91);
            coursesLbx.Name = "coursesLbx";
            coursesLbx.Size = new Size(180, 276);
            coursesLbx.TabIndex = 3;
            coursesLbx.Click += coursesLbx_Click;
            coursesLbx.SelectedIndexChanged += coursesLbx_SelectedIndexChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 1;
            numericUpDown1.Font = new Font("Segoe UI", 12F);
            numericUpDown1.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numericUpDown1.Location = new Point(188, 56);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(49, 29);
            numericUpDown1.TabIndex = 4;
            // 
            // gpaResultLbl
            // 
            gpaResultLbl.AutoSize = true;
            gpaResultLbl.BackColor = SystemColors.Control;
            gpaResultLbl.BorderStyle = BorderStyle.Fixed3D;
            gpaResultLbl.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            gpaResultLbl.Location = new Point(198, 391);
            gpaResultLbl.Name = "gpaResultLbl";
            gpaResultLbl.Size = new Size(108, 34);
            gpaResultLbl.TabIndex = 5;
            gpaResultLbl.Text = "GPA = :)";
            gpaResultLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // deleteCourseBtn
            // 
            deleteCourseBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            deleteCourseBtn.Location = new Point(6, 17);
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
            clearAllBtn.Location = new Point(93, 17);
            clearAllBtn.Name = "clearAllBtn";
            clearAllBtn.RightToLeft = RightToLeft.No;
            clearAllBtn.Size = new Size(80, 29);
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, aboutToolStripMenuItem, modeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(359, 24);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, loadToolStripMenuItem, clearSaveToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(128, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(128, 22);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // clearSaveToolStripMenuItem
            // 
            clearSaveToolStripMenuItem.Name = "clearSaveToolStripMenuItem";
            clearSaveToolStripMenuItem.Size = new Size(128, 22);
            clearSaveToolStripMenuItem.Text = "Clear Save";
            clearSaveToolStripMenuItem.Click += clearSaveToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 20);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // modeToolStripMenuItem
            // 
            modeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { editToolStripMenuItem, planToolStripMenuItem });
            modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            modeToolStripMenuItem.Size = new Size(50, 20);
            modeToolStripMenuItem.Text = "Mode";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(97, 22);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // planToolStripMenuItem
            // 
            planToolStripMenuItem.Name = "planToolStripMenuItem";
            planToolStripMenuItem.Size = new Size(97, 22);
            planToolStripMenuItem.Text = "Plan";
            planToolStripMenuItem.Click += planToolStripMenuItem_Click;
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
            gradeSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            gradeSelector.Font = new Font("Segoe UI", 12F);
            gradeSelector.FormattingEnabled = true;
            gradeSelector.Items.AddRange(new object[] { " ", "-3", "00", "02", "4", "7", "10", "12" });
            gradeSelector.Location = new Point(243, 56);
            gradeSelector.Name = "gradeSelector";
            gradeSelector.Size = new Size(49, 29);
            gradeSelector.TabIndex = 13;
            // 
            // pointsLbx
            // 
            pointsLbx.BackColor = Color.LightGoldenrodYellow;
            pointsLbx.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            pointsLbx.FormattingEnabled = true;
            pointsLbx.ItemHeight = 17;
            pointsLbx.Location = new Point(188, 91);
            pointsLbx.Name = "pointsLbx";
            pointsLbx.Size = new Size(59, 276);
            pointsLbx.TabIndex = 14;
            pointsLbx.SelectedIndexChanged += pointsLbx_SelectedIndexChanged;
            // 
            // gradeLbx
            // 
            gradeLbx.BackColor = Color.LavenderBlush;
            gradeLbx.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            gradeLbx.FormattingEnabled = true;
            gradeLbx.ItemHeight = 17;
            gradeLbx.Location = new Point(243, 91);
            gradeLbx.Name = "gradeLbx";
            gradeLbx.Size = new Size(103, 276);
            gradeLbx.TabIndex = 15;
            gradeLbx.SelectedIndexChanged += gradeLbx_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(312, 460);
            label4.Name = "label4";
            label4.Size = new Size(47, 15);
            label4.TabIndex = 16;
            label4.Text = "ver. 2.0.";
            // 
            // sortBtn
            // 
            sortBtn.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sortBtn.Location = new Point(7, 62);
            sortBtn.Name = "sortBtn";
            sortBtn.Size = new Size(77, 23);
            sortBtn.TabIndex = 17;
            sortBtn.Text = "Sort By: ";
            sortBtn.UseVisualStyleBackColor = true;
            sortBtn.Click += sortBtn_Click;
            // 
            // sortAscDescBox
            // 
            sortAscDescBox.DropDownStyle = ComboBoxStyle.DropDownList;
            sortAscDescBox.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sortAscDescBox.FormattingEnabled = true;
            sortAscDescBox.Items.AddRange(new object[] { "Desc.", "Asc." });
            sortAscDescBox.Location = new Point(86, 63);
            sortAscDescBox.Name = "sortAscDescBox";
            sortAscDescBox.Size = new Size(42, 21);
            sortAscDescBox.TabIndex = 18;
            // 
            // sortVariableBox
            // 
            sortVariableBox.DropDownStyle = ComboBoxStyle.DropDownList;
            sortVariableBox.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sortVariableBox.FormattingEnabled = true;
            sortVariableBox.Items.AddRange(new object[] { "Name", "ECTS", "Grade" });
            sortVariableBox.Location = new Point(131, 63);
            sortVariableBox.Name = "sortVariableBox";
            sortVariableBox.Size = new Size(42, 21);
            sortVariableBox.TabIndex = 19;
            // 
            // controlBox
            // 
            controlBox.Controls.Add(clearPlansBtn);
            controlBox.Controls.Add(minBtn);
            controlBox.Controls.Add(maxBtn);
            controlBox.Controls.Add(sortVariableBox);
            controlBox.Controls.Add(sortBtn);
            controlBox.Controls.Add(sortAscDescBox);
            controlBox.Controls.Add(clearAllBtn);
            controlBox.Controls.Add(planBtn);
            controlBox.Controls.Add(targetLbl);
            controlBox.Controls.Add(deleteCourseBtn);
            controlBox.Controls.Add(targetGPAUpDown);
            controlBox.Location = new Point(12, 374);
            controlBox.Name = "controlBox";
            controlBox.Size = new Size(180, 98);
            controlBox.TabIndex = 20;
            controlBox.TabStop = false;
            controlBox.Text = "Edit";
            // 
            // clearPlansBtn
            // 
            clearPlansBtn.BackColor = Color.Transparent;
            clearPlansBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clearPlansBtn.ForeColor = Color.Black;
            clearPlansBtn.Location = new Point(134, 17);
            clearPlansBtn.Name = "clearPlansBtn";
            clearPlansBtn.RightToLeft = RightToLeft.No;
            clearPlansBtn.Size = new Size(39, 29);
            clearPlansBtn.TabIndex = 24;
            clearPlansBtn.Text = "C";
            clearPlansBtn.UseVisualStyleBackColor = false;
            clearPlansBtn.Click += button1_Click_1;
            // 
            // minBtn
            // 
            minBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            minBtn.Location = new Point(6, 17);
            minBtn.Name = "minBtn";
            minBtn.Size = new Size(58, 29);
            minBtn.TabIndex = 23;
            minBtn.Text = "Min";
            minBtn.UseVisualStyleBackColor = true;
            minBtn.Click += minBtn_Click;
            // 
            // maxBtn
            // 
            maxBtn.BackColor = Color.Transparent;
            maxBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            maxBtn.ForeColor = Color.Black;
            maxBtn.Location = new Point(71, 17);
            maxBtn.Name = "maxBtn";
            maxBtn.RightToLeft = RightToLeft.No;
            maxBtn.Size = new Size(58, 29);
            maxBtn.TabIndex = 23;
            maxBtn.Text = "Max";
            maxBtn.UseVisualStyleBackColor = false;
            maxBtn.Click += maxBtn_Click;
            // 
            // planBtn
            // 
            planBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            planBtn.Location = new Point(76, 62);
            planBtn.Name = "planBtn";
            planBtn.Size = new Size(98, 28);
            planBtn.TabIndex = 22;
            planBtn.Text = "Plan";
            planBtn.UseVisualStyleBackColor = true;
            planBtn.Click += planBtn_Click;
            // 
            // targetLbl
            // 
            targetLbl.AutoSize = true;
            targetLbl.Location = new Point(6, 48);
            targetLbl.Name = "targetLbl";
            targetLbl.Size = new Size(64, 15);
            targetLbl.TabIndex = 22;
            targetLbl.Text = "Target GPA";
            targetLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // targetGPAUpDown
            // 
            targetGPAUpDown.DecimalPlaces = 2;
            targetGPAUpDown.Font = new Font("Segoe UI", 12F);
            targetGPAUpDown.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            targetGPAUpDown.Location = new Point(8, 63);
            targetGPAUpDown.Name = "targetGPAUpDown";
            targetGPAUpDown.Size = new Size(64, 29);
            targetGPAUpDown.TabIndex = 22;
            // 
            // totalECTSLbl
            // 
            totalECTSLbl.AutoSize = true;
            totalECTSLbl.BackColor = SystemColors.Control;
            totalECTSLbl.BorderStyle = BorderStyle.Fixed3D;
            totalECTSLbl.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic);
            totalECTSLbl.Location = new Point(198, 436);
            totalECTSLbl.Name = "totalECTSLbl";
            totalECTSLbl.Size = new Size(109, 21);
            totalECTSLbl.TabIndex = 21;
            totalECTSLbl.Text = "Total ECTS = :) ";
            totalECTSLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.FlatStyle = FlatStyle.Popup;
            checkBox1.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox1.Location = new Point(299, 38);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(51, 17);
            checkBox1.TabIndex = 23;
            checkBox1.Text = "Mod.";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.Click += checkBox1_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Control;
            button1.FlatStyle = FlatStyle.System;
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(298, 56);
            button1.Name = "button1";
            button1.Size = new Size(49, 29);
            button1.TabIndex = 24;
            button1.Text = "Modify";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 484);
            Controls.Add(button1);
            Controls.Add(checkBox1);
            Controls.Add(totalECTSLbl);
            Controls.Add(label4);
            Controls.Add(gradeLbx);
            Controls.Add(pointsLbx);
            Controls.Add(gradeSelector);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(gpaResultLbl);
            Controls.Add(numericUpDown1);
            Controls.Add(coursesLbx);
            Controls.Add(addCourseBtn);
            Controls.Add(courseNameBox);
            Controls.Add(menuStrip1);
            Controls.Add(controlBox);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Form1";
            Text = "GPA Calculator";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            controlBox.ResumeLayout(false);
            controlBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)targetGPAUpDown).EndInit();
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
        private ToolStripMenuItem clearSaveToolStripMenuItem;
        private Label label4;
        private Button sortBtn;
        private ComboBox sortAscDescBox;
        private ComboBox sortVariableBox;
        private GroupBox controlBox;
        private Label totalECTSLbl;
        private ToolStripMenuItem modeToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem planToolStripMenuItem;
        private Label targetLbl;
        private NumericUpDown targetGPAUpDown;
        private Button planBtn;
        private Button minBtn;
        private Button maxBtn;
        private Button clearPlansBtn;
        private CheckBox checkBox1;
        private Button button1;
    }
}
