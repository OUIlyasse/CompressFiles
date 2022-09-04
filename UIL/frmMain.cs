using iTools;
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

namespace UIL
{
    public partial class frmMain : Form
    {
        private Archive r = new Archive();
        private bool yesDo = false;
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnCompress_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog b = new FolderBrowserDialog();
            string path = string.Empty;
            if (b.ShowDialog() == DialogResult.OK)
            {
                path = b.SelectedPath;
            }
            DirectoryInfo Dinfo = new DirectoryInfo(path);
            foreach (FileInfo item in Dinfo.GetFiles())
            {
                if (yesDo)
                {
                    r.Compress(item);
                    File.Delete(item.FullName);
                }
                else
                {
                    r.Compress(item);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                yesDo = true;
                return;
            }
            yesDo = false;
        }

        private void vtnExtract_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog b = new FolderBrowserDialog();
            string path = string.Empty;
            if (b.ShowDialog() == DialogResult.OK)
            {
                path = b.SelectedPath;
            }
            DirectoryInfo Dinfo = new DirectoryInfo(path);
            foreach (FileInfo item in Dinfo.GetFiles())
            {
                r.Decompress(item);
                //File.Delete(item.FullName);
            }
        }
    }
}