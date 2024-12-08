namespace PhotoFiles
{
    using System;
    using System.IO;
    using Microsoft.VisualBasic.FileIO;

    class Program
        // TODO - uložit extentions do separatniho souboru a pokud neexistuje soubor tak s eprogram zepta uzivatele, ktery chce
    {   public static void RemoveFiles(List<string> files)
        {
            foreach (var file in files)
            {
                FileSystem.DeleteFile(file, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                Console.WriteLine($"Moved to Recycle Bin: {file}");
            }
        }
        public static void Renumber()
        {
            //todo
        }
        public static void MoveProcessed()
        {
            //move processed files with jpg extentions into the edited folder on my computer with today's (yyyy_mm_dd_export) folder
        }
        public static Queue<string> EnqueueDirectories(string rootDirectory, Queue<string> directoriesToProcess) //reccursive bcs I hate myself :)
        {
            directoriesToProcess.Enqueue(rootDirectory);
            string[] directories = Directory.GetDirectories(rootDirectory);

            foreach (var directory in directories)
            {
                EnqueueDirectories(directory, directoriesToProcess);
            }

            return directoriesToProcess;
        }
        public static (string, List<string>) InitialiseSaved(string settingsFileLocation)
        {
            //first line is directory path, second line is fileExtentionsToRemove, thir
            StreamReader reader = new StreamReader(settingsFileLocation);










            return (null, null);
        }
        public static List<string> GetFilesForProcessing(string rootDirectory, List<string> fileExtensions)
        {
            List<string> filesForProcessing = new List<string>();
            try
            {
                
                Queue<string> directoriesToProcess = new Queue<string>();
                directoriesToProcess = EnqueueDirectories(rootDirectory, directoriesToProcess);

                foreach (var directoryToProcess in directoriesToProcess)
                {
                    string[] files = Directory.GetFiles(directoryToProcess);

                    foreach (string file in files)
                    {
                        foreach (var fileExtension in fileExtensions)
                        {
                            if (file.EndsWith(fileExtension, StringComparison.OrdinalIgnoreCase))
                            {
                                filesForProcessing.Add(file);
                            }
                        }
                    }
                }
                // get all files with the specified extension in the directory


                Console.WriteLine("All files with the extension have been moved to the Recycle Bin.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return filesForProcessing;
        }
        static void Main()
        {
            string settingsFileLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "PhotoFilesSettings.txt"); //path for settings file 
            string directoryPath = @"C:\Users\tobia\Desktop\tst";
            List<string> fileExtensionsRemove = new List<string> {".dng", ".tiff", ".tif" };
            List<string> filesForProcessing;
            //(directoryPath, fileExtensionsRemove) = InitialiseSaved(settingsFileLocation);

            filesForProcessing = GetFilesForProcessing(directoryPath, fileExtensionsRemove);
            RemoveFiles(filesForProcessing);

            Console.ReadKey();
        }
    }
}
