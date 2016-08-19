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

        // should start download process
        // async cause download process should update progress bar
        private async void btnDownload_Click(object sender, EventArgs e)
        {
            #region frm behavior

            btnDownload.Enabled = false;
            lblCurrentNo.Text = "0";

            int top = 0;
            switch(cmbxDownloadType.SelectedIndex)
            {
                case 0: 
                    lblTotalNo.Text = "ALL";
                    break;
                case 1:
                case 2:
                    top = decimal.ToInt32(numTopX.Value);
                    lblTotalNo.Text = top.ToString();
                    break;
            }

            #endregion

            IPackageDownloader downloader = new NugetDownloader();
            downloader.SetProgressBarFunc(new Progress<string>(s => lblCurrentNo.Text = s));

            if(rdbDownloadPckgs.Checked)
                await Task.Run(() => downloader.DownloadFilesTo(txtSourceUrl.Text, top, txtDestinationFolder.Text));
            else
                await Task.Run(() => downloader.GenerateHashLog(txtSourceUrl.Text, top, txtDestinationFolder.Text));

            // after download should ...
            btnDownload.Enabled = true;
            _configuration.LastDownloadDate = DateTime.Now;
        }

        #region frm behavior

        private void cmbxDownloadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dpDownloadFDate.Enabled = false;
            if (cmbxDownloadType.SelectedIndex == 2)
                dpDownloadFDate.Enabled = true;
        }

        private void btnFolderDlg_Click(object sender, EventArgs e)
        {
            if (fbDialog.ShowDialog() == DialogResult.OK)
                txtDestinationFolder.Text = fbDialog.SelectedPath;
        }

        #endregion

        #region Configuration

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

        #endregion
    }
}
