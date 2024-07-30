using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace _07_file_system
{
    internal class Program
    {
        // -------------------- DriveInfo - working with system drive
        // -------------------- DirectoryInfo / Directory - working with directory
        // -------------------- FileInfo / File - working with file

        // get system directories
        static string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        static string dirName = "test_folder";
        static string fileName = "my_file.txt";

        static string filePath = Path.Combine(desktopPath, fileName);

        private static void Main(string[] args)
        {
            //Drives();
            //Directories();
            //Files();
            //Streams(); 
        }

        private static void Drives()
        {
            // var - auto-detect type

            var drives = DriveInfo.GetDrives();

            foreach (var d in drives)
            {
                if (d.IsReady)
                    Console.WriteLine($"Drive {d.VolumeLabel}: {d.Name} {d.DriveFormat}, size: {d.TotalFreeSpace / 1024.0 / 1024 / 1024}");
                else
                    Console.WriteLine($"Drive {d.Name} is not ready for use!");
            }
        }
        private static void Directories()
        {
            // ------------------ working with directories

            // Path - working with file system paths
            // GetExnetsion(), Combine(), GetFileName()
            string dirFullPath = Path.Combine(desktopPath, dirName);

            // @ - avoid escape sequences
            if (!Directory.Exists(dirFullPath))
            {
                Directory.CreateDirectory(dirFullPath); // add separator depends on OS
            }

            DirectoryInfo dir = new(dirFullPath);

            Console.WriteLine($"New Directory Info: {dir.Name} created at {dir.CreationTime}\n" +
                $"Last access: {dir.LastAccessTime} | Last write time: {dir.LastWriteTime}\n");

            // --------- get directories and files
            var desktop = new DirectoryInfo(desktopPath);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--------------- Desktop Directories ---------------");
            foreach (DirectoryInfo d in desktop.GetDirectories())
            {
                Console.WriteLine(d.Name); // FullName
            }

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("--------------- Desktop Files ---------------");
            foreach (FileInfo d in desktop.GetFiles())
            {
                Console.WriteLine("\t" + d.Name);
            }
            Console.ResetColor();

            // --------- search files
            /* pattern symbols:
                [*] - any characters sequence
                [?] - any single character

                example: fake.txt foo.txf f.txt 
            */
            foreach (var f in dir.GetFiles("f*.tx?", System.IO.SearchOption.AllDirectories))
            {
                Console.WriteLine($"File: {f.Name} | {f.Length / 1024.0:f2} KB");
            }

            //dir.MoveTo("...");

            //dir.Delete();       // delete if directory is empty
            //dir.Delete(true);   // delete directory with all content

            FileSystem.DeleteDirectory(dirFullPath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
        }
        private static void Files()
        {
            // ------------------ working with files

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            // write content
            File.WriteAllText(filePath, "Hello from C#!!!\n");
            File.AppendAllText(filePath, "We are here again...");

            // File.WriteAllBytes()

            // read content
            string content = File.ReadAllText(filePath);
            Console.WriteLine($"Content: {new string(content.Take(15).ToArray())}...");

            var file = new FileInfo(filePath);
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(desktopPath, dirName));

            //file.MoveTo("...");
            //file.CopyTo(Path.Combine(dir.FullName, fileName), true); // overrite existing file

            //file.Delete();

            // rename file - move file to the same directory but with different name
            //file.MoveTo(Path.Combine(desktopPath, "new_name.txt"));

            //file.Encrypt();
            //file.Decrypt();

            // file attributes (hidden, offline, compresed, system ...etc)
            file.Attributes = FileAttributes.Offline | FileAttributes.Hidden;

            // ------------------- Ukrainian text
            Console.OutputEncoding = Encoding.UTF8;

            var text = File.ReadAllText(Path.Combine(desktopPath, "Привіт.txt"));
            Console.WriteLine(text);
        }
        private static void Streams()
        {
            // ------------------ working with File Streams
            FileStream fs = new(filePath, FileMode.Truncate);

            // fs.Write() - write bytes to the file
            // fs.Read()  - read bytes from the file

            string text = "Program text!";

            fs.Write(Encoding.UTF8.GetBytes(text));
            fs.Close(); // close file

            // --------- text streams: StreamReader, StreamWriter

            //StreamWriter writer = new(fs);
            //StreamWriter writer = new(filePath);

            using (StreamWriter writer = File.CreateText(filePath))
            {
                writer.WriteLine(text);
                writer.Write("Additional line. Last word in the file.");

            } // auto clear resources here: try {...} finally { Dispose() }

            using (StreamReader reader = File.OpenText(filePath))
            {
                string all = reader.ReadToEnd();
                Console.WriteLine($"All text: {all}");
            }
        }
    }
}