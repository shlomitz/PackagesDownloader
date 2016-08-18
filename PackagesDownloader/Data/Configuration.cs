using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackagesDownloader.Data
{
    class Configuration
    {
        public string PackageName { get; set; }
        public DateTime LastDownloadDate { get; set; }
        public string SourceUrl{ get; set; }
        public string DestinationFolder { get; set; }
    }
}
