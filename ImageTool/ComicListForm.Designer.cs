namespace ImageTool
{
	partial class ComicListForm
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
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.finalizeButton = new System.Windows.Forms.Button();
			this.comicsView = new System.Windows.Forms.ListView();
			this.cancelButton = new System.Windows.Forms.Button();
			this.titleHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.decisionHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.noButton = new System.Windows.Forms.Button();
			this.yesButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.comicsView);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.yesButton);
			this.splitContainer.Panel2.Controls.Add(this.noButton);
			this.splitContainer.Panel2.Controls.Add(this.cancelButton);
			this.splitContainer.Panel2.Controls.Add(this.finalizeButton);
			this.splitContainer.Size = new System.Drawing.Size(626, 613);
			this.splitContainer.SplitterDistance = 575;
			this.splitContainer.TabIndex = 0;
			// 
			// finalizeButton
			// 
			this.finalizeButton.Location = new System.Drawing.Point(12, 3);
			this.finalizeButton.Name = "finalizeButton";
			this.finalizeButton.Size = new System.Drawing.Size(75, 23);
			this.finalizeButton.TabIndex = 0;
			this.finalizeButton.Text = "Finalize";
			this.finalizeButton.UseVisualStyleBackColor = true;
			this.finalizeButton.Click += new System.EventHandler(this.finalizeButton_Click);
			// 
			// comicsView
			// 
			this.comicsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.titleHeader,
            this.decisionHeader});
			this.comicsView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comicsView.Location = new System.Drawing.Point(0, 0);
			this.comicsView.MultiSelect = false;
			this.comicsView.Name = "comicsView";
			this.comicsView.Size = new System.Drawing.Size(626, 575);
			this.comicsView.TabIndex = 0;
			this.comicsView.UseCompatibleStateImageBehavior = false;
			this.comicsView.View = System.Windows.Forms.View.Details;
			this.comicsView.ItemActivate += new System.EventHandler(this.comicsView_ItemActivate);
			this.comicsView.SelectedIndexChanged += new System.EventHandler(this.comicsView_SelectedIndexChanged);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.Location = new System.Drawing.Point(539, 3);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// titleHeader
			// 
			this.titleHeader.Text = "Title";
			this.titleHeader.Width = 557;
			// 
			// decisionHeader
			// 
			this.decisionHeader.Text = "Decision";
			this.decisionHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// noButton
			// 
			this.noButton.Location = new System.Drawing.Point(458, 3);
			this.noButton.Name = "noButton";
			this.noButton.Size = new System.Drawing.Size(75, 23);
			this.noButton.TabIndex = 2;
			this.noButton.Text = "No";
			this.noButton.UseVisualStyleBackColor = true;
			this.noButton.Click += new System.EventHandler(this.noButton_Click);
			// 
			// yesButton
			// 
			this.yesButton.Location = new System.Drawing.Point(377, 3);
			this.yesButton.Name = "yesButton";
			this.yesButton.Size = new System.Drawing.Size(75, 23);
			this.yesButton.TabIndex = 3;
			this.yesButton.Text = "Yes";
			this.yesButton.UseVisualStyleBackColor = true;
			this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
			// 
			// ComicListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(626, 613);
			this.Controls.Add(this.splitContainer);
			this.Name = "ComicListForm";
			this.Text = "Comics";
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.Button finalizeButton;
		private System.Windows.Forms.ListView comicsView;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.ColumnHeader titleHeader;
		private System.Windows.Forms.ColumnHeader decisionHeader;
		private System.Windows.Forms.Button yesButton;
		private System.Windows.Forms.Button noButton;
	}
}