using Downloaders.PackagesDownloader;
using Newtonsoft.Json;
using PackagesDownloader.Data;
using PackagesDownloader.Downloaders;
using System;
using System.IO;
using System.Threading.Tasks;
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

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            btnDownload.Enabled = false;

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

            lblCurrentNo.Text = "0";

            IPackageDownloader downloader = new NugetDownloader();
            downloader.SetProgressBarFunc(new Progress<string>(s => lblCurrentNo.Text = s));
            await Task.Run(() => downloader.DownloadFilesTo(txtSourceUrl.Text, top, txtDestinationFolder.Text));

            btnDownload.Enabled = true;
            _configuration.LastDownloadDate = DateTime.Now;            
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

        private void btnFolderDlg_Click(object sender, EventArgs e)
        {
            if(fbDialog.ShowDialog() == DialogResult.OK)
                txtDestinationFolder.Text = fbDialog.SelectedPath;
        }
    }
}
