using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;

namespace ImageTool
{
	public partial class ComicListForm : Form
	{
		private SortProject _project;
		private MainForm _mainForm;

		public ComicListForm(SortProject project, MainForm form)
		{
			InitializeComponent();
			_project = project;
			_mainForm = form;
			RefreshComics();
			yesButton.Enabled = false;
			noButton.Enabled = false;
		}

		// refresh the list of comics
		private void RefreshComics()
		{
			// we encode verdicts within filenames
			var verdicts = new Dictionary<string, bool>();
			foreach(string file in _project.FinishedFiles)
			{
				var parts = file.Split(';');
				verdicts[parts[0]] = (parts[1] == "yes");
			}

			// find all directories with
			var dirs = Directory
				.EnumerateDirectories(_project.Directory)
				.Select(d => Path.GetFileName(d))
				.OrderByAlphaNumeric(d => d);

			var selectedItem = (comicsView.SelectedItems.Count > 0 ? comicsView.SelectedItems[0].Text : null);

			// reset list view
			comicsView.Items.Clear();
			foreach(string dir in dirs)
			{
				var item = new ListViewItem();
				item.Text = dir;
				var verdictText = "-";
				if(verdicts.ContainsKey(dir))
				{
					verdictText = verdicts[dir] ? "Yes" : "No";
				}
				item.SubItems.Add(verdictText);

				if(dir == selectedItem)
				{
					item.Selected = true;
				}

				comicsView.Items.Add(item);
			}

			comicsView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			comicsView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}

		private void comicsView_ItemActivate(object sender, EventArgs e)
		{
			var dir = Path.Combine(_project.Directory, comicsView.SelectedItems[0].Text);
			var files = Directory.EnumerateFiles(dir);
			// if there are no images in the comic, abort
			if(!files.Any())
			{
				MessageBox.Show("The directory is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// open up the first image of the comic
			// hopefully your image viewer can help you from here
			Process.Start(Path.Combine(dir, files.OrderByAlphaNumeric(s => s).First()));
		}

		private void yesButton_Click(object sender, EventArgs e)
		{
			var comic = comicsView.SelectedItems[0].Text;
			_project.AddFinishedFile(comic + ";yes");
			comicsView.SelectedItems[0].SubItems[1].Text = "Yes";
			SaveManager.SaveProject(_project);
		}

		private void noButton_Click(object sender, EventArgs e)
		{
			var comic = comicsView.SelectedItems[0].Text;
			_project.AddFinishedFile(comic + ";no");
			comicsView.SelectedItems[0].SubItems[1].Text = "No";
			SaveManager.SaveProject(_project);
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void finalizeButton_Click(object sender, EventArgs e)
		{
			var choice = MessageBox.Show("Are you sure you want to finalize this sort project?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if(choice == DialogResult.Yes)
			{
				foreach(string finished in _project.FinishedFiles)
				{
					var parts = finished.Split(';');
					// delete all "no" comics
					if(parts[1] == "no")
					{
						FileSystem.DeleteDirectory(
							Path.Combine(_project.Directory, parts[0]), 
							UIOption.OnlyErrorDialogs, 
							RecycleOption.SendToRecycleBin);
					}
				}

				_mainForm.RemoveProject((string)Tag);
				this.Close();
			}
		}

		private void comicsView_SelectedIndexChanged(object sender, EventArgs e)
		{
			yesButton.Enabled = true;
			noButton.Enabled = true;
		}
	}
}
