using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace ImageTool
{
    public partial class MainForm : Form
    {
        public List<SortProject> Projects;

        NewSortProjectDialog _newProjectDialog;
        SortForm _sortForm;
		ComicListForm _comicForm;

        public MainForm()
        {
            InitializeComponent();
            Projects = new List<SortProject>(SaveManager.Load());
            foreach (SortProject project in Projects)
            {
                var item = new ListViewItem(project.Name);
                item.Tag = project.Id;
                projectList.Items.Add(item).SubItems.Add(project.Directory);
            }
        }

        public void RemoveProject(string id)
        {
            var projectId = id;
            var project = Projects.Where(x => x.Id == projectId).First();
            Projects.Remove(project);
            ListViewItem projectItem = null;
            foreach(ListViewItem item in projectList.Items)
            {
                if((string)item.Tag == project.Id)
                {
                    projectItem = item;
                    break;
                }
            }
            if(projectItem != null)
                projectList.Items.Remove(projectItem);
            SaveManager.DeleteProject(project);
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            _newProjectDialog = new NewSortProjectDialog();
            if (_newProjectDialog.ShowDialog() == DialogResult.OK)
            {
                var project = _newProjectDialog.Project;
                project.Id = GenerateProjectId(project.Name);
                Projects.Add(project);
                var item = new ListViewItem(project.Name);
                item.Tag = project.Id;
                projectList.Items.Add(item).SubItems.Add(project.Directory);
                SaveManager.Save(Projects.ToArray());
            }
        }

        private void projectList_ItemActivate(object sender, EventArgs e)
        {
            var projectId = (string)projectList.SelectedItems[0].Tag;
            var project = Projects.Where(x => x.Id == projectId).First();

			if(project.Type == SortProject.ProjectType.Images)
			{
				var result = MessageBox.Show("Random sort?", "Sort", MessageBoxButtons.YesNo);
				_sortForm = new SortForm(project, this, result == DialogResult.Yes);
				_sortForm.Tag = project.Id;
				_sortForm.Show();
			}
			else
			{
				_comicForm = new ComicListForm(project, this);
				_comicForm.Tag = project.Id;
				_comicForm.Show();
			}
        }

        private string GenerateProjectId(string projectName)
        {
            var invalidChars = Path.GetInvalidFileNameChars();
            var sanitizedName =
                new string(
                    projectName
                        .ToCharArray()
                        .Where(x => !invalidChars.Contains(x))
                        .ToArray()
                );
            sanitizedName = sanitizedName.ToLower().Replace(' ', '_');
            int num = 0;
            string finalName = sanitizedName;
            while(Projects.Where(x => x.Id == finalName).Any())
                finalName = sanitizedName + (num++);
            return finalName;
        }
    }
}
