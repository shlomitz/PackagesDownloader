using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Downloaders.PackagesDownloader
{
    interface IPackageDownloader
    {
        void SetProgressBarFunc(IProgress<string> progress);
        void DownloadFilesTo(string repoUrl, int top, string parentFolder = @"c:\repository\");
        void DownloadHashTo(string repoUrl, int top, string parentFolder = @"c:\repository\");
    }
}
