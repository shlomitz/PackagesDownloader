using Downloaders.PackagesDownloader;
using Newtonsoft.Json;
using PackagesDownloader.Data;
using PackagesDownloader.Downloaders;
using System;
using System.IO;
using System.Windows.Forms;

namespace PackagesDownloader
{
    public partial class frmPckgsDownloader : Form
    {
        string _configurationFile;
        Configuration _configuration = null;

        public frmPckgsDownloader()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            int top = 0;

            switch(cmbxDownloadType.SelectedIndex)
            {
                case 0: 
                    lblTotalNo.Text = "60000";
                    break;
                case 1:
                case 2:
                    top = decimal.ToInt32(numTopX.Value);
                    lblTotalNo.Text = top.ToString();
                    break;
            }

            IPackageDownloader downloader = new NugetDownloader();
            downloader.SetProgressBarItem(lblCurrentNo);
            downloader.DownloadFilesTo("https://www.nuget.org/api/v2/Packages()", top);
        }

        private void cmbxDownloadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dpDownloadFDate.Enabled = false;
            if (cmbxDownloadType.SelectedIndex == 2)
                dpDownloadFDate.Enabled = true;
        }

        private void LoadConfigurationData()
        {
            _configuration = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(_configurationFile));
            dpDownloadFDate.Value = _configuration.LastDownloadDate;
            txtSourceUrl.Text = _configuration.SourceUrl;
            txtDestinationFolder.Text = _configuration.DestinationFolder;

            cmbxDownloadType.SelectedIndex = 1;
        }

        private void SaveConfigurationDataToFile()
        {
            if(_configuration != null)
                File.WriteAllText(_configurationFile, JsonConvert.SerializeObject(_configuration));
        }

        private void frmPckgsDownloader_Load(object sender, EventArgs e)
        {
            _configurationFile = $"{Environment.CurrentDirectory}\\PackagesDownloaderConfig.json";
            if (!File.Exists(_configurationFile))
            {
                MessageBox.Show("App DownloadPackages configuration file is missing", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            else
                LoadConfigurationData();  
        }

        private void frmPckgsDownloader_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfigurationDataToFile();
        }
    }
}
