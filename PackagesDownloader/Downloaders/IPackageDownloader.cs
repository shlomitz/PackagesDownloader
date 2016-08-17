using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloaders.PackagesDownloader
{
    interface IPackageDownloader
    {
        void DownloadFilesTo(string repoUrl, int top, string parentFolder = @"c:\repository\");
        void DownloadHashTo(string repoUrl, int top, string parentFolder = @"c:\repository\");
    }
}
