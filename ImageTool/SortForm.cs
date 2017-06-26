using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Vlc.DotNet.Forms;

namespace ImageTool
{
	public partial class SortForm : Form
	{
		private string[] _imageFormats = new string[] { ".jpg", ".jpeg", ".png", ".gif" };
		private string[] _videoFormats = new string[] { ".webm", ".mp4" };
		private SortProject _project;
		private string _currentImageLocation;
		private MainForm _mainForm;
		private VlcControl _vlcControl;
		private PictureBox _pictureBox;
		private bool _randomSort;

		public SortForm(SortProject project, MainForm mainForm, bool randomSort)
		{
			InitializeComponent();
			_randomSort = randomSort;
			_mainForm = mainForm;
			_project = project;

			// vlc control used for webms
			_vlcControl = new VlcControl();
			_vlcControl.VlcMediaplayerOptions = new string[] { "--loop" };
			_vlcControl.VlcLibDirectoryNeeded += VlcLibDirectoryNeeded;
			_vlcControl.EndReached += EndReached;
			_vlcControl.Dock = DockStyle.Fill;
			_vlcControl.BackColor = SystemColors.Control;
			_vlcControl.VlcLibDirectory = new DirectoryInfo(".");
			_vlcControl.EndInit();
			_vlcControl.Visible = false;

			// picture box used for everything else - the vlc control can show images, but it's a lot slower than the picture box
			// we disable both and choose which one to display based on the filetype of the current image
			_pictureBox = new PictureBox();
			_pictureBox.Dock = DockStyle.Fill;
			_pictureBox.Visible = false;
			_pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

			splitter.Panel1.Controls.Add(_vlcControl);
			splitter.Panel1.Controls.Add(_pictureBox);

			// load the first image
			LoadImage(FindNextImage());
		}

		private void EndReached(object sender, Vlc.DotNet.Core.VlcMediaPlayerEndReachedEventArgs e)
		{
			_vlcControl.Play(new FileInfo(_currentImageLocation));
		}

		private void VlcLibDirectoryNeeded(object sender, VlcLibDirectoryNeededEventArgs e)
		{
			e.VlcLibDirectory = new DirectoryInfo(".");
		}

		/// <summary>
		/// Loads the provided image and displays it.
		/// </summary>
		/// <param name="name">The filename to load.</param>
		private void LoadImage(string name)
		{
			// Stop the current video.
			if (_vlcControl.IsPlaying)
				_vlcControl.Stop();

			// Unload the current image, if there is one.
			if (_pictureBox.Image != null)
				_pictureBox.Image.Dispose();

			// If there is no next image, stop.
			if (name == null)
			{
				_vlcControl.Stop();
				_pictureBox.Image = null;
				Text = "Sort";
				return;
			}

			var oldLocation = _currentImageLocation;
			try
			{
				_currentImageLocation = Path.Combine(_project.Directory, name);

				// If it's a video, use VLC.
				if (_videoFormats.Contains(Path.GetExtension(name).ToLower()))
				{
					_vlcControl.SetMedia(new FileInfo(_currentImageLocation));
					if (!_vlcControl.IsPlaying)
						_vlcControl.Play();
					_vlcControl.Visible = true;
					_pictureBox.Visible = false;
				}
				// Otherwise, use the picture box.
				else
				{
					_pictureBox.Image = Image.FromFile(_currentImageLocation);
					_vlcControl.Visible = false;
					_pictureBox.Visible = true;
				}
			}
			catch (OutOfMemoryException e)
			{
				// picture box throws out of memory exception when an image isn't valid, for some reason
				// Return to the previous image.
				_currentImageLocation = oldLocation;
				MessageBox.Show(
					this,
					"Can't open " + name + ". This might mean it's an invalid image. Check it out.",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
				return;
			}

			Text = "Sort - " + Path.GetFileName(name);
		}

		/// <summary>
		/// Finds the next image to display.
		/// </summary>
		/// <returns>The name of the next image to display, or null if we're done.</returns>
		private string FindNextImage()
		{
			if (!Directory.Exists(_project.Directory))
				return null;

			var files = Directory.EnumerateFiles(_project.Directory);
			var rand = new Random();

			// Only load files that we haven't finished and that are images.
			var f = files
				.Where(
					name =>
						!_project.FinishedFiles.Contains(Path.GetFileName(name)) &&
						CheckExtension(name));

			// sort randomly instead
			if (_randomSort)
			{
				f = f.OrderBy(_ => rand.Next());
			}

			// If there's no images, we're done.
			if (!f.Any())
			{
				MessageBox.Show("There are no more files to sort!", "Error", MessageBoxButtons.OK);
				return null;
			}

			// Set the count and return the first image.
			countLabel.Text = $"{f.Count()} Images Remaining";
			return f.First();
		}

		/// <summary>
		/// Make sure the file is of the correct extension.
		/// </summary>
		/// <param name="name">The name of the file.</param>
		/// <returns>True if it's openable, false if not.</returns>
		private bool CheckExtension(string name)
		{
			var ext = Path.GetExtension(name).ToLower();
			return _imageFormats.Contains(ext) || _videoFormats.Contains(ext);
		}

		// Toggle the buttons that act on the current image.
		private void ToggleButtons(bool val)
		{
			openButton.Enabled = val;
			yesButton.Enabled = val;
			noButton.Enabled = val;
		}

		// open the image directly
		private void openButton_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(_currentImageLocation);
		}

		private void noButton_Click(object sender, EventArgs e)
		{
			// Disable the buttons.
			ToggleButtons(false);

			// Move the file to the delete directory, if it exists.
			var deletePath = Path.Combine(_project.Directory, ".delete");
			if (!Directory.Exists(deletePath))
				Directory.CreateDirectory(deletePath);

			string oldImage = _currentImageLocation;

			_vlcControl.Stop();
			if (_pictureBox.Image != null)
				_pictureBox.Image.Dispose();
			_pictureBox.Image = null;

			// See if the new path is too long.
			var currentPathLength = _project.Directory.Length + ".delete".Length + 3;
			string fileName = Path.GetFileName(oldImage);

			// If it is, shorten the name.
			if (fileName.Length > 260 - currentPathLength)
			{
				var targetSize = 260 - currentPathLength;
				targetSize -= (Path.GetExtension(oldImage).Length);

				// Set the new name to a shorter version.
				string newName = Path.GetFileNameWithoutExtension(oldImage).Substring(0, targetSize - 3);
				string app = "";
				int cnt = 0;

				// Make sure we're not accidentally overwritting a file.
				while (
					File.Exists(
						Path.Combine(
							_project.Directory,
							".delete",
							newName + app + Path.GetExtension(oldImage))))
				{
					cnt++;
					app = cnt.ToString();
				}
				fileName = newName + app + Path.GetExtension(oldImage);
			}

			File.Move(oldImage, Path.Combine(_project.Directory, ".delete", fileName));

			// Add the last file to the history.
			_project.AddHistory("no," + Path.Combine(_project.Directory, ".delete", fileName));
			prevButton.Enabled = true;

			// Load the next image.
			LoadImage(FindNextImage());

			// Reenable the buttons.
			ToggleButtons(true);

			// Save the project.
			SaveManager.SaveProject(_project);
		}

		private void yesButton_Click(object sender, EventArgs e)
		{
			// Disable the buttons.
			ToggleButtons(false);

			// Add the file to the list of finished images.
			_project.AddFinishedFile(Path.GetFileName(_currentImageLocation));

			// Add the last file to the history.
			_project.AddHistory("yes," + _currentImageLocation);
			prevButton.Enabled = true;

			// Load the next image.
			LoadImage(FindNextImage());

			// Reenable the buttons.
			ToggleButtons(true);

			// Save the project.
			SaveManager.SaveProject(_project);
		}

		private void cancelSort_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void finalizeSort_Click(object sender, EventArgs e)
		{
			if (
				MessageBox.Show(
					"Are you sure you want to finalize this sorting project?",
					"Finalize",
					MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				// Delete the .delete directory.
				var deleteDir = Path.Combine(_project.Directory, ".delete");
				if (Directory.Exists(deleteDir))
				{
					foreach (string file in Directory.GetFiles(deleteDir))
						File.Delete(Path.Combine(deleteDir, file));
					Directory.Delete(deleteDir);
				}

				// Remove the project.
				_mainForm.RemoveProject((string)Tag);
				Close();
			}
		}
		
		private void prevButton_Click(object sender, EventArgs e)
		{
			// if there are no previous images, 
			var history = _project.History;
			if (history.Count == 0)
				return;

			// check the last item in the history list
			var last = history.Last();
			var parts = last.Split(',');
			var dest = parts[0];
			var file = parts[1];

			// if it wasn't moved, just remove it from the list of finished files
			if (dest == "yes")
			{
				_project.RemoveFinishedFile(Path.GetFileName(file));
			}
			else // if it was moved (it was a no), move it back
			{
				var newPath = Path.Combine(_project.Directory, Path.GetFileName(file));
				File.Move(file, newPath);
				file = newPath;
			}

			// load the image and remove it from the history list
			LoadImage(file);
			_project.RemoveHistory(last);

			// Save the project.
			SaveManager.SaveProject(_project);

			// disable the prev button if there's no more history
			if (_project.History.Count == 0)
			{
				prevButton.Enabled = true;
			}
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			// allow using keyboard shortcuts for navigation
			// we have to use ProcessCmdKey because the built-in event for keypresses is bad
			if (keyData == Keys.W)
				yesButton.PerformClick();
			else if (keyData == Keys.S)
				noButton.PerformClick();
			else if (keyData == Keys.O)
				openButton.PerformClick();
			else if (keyData == Keys.A)
				prevButton.PerformClick();
			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void SortForm_Load(object sender, EventArgs e)
		{
			// disable prev button if no history
			if (_project.History.Count == 0)
			{
				prevButton.Enabled = false;
			}
		}

		private void SortForm_Resize(object sender, EventArgs e)
		{
			// doesn't respect dock for some reason
			_vlcControl.Size = splitter.Panel1.ClientSize;
		}
	}
}
