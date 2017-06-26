namespace ImageTool
{
    partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.projectList = new System.Windows.Forms.ListView();
			this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.directoryColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// projectList
			// 
			this.projectList.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.projectList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.directoryColumn});
			this.projectList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.projectList.Location = new System.Drawing.Point(0, 0);
			this.projectList.MultiSelect = false;
			this.projectList.Name = "projectList";
			this.projectList.Size = new System.Drawing.Size(367, 324);
			this.projectList.TabIndex = 1;
			this.projectList.UseCompatibleStateImageBehavior = false;
			this.projectList.View = System.Windows.Forms.View.Details;
			this.projectList.ItemActivate += new System.EventHandler(this.projectList_ItemActivate);
			// 
			// nameColumn
			// 
			this.nameColumn.Text = "Name";
			this.nameColumn.Width = 120;
			// 
			// directoryColumn
			// 
			this.directoryColumn.Text = "Directory";
			this.directoryColumn.Width = 400;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 302);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(367, 22);
			this.statusStrip1.TabIndex = 2;
			// 
			// toolStripSplitButton1
			// 
			this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripSplitButton1.DropDownButtonWidth = 0;
			this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
			this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripSplitButton1.Name = "toolStripSplitButton1";
			this.toolStripSplitButton1.Size = new System.Drawing.Size(21, 20);
			this.toolStripSplitButton1.Text = "toolStripSplitButton1";
			this.toolStripSplitButton1.ButtonClick += new System.EventHandler(this.toolStripSplitButton1_ButtonClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(367, 324);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.projectList);
			this.Name = "MainForm";
			this.Text = "Image Tool";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView projectList;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ColumnHeader nameColumn;
        private System.Windows.Forms.ColumnHeader directoryColumn;
    }
}

