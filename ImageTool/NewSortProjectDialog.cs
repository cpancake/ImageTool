using System;
using System.IO;
using System.Windows.Forms;
using Ookii.Dialogs;

namespace ImageTool
{
    public partial class NewSortProjectDialog : Form
    {
        public SortProject Project;

        VistaFolderBrowserDialog _folderDialog = null;

        public NewSortProjectDialog()
        {
            InitializeComponent();
			projectType.SelectedIndex = 0;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            _folderDialog = new VistaFolderBrowserDialog();
            if (_folderDialog.ShowDialog() == DialogResult.OK)
            {
                directoryBox.Text = _folderDialog.SelectedPath;
                if (string.IsNullOrWhiteSpace(projectNameBox.Text))
                    projectNameBox.Text = Path.GetFileName(_folderDialog.SelectedPath); 
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(projectNameBox.Text) ||
                string.IsNullOrWhiteSpace(directoryBox.Text))
                return;
            DialogResult = DialogResult.OK;
            this.Hide();
            Project = new SortProject(projectNameBox.Text, directoryBox.Text)
			{
				Type = (SortProject.ProjectType)
					Enum.Parse(typeof(SortProject.ProjectType), (string)projectType.SelectedItem)
			};
        }
    }
}
