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
using TextCompressor.Logic;

namespace TextCompressor
{
    public partial class App : Form
    {
        private string folderPath;

        public App()
        {
            InitializeComponent();
            folderPath = Path.GetDirectoryName(Application.ExecutablePath);
        }

        private void panel1_DragOver(object sender, DragEventArgs e)
        {
            panel1.BackColor = Color.Aqua;
        }

        private void panel1_DragLeave(object sender, EventArgs e)
        {
            panel1.BackColor = SystemColors.Control;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileContent = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = true;

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SetUpFolderPath();
                //Get the names of the files
                string[] files = openFileDialog.FileNames;
                string[] fileNames = new string[files.Length];
                for (int i = 0; i < files.Length; i++)
                {
                    fileNames[i] = Path.GetFileNameWithoutExtension(files[i]);
                }

                WriteToFiles(files, fileNames);

                System.Diagnostics.Process.Start(folderPath);
            }
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            SetUpFolderPath();

            //Get a list of paths from the  files that have been dropped 
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            //Get the names of the files
            string[] fileNames = new string[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                fileNames[i] = Path.GetFileNameWithoutExtension(files[i]);
            }

            WriteToFiles(files, fileNames);

            //Open the folder containing the new files
            System.Diagnostics.Process.Start(folderPath);

        }

        

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }


        private void WriteToFiles(string[] files, string[] fileNames)
        {
            for (int i = 0; i < files.Length; i++)
            {
                //Get the bytes of the text in the file
                byte[] body = Encoding.UTF8.GetBytes(File.ReadAllText(files[i]));

                //Compress the file and get the compressed body
                byte[] compressed = Compression.CompressFile(body);
                if(compressed == null)
                {
                    MessageBox.Show("Something went wrong with compressing that this file: " + fileNames[i]);
                    return;
                }

                //File ends with .compr
                File.WriteAllBytes(folderPath + "\\" + fileNames[i] + ".compr", compressed);

            }

            panel1.BackColor = SystemColors.Control;
        }
        
        private void SetUpFolderPath()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Select a folder to place new files.";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog.SelectedPath;
            }
        }

    }
}
