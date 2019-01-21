using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextCompressor.Logic
{
    
    public class TextCompressor
    {
        public string FolderPath { set; get; }
        public string[] Files { set; get; }
        public string[] Names { set; get; }

        public TextCompressor(string[] files, string[] names)
        {
            //Loads the default path for the files to be written
            FolderPath = Path.GetDirectoryName(Application.ExecutablePath);
            Files = files;
            Names = names;
        }

        public void CompressFiles()
        {
            if (!SetUpFolderPath())
                return;

            for (int i = 0; i < Files.Length; i++)
            {
                //Get the bytes of the text in the file
                byte[] body = Encoding.UTF8.GetBytes(File.ReadAllText(Files[i]));

                //Compress the file and get the compressed body
                byte[] compressed = Compression.CompressFile(body);
                if (compressed == null)
                {
                    MessageBox.Show("Something went wrong with compressing that this file: " + Names[i]);
                    return;
                }

                //File ends with .compr
                File.WriteAllBytes(FolderPath + "\\" + Names[i] + ".gz", compressed);

            }
            //Open the folder containing the new files
            System.Diagnostics.Process.Start(FolderPath);
        }

        public void DecompressFiles()
        {
            if(!SetUpFolderPath())
                return;

            for (int i = 0; i < Files.Length; i++)
            {
                //Get the bytes of the text in the file
                byte[] body = File.ReadAllBytes(Files[i]);

                //Compress the file and get the compressed body
                byte[] decompressed = Compression.DecompressFile(body);
                if (decompressed == null)
                {
                    MessageBox.Show("Something went wrong with compressing that this file: " + Names[i]);
                    return;
                }
                Console.WriteLine(Encoding.UTF8.GetString(decompressed));
                //File ends with .compr
                File.WriteAllText(FolderPath + "\\" + Names[i]+".txt", Encoding.UTF8.GetString(decompressed));

            }
            //Open the folder containing the new files
            System.Diagnostics.Process.Start(FolderPath);
        }

        private bool SetUpFolderPath()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Select a folder to place new files.";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                FolderPath = folderBrowserDialog.SelectedPath;
                return true;
            }

            return false; 
        }
    }
}
