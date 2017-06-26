namespace ImageTool
{
    partial class NewSortProjectDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.label1 = new System.Windows.Forms.Label();
			this.projectNameBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.directoryBox = new System.Windows.Forms.TextBox();
			this.browseButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.createButton = new System.Windows.Forms.Button();
			this.projectType = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Project Name";
			// 
			// projectNameBox
			// 
			this.projectNameBox.Location = new System.Drawing.Point(89, 12);
			this.projectNameBox.Name = "projectNameBox";
			this.projectNameBox.Size = new System.Drawing.Size(269, 20);
			this.projectNameBox.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Directory";
			// 
			// directoryBox
			// 
			this.directoryBox.Location = new System.Drawing.Point(89, 38);
			this.directoryBox.Name = "directoryBox";
			this.directoryBox.ReadOnly = true;
			this.directoryBox.Size = new System.Drawing.Size(239, 20);
			this.directoryBox.TabIndex = 3;
			// 
			// browseButton
			// 
			this.browseButton.Location = new System.Drawing.Point(334, 38);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new System.Drawing.Size(24, 21);
			this.browseButton.TabIndex = 4;
			this.browseButton.Text = "...";
			this.browseButton.UseVisualStyleBackColor = true;
			this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(283, 92);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 5;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// createButton
			// 
			this.createButton.Location = new System.Drawing.Point(195, 92);
			this.createButton.Name = "createButton";
			this.createButton.Size = new System.Drawing.Size(75, 23);
			this.createButton.TabIndex = 6;
			this.createButton.Text = "Create";
			this.createButton.UseVisualStyleBackColor = true;
			this.createButton.Click += new System.EventHandler(this.createButton_Click);
			// 
			// projectType
			// 
			this.projectType.FormattingEnabled = true;
			this.projectType.Items.AddRange(new object[] {
            "Images",
            "Comics"});
			this.projectType.Location = new System.Drawing.Point(89, 65);
			this.projectType.Name = "projectType";
			this.projectType.Size = new System.Drawing.Size(269, 21);
			this.projectType.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 68);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(31, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Type";
			// 
			// NewSortProjectDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(370, 123);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.projectType);
			this.Controls.Add(this.createButton);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.browseButton);
			this.Controls.Add(this.directoryBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.projectNameBox);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "NewSortProjectDialog";
			this.Text = "New Sort Project";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox projectNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox directoryBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button createButton;
		private System.Windows.Forms.ComboBox projectType;
		private System.Windows.Forms.Label label3;
	}
}