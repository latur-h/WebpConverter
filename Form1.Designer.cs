namespace WebpConverter
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
            rt_Console = new RichTextBox();
            button_Convert_File = new Button();
            button_Convert_Directory = new Button();
            radioButton_DefaultPath = new RadioButton();
            radioButton_LastPath = new RadioButton();
            groupBox_Path = new GroupBox();
            button_SetDefaultFolder = new Button();
            textBox_X = new TextBox();
            textBox_Y = new TextBox();
            textBox_Quality = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button_Save = new Button();
            button_Restore = new Button();
            label_Version = new Label();
            groupBox_Path.SuspendLayout();
            SuspendLayout();
            // 
            // rt_Console
            // 
            rt_Console.BackColor = Color.Black;
            rt_Console.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rt_Console.ForeColor = SystemColors.ControlLight;
            rt_Console.Location = new Point(12, 12);
            rt_Console.Name = "rt_Console";
            rt_Console.ReadOnly = true;
            rt_Console.Size = new Size(633, 426);
            rt_Console.TabIndex = 0;
            rt_Console.Text = "";
            // 
            // button_Convert_File
            // 
            button_Convert_File.Location = new Point(651, 12);
            button_Convert_File.Name = "button_Convert_File";
            button_Convert_File.Size = new Size(137, 39);
            button_Convert_File.TabIndex = 1;
            button_Convert_File.Text = "Convert files";
            button_Convert_File.UseVisualStyleBackColor = true;
            button_Convert_File.Click += button_Convert_File_Click;
            // 
            // button_Convert_Directory
            // 
            button_Convert_Directory.Location = new Point(651, 96);
            button_Convert_Directory.Name = "button_Convert_Directory";
            button_Convert_Directory.Size = new Size(137, 47);
            button_Convert_Directory.TabIndex = 2;
            button_Convert_Directory.Text = "Convert all files in directory";
            button_Convert_Directory.UseVisualStyleBackColor = true;
            button_Convert_Directory.Click += button_Convert_Directory_Click;
            // 
            // radioButton_DefaultPath
            // 
            radioButton_DefaultPath.AutoSize = true;
            radioButton_DefaultPath.Location = new Point(6, 22);
            radioButton_DefaultPath.Name = "radioButton_DefaultPath";
            radioButton_DefaultPath.Size = new Size(90, 19);
            radioButton_DefaultPath.TabIndex = 3;
            radioButton_DefaultPath.TabStop = true;
            radioButton_DefaultPath.Text = "Default Path";
            radioButton_DefaultPath.UseVisualStyleBackColor = true;
            radioButton_DefaultPath.Click += radioButton_DefaultPath_Click;
            // 
            // radioButton_LastPath
            // 
            radioButton_LastPath.AutoSize = true;
            radioButton_LastPath.Location = new Point(6, 47);
            radioButton_LastPath.Name = "radioButton_LastPath";
            radioButton_LastPath.Size = new Size(73, 19);
            radioButton_LastPath.TabIndex = 4;
            radioButton_LastPath.TabStop = true;
            radioButton_LastPath.Text = "Last Path";
            radioButton_LastPath.UseVisualStyleBackColor = true;
            // 
            // groupBox_Path
            // 
            groupBox_Path.Controls.Add(radioButton_DefaultPath);
            groupBox_Path.Controls.Add(radioButton_LastPath);
            groupBox_Path.Location = new Point(651, 366);
            groupBox_Path.Name = "groupBox_Path";
            groupBox_Path.Size = new Size(137, 72);
            groupBox_Path.TabIndex = 5;
            groupBox_Path.TabStop = false;
            // 
            // button_SetDefaultFolder
            // 
            button_SetDefaultFolder.Location = new Point(651, 349);
            button_SetDefaultFolder.Name = "button_SetDefaultFolder";
            button_SetDefaultFolder.Size = new Size(137, 23);
            button_SetDefaultFolder.TabIndex = 6;
            button_SetDefaultFolder.Text = "Set Default Folder";
            button_SetDefaultFolder.UseVisualStyleBackColor = true;
            button_SetDefaultFolder.Click += button_SetDefaultFolder_Click;
            // 
            // textBox_X
            // 
            textBox_X.Location = new Point(695, 177);
            textBox_X.Name = "textBox_X";
            textBox_X.Size = new Size(93, 23);
            textBox_X.TabIndex = 7;
            // 
            // textBox_Y
            // 
            textBox_Y.Location = new Point(695, 206);
            textBox_Y.Name = "textBox_Y";
            textBox_Y.Size = new Size(93, 23);
            textBox_Y.TabIndex = 8;
            // 
            // textBox_Quality
            // 
            textBox_Quality.Location = new Point(695, 254);
            textBox_Quality.Name = "textBox_Quality";
            textBox_Quality.Size = new Size(93, 23);
            textBox_Quality.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(644, 180);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 10;
            label1.Text = "Width:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(644, 209);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 11;
            label2.Text = "Height:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(644, 257);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 12;
            label3.Text = "Quality:";
            // 
            // button_Save
            // 
            button_Save.Location = new Point(651, 292);
            button_Save.Name = "button_Save";
            button_Save.Size = new Size(61, 23);
            button_Save.TabIndex = 13;
            button_Save.Text = "Save";
            button_Save.UseVisualStyleBackColor = true;
            button_Save.Click += button_Save_Click;
            // 
            // button_Restore
            // 
            button_Restore.Location = new Point(713, 292);
            button_Restore.Name = "button_Restore";
            button_Restore.Size = new Size(75, 23);
            button_Restore.TabIndex = 14;
            button_Restore.Text = "Restore";
            button_Restore.UseVisualStyleBackColor = true;
            button_Restore.Click += button_Restore_Click;
            // 
            // label_Version
            // 
            label_Version.AutoSize = true;
            label_Version.Enabled = false;
            label_Version.Location = new Point(750, 426);
            label_Version.Name = "label_Version";
            label_Version.Size = new Size(0, 15);
            label_Version.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label_Version);
            Controls.Add(button_Restore);
            Controls.Add(button_Save);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox_Quality);
            Controls.Add(textBox_Y);
            Controls.Add(textBox_X);
            Controls.Add(button_SetDefaultFolder);
            Controls.Add(groupBox_Path);
            Controls.Add(button_Convert_Directory);
            Controls.Add(button_Convert_File);
            Controls.Add(rt_Console);
            Name = "Form1";
            Text = "Webp Converter";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            groupBox_Path.ResumeLayout(false);
            groupBox_Path.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public RichTextBox rt_Console;
        public Button button_Convert_File;
        public Button button_Convert_Directory;
        public RadioButton radioButton_DefaultPath;
        public RadioButton radioButton_LastPath;
        public GroupBox groupBox_Path;
        public Button button_SetDefaultFolder;
        public TextBox textBox_X;
        public TextBox textBox_Y;
        public TextBox textBox_Quality;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button_Save;
        private Button button_Restore;
        private Label label_Version;
    }
}
