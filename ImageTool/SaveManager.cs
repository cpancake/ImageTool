using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageTool
{
    public static class SaveManager
    {
		/// <summary>
		/// Saves several projects.
		/// </summary>
        public static void Save(SortProject[] projects)
        {
            var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            CreateDataDirectory(appDataFolder);
            foreach(SortProject project in projects)
                SaveProject(project);
        }

		/// <summary>
		/// Saves a single project.
		/// </summary>
        public static void SaveProject(SortProject project)
        {
			// find the app folder and ensure it's created.
            var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            CreateDataDirectory(appDataFolder);

            var filePath = Path.Combine(appDataFolder, "imagetool",  project.Id + ".dat");
            var fileExists = File.Exists(filePath);
            var outputFile = File.Open(
                filePath,
                FileMode.Append
            );

            var outputWriter = new StreamWriter(outputFile);
			// if the file doesn't exist, write the header
			if (!fileExists)
            {
                outputWriter.WriteLine("--project2--");
                outputWriter.WriteLine(project.Id);
                outputWriter.WriteLine(project.Name);
                outputWriter.WriteLine(project.Directory);
				outputWriter.WriteLine(project.Type);
                foreach (string file in project.FinishedFiles)
                    outputWriter.WriteLine(file);
            }
            else // if the file exists, just write the files that have changed since last save
            {
                foreach (string file in project.GetBuffer())
                    outputWriter.WriteLine(file);
                project.ClearBuffer();
            }
            outputWriter.Close();
            outputFile.Close();

			SaveHistory(project);
        }

		/// <summary>
		/// Loads all sort projects.
		/// </summary>
        public static SortProject[] Load()
        {
            var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            CreateDataDirectory(appDataFolder);

            var projects = new List<SortProject>();
            var files = Directory
				.GetFiles(Path.Combine(appDataFolder, "imagetool"))
				.Where(x => Path.GetExtension(x) == ".dat");
            foreach (string file in files)
                projects.Add(LoadFile(file));
            return projects.ToArray();
        }

		/// <summary>
		/// Loads a single sort project.
		/// </summary>
        public static SortProject LoadFile(string file)
        {
            var inputFile = File.Open(file, FileMode.Open);
            var inputReader = new StreamReader(inputFile);
            var magic = inputReader.ReadLine();

			// there was a time when sorting projects didn't record the type of project (there was only one type)
			// so check if it's available
			bool hasType = false;
			if (magic == "--project2--")
				hasType = true;
			else if (magic != "--project--")
				throw new InvalidDataException("Invalid project file: " + file);

            var id = inputReader.ReadLine();
            var name = inputReader.ReadLine();
            var directory = inputReader.ReadLine();
			var type = SortProject.ProjectType.Images;
			if (hasType)
				Enum.TryParse(inputReader.ReadLine(), out type);
            var finishedFiles = new HashSet<string>();
            while(!inputReader.EndOfStream)
                finishedFiles.Add(inputReader.ReadLine());
            inputReader.Close();
            inputFile.Close();

            return new SortProject(name, directory, finishedFiles, LoadHistory(id)) { Id = id, Type = type };
        }

		/// <summary>
		/// Delete the sort project.
		/// </summary>
        public static void DeleteProject(SortProject project)
        {
            var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var projectPath = Path.Combine(appDataFolder, "imagetool", project.Id);
            if (File.Exists(projectPath + ".dat"))
				File.Delete(projectPath + ".dat");
			if (File.Exists(projectPath + ".hist"))
				File.Delete(projectPath + ".hist");
        }

		/// <summary>
		/// Creates the data directory (the place the files are saved)
		/// </summary>
        private static void CreateDataDirectory(string appdata)
        {
            var folderPath = Path.Combine(appdata, "imagetool");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
		}

		/// <summary>
		/// Save the history - image history is saved in a seperate file, to make appending to both formats easier.
		/// </summary>
		private static void SaveHistory(SortProject project)
		{
			var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			CreateDataDirectory(appDataFolder);

			var filePath = Path.Combine(appDataFolder, "imagetool", project.Id + ".hist");
			var fileExists = File.Exists(filePath);
			var outputFile = File.Open(
				filePath,
				project.HistoryCount < 0 ? FileMode.Create : FileMode.Append
			);

			var outputWriter = new StreamWriter(outputFile);
			if (!fileExists || project.HistoryCount < 0)
			{
				outputWriter.WriteLine("--history--");
				foreach (string file in project.History)
					outputWriter.WriteLine(file);
			}
			else
			{
				foreach (string file in project.GetHistoryBuffer())
					outputWriter.WriteLine(file);
			}
			project.ClearHistoryBuffer();
			outputWriter.Close();
			outputFile.Close();
		}

		/// <summary>
		/// Load the history.
		/// </summary>
		private static HashSet<string> LoadHistory(string id)
		{
			var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			CreateDataDirectory(appDataFolder);

			var filePath = Path.Combine(appDataFolder, "imagetool", id + ".hist");
			if (!File.Exists(filePath))
				return new HashSet<string>();

			var inputFile = File.Open(filePath, FileMode.Open);
			var inputReader = new StreamReader(inputFile);
			if(inputReader.ReadLine() != "--history--")
				throw new InvalidDataException("Invalid history file: " + id);

			var history = new HashSet<string>();
			while (!inputReader.EndOfStream)
				history.Add(inputReader.ReadLine());
			inputReader.Close();
			inputFile.Close();
			return history;
		}
	}
}
