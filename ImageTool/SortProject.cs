using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageTool
{
    public class SortProject
    {
		/// <summary>
		/// The set of finished files.
		/// </summary>
        private HashSet<string> _finishedFiles;
		/// <summary>
		/// The set of finished files modified in this session (i.e. only since last load)
		/// </summary>
        private HashSet<string> _finishedFileBuffer;
		/// <summary>
		/// The set of file history.
		/// </summary>
		private HashSet<string> _history;
		/// <summary>
		/// The set of file history for files modified in this session.
		/// </summary>
		private HashSet<string> _historyBuffer;

		/// <summary>
		/// The ID of this project (the filename).
		/// </summary>
        public string Id;
		/// <summary>
		/// The human name of this project.
		/// </summary>
        public string Name;
		/// <summary>
		/// The directory this project sorts.
		/// </summary>
        public string Directory;
		/// <summary>
		/// The type of the project.
		/// </summary>
		public ProjectType Type = ProjectType.Images;
		/// <summary>
		/// The number of items in the history buffer.
		/// </summary>
		public int HistoryCount = 0;

		/// <summary>
		/// List of finished files (files that have already been checked).
		/// </summary>
        public HashSet<string> FinishedFiles
        {
            get { return _finishedFiles; }
        }

		/// <summary>
		/// History of files already checked.
		/// </summary>
		public HashSet<string> History
		{
			get { return _history; }
		}

		/// <summary>
		/// Adds a finished file.
		/// </summary>
        public void AddFinishedFile(string file)
        {
            _finishedFiles.Add(file);
            _finishedFileBuffer.Add(file);
        }

		/// <summary>
		/// Removes a finished file.
		/// </summary>
		public void RemoveFinishedFile(string file)
		{
			_finishedFiles.Remove(file);
			_finishedFileBuffer.Remove(file);
		}

		/// <summary>
		/// Add an item to the history.
		/// </summary>
		public void AddHistory(string file)
		{
			_history.Add(file);
			_historyBuffer.Add(file);
			HistoryCount++;
		}

		/// <summary>
		/// Removes an item from the history.
		/// </summary>
		public void RemoveHistory(string file)
		{
			_history.Remove(file);
			_historyBuffer.Remove(file);
			HistoryCount--;
		}

		/// <summary>
		/// Returns the "buffer" of finished files.
		/// </summary>
        public HashSet<string> GetBuffer()
        {
            return _finishedFileBuffer;
        }

		/// <summary>
		/// Clears the finished file buffer (when the file is saved).
		/// </summary>
        public void ClearBuffer()
        {
            _finishedFileBuffer.Clear();
        }

		/// <summary>
		/// Gets the history buffer.
		/// </summary>
		public HashSet<string> GetHistoryBuffer()
		{
			return _historyBuffer;
		}

		/// <summary>
		/// Clears the history buffer (when the file is saved).
		/// </summary>
		public void ClearHistoryBuffer()
		{
			_historyBuffer.Clear();
		}

		/// <summary>
		/// The number of finished files.
		/// </summary>
        public int FinishedFileCount => _finishedFiles.Count;

        public SortProject(string name, string directory, HashSet<string> finishedFiles, HashSet<string> history)
        {
            this.Name = name;
            this.Directory = directory;
            this._finishedFiles = finishedFiles;
            this._finishedFileBuffer = new HashSet<string>();
			this._history = history;
			this._historyBuffer = new HashSet<string>();
        }

        public SortProject(string name, string directory)
            : this(name, directory, new HashSet<string>(), new HashSet<string>())
        {
        }

		public SortProject(string name, string directory, HashSet<string> finishedFiles)
			: this(name, directory, finishedFiles, new HashSet<string>())
		{

		}

		public enum ProjectType
		{
			Images,
			Comics
		}
    }
}
