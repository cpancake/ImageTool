namespace ImageTool
{
    partial class SortForm
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
			this.splitter = new System.Windows.Forms.SplitContainer();
			this.countLabel = new System.Windows.Forms.Label();
			this.cancelSort = new System.Windows.Forms.Button();
			this.finalizeSort = new System.Windows.Forms.Button();
			this.openButton = new System.Windows.Forms.Button();
			this.yesButton = new System.Windows.Forms.Button();
			this.noButton = new System.Windows.Forms.Button();
			this.prevButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
			this.splitter.Panel2.SuspendLayout();
			this.splitter.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitter
			// 
			this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitter.IsSplitterFixed = true;
			this.splitter.Location = new System.Drawing.Point(0, 0);
			this.splitter.Name = "splitter";
			this.splitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitter.Panel2
			// 
			this.splitter.Panel2.Controls.Add(this.prevButton);
			this.splitter.Panel2.Controls.Add(this.countLabel);
			this.splitter.Panel2.Controls.Add(this.cancelSort);
			this.splitter.Panel2.Controls.Add(this.finalizeSort);
			this.splitter.Panel2.Controls.Add(this.openButton);
			this.splitter.Panel2.Controls.Add(this.yesButton);
			this.splitter.Panel2.Controls.Add(this.noButton);
			this.splitter.Size = new System.Drawing.Size(604, 302);
			this.splitter.SplitterDistance = 276;
			this.splitter.SplitterWidth = 1;
			this.splitter.TabIndex = 0;
			// 
			// countLabel
			// 
			this.countLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.countLabel.AutoSize = true;
			this.countLabel.Location = new System.Drawing.Point(174, 8);
			this.countLabel.Name = "countLabel";
			this.countLabel.Size = new System.Drawing.Size(35, 13);
			this.countLabel.TabIndex = 5;
			this.countLabel.Text = "label1";
			// 
			// cancelSort
			// 
			this.cancelSort.Location = new System.Drawing.Point(93, 3);
			this.cancelSort.Name = "cancelSort";
			this.cancelSort.Size = new System.Drawing.Size(75, 23);
			this.cancelSort.TabIndex = 4;
			this.cancelSort.Text = "Cancel";
			this.cancelSort.UseVisualStyleBackColor = true;
			this.cancelSort.Click += new System.EventHandler(this.cancelSort_Click);
			// 
			// finalizeSort
			// 
			this.finalizeSort.Location = new System.Drawing.Point(12, 3);
			this.finalizeSort.Name = "finalizeSort";
			this.finalizeSort.Size = new System.Drawing.Size(75, 23);
			this.finalizeSort.TabIndex = 3;
			this.finalizeSort.Text = "Finalize";
			this.finalizeSort.UseVisualStyleBackColor = true;
			this.finalizeSort.Click += new System.EventHandler(this.finalizeSort_Click);
			// 
			// openButton
			// 
			this.openButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.openButton.Location = new System.Drawing.Point(355, 3);
			this.openButton.Name = "openButton";
			this.openButton.Size = new System.Drawing.Size(75, 23);
			this.openButton.TabIndex = 2;
			this.openButton.Text = "Open";
			this.openButton.UseVisualStyleBackColor = true;
			this.openButton.Click += new System.EventHandler(this.openButton_Click);
			// 
			// yesButton
			// 
			this.yesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.yesButton.Location = new System.Drawing.Point(436, 3);
			this.yesButton.Name = "yesButton";
			this.yesButton.Size = new System.Drawing.Size(75, 23);
			this.yesButton.TabIndex = 1;
			this.yesButton.Text = "Yes";
			this.yesButton.UseVisualStyleBackColor = true;
			this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
			// 
			// noButton
			// 
			this.noButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.noButton.Location = new System.Drawing.Point(517, 3);
			this.noButton.Name = "noButton";
			this.noButton.Size = new System.Drawing.Size(75, 23);
			this.noButton.TabIndex = 0;
			this.noButton.Text = "No";
			this.noButton.UseVisualStyleBackColor = true;
			this.noButton.Click += new System.EventHandler(this.noButton_Click);
			// 
			// prevButton
			// 
			this.prevButton.Location = new System.Drawing.Point(274, 3);
			this.prevButton.Name = "prevButton";
			this.prevButton.Size = new System.Drawing.Size(75, 23);
			this.prevButton.TabIndex = 6;
			this.prevButton.Text = "Previous";
			this.prevButton.UseVisualStyleBackColor = true;
			this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
			// 
			// SortForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(604, 302);
			this.Controls.Add(this.splitter);
			this.Name = "SortForm";
			this.Text = "Sort";
			this.Load += new System.EventHandler(this.SortForm_Load);
			this.Resize += new System.EventHandler(this.SortForm_Resize);
			this.splitter.Panel2.ResumeLayout(false);
			this.splitter.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
			this.splitter.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitter;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button yesButton;
        private System.Windows.Forms.Button cancelSort;
        private System.Windows.Forms.Button finalizeSort;
        private System.Windows.Forms.Label countLabel;
		private System.Windows.Forms.Button prevButton;
	}
}