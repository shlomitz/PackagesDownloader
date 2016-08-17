using Downloaders.PackagesDownloader;
using PackagesDownloader.Downloaders;
using System;
using System.Windows.Forms;

namespace PackagesDownloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            IPackageDownloader downloader = new NugetDownloader();
            downloader.DownloadFilesTo("https://www.nuget.org/api/v2/Packages()", 1);
        }
    }
}
