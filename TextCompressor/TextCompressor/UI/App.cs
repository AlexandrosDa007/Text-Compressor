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
        private int mode;
        private Logic.TextCompressor compressor;

        public App(int mode)
        {
            InitializeComponent();
            this.mode = mode;

            toolTip1.SetToolTip(browseButton, "Browse for files or drag'n drop them");
            if (mode == 0)
                toolTip1.SetToolTip(panel1, "Drop files here to compress");
            else
                toolTip1.SetToolTip(panel1, "Drop files here to decompress");
            compressor = new Logic.TextCompressor(null,null);
            
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
                //Get the names of the files
                string[] files = openFileDialog.FileNames;
                string[] fileNames = new string[files.Length];
                for (int i = 0; i < files.Length; i++)
                {
                    fileNames[i] = Path.GetFileNameWithoutExtension(files[i]);
                }
                compressor.Files = files;
                compressor.Names = fileNames;
                if (mode == 0)
                    compressor.CompressFiles();
                else
                    compressor.DecompressFiles();

                panel1.BackColor = SystemColors.Control;
            }
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {

            //Get a list of paths from the  files that have been dropped 
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            //Get the names of the files
            string[] fileNames = new string[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                fileNames[i] = Path.GetFileNameWithoutExtension(files[i]);
            }
            compressor.Files = files;
            compressor.Names = fileNames;
            if (mode == 0)
                compressor.CompressFiles();
            else
                compressor.DecompressFiles();

            panel1.BackColor = SystemColors.Control;

        }

        

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

    }
}
