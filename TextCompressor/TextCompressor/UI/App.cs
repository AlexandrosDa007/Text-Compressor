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

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of the specified file
                filePath = openFileDialog.FileName;
                //Get the content of the file as a stream
                Stream fileStream = openFileDialog.OpenFile();
                //Create a StreamReader object to read the content of the file
                StreamReader reader = new StreamReader(fileStream);
                //Read the content and update the string
                fileContent = reader.ReadToEnd();
                label2.Text = "File: " + filePath;
            }
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop,false);

            byte[] body = Encoding.UTF8.GetBytes(File.ReadAllText(files[0]));

            byte[] compressed = Compression.CompressFile(body);

            File.WriteAllBytes(folderPath+"\\dafaq",compressed);

            byte[] readd = File.ReadAllBytes(folderPath + "\\dafaq");

            byte[] decompressed = Compression.DecompressFile(readd);

            string newbody = Encoding.UTF8.GetString(decompressed);

            Console.WriteLine(newbody);

        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
