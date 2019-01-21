using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextCompressor
{
    public partial class StartPage : Form
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void compressButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            App application = new App(0);
            application.Text = "Compression tool";
            application.ShowDialog();
            
            this.Show();
        }

        private void decompressButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            App application = new App(1);
            application.Text = "Decompression tool";
            application.ShowDialog();
            
            this.Show();
        }
    }
}
