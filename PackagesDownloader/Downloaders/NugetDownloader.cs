using Downloaders.PackagesDownloader;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PackagesDownloader.Downloaders
{
    // implementation of NugetDownloader
    class NugetDownloader : IPackageDownloader, IDisposable
    {
        int _currentCount = 0;
        IProgress<string> _progress = null;
        string _downloadedPackagesLog = String.Empty;

        #region IPackageDownloader Api

        // download Nuget repository
        // repurl - url of repository api
        // top - how many items to download (0 - all)
        // parentFolder - destination
        public void DownloadFilesTo(string repoUrl, int top, string parentFolder = @"c:\repository")
        {            
            DownloadFilesTo(repoUrl, top, parentFolder, false);
        }

        public void GenerateHashLog(string repoUrl, int top, string parentFolder = @"c:\repository")
        {            
            DownloadFilesTo(repoUrl, top, parentFolder, true);
        }

        public void SetProgressBarFunc(IProgress<string> progress)
        {
            _progress = progress;
        }

        #endregion

        #region private methods

        private void DownloadFilesTo(string repoUrl, int top, string parentFolder, bool isHash)
        {
            parentFolder = DownloadPrerequisites(parentFolder, isHash);
            LogDownloadFile($@"{{""files"":[");

            string filteredRepoUrl = CreateFilteredRequest(repoUrl, top);
            DownloadFiles(filteredRepoUrl, top, parentFolder, isHash);

            LogDownloadFile($@"],""general_data"":{{""url"":""{repoUrl}"", ""download_time"":""{DateTime.Now.ToShortDateString()}""}}}}");
        }

        private string DownloadPrerequisites(string parentFolder, bool isHash)
        {
            _currentCount = 0;
            parentFolder += @"\nuget\";
            if (!Directory.Exists(parentFolder))
                Directory.CreateDirectory(parentFolder);

            if(isHash)
                _downloadedPackagesLog = $"{parentFolder}\\DownloadedPackagesHashLog_{DateTime.Now.Millisecond}.json";
            else
                _downloadedPackagesLog = $"{parentFolder}\\DownloadedPackagesLog_{DateTime.Now.Millisecond}.json";

            return parentFolder;
        }

        private void DownloadFiles(string repoUrl, int top, string parentFolder, bool isHash)
        {
            XDocument xdoc = null;
            
            try
            {
                using (WebClient webReq = new WebClient())
                {
                    string delimiter = String.Empty;
                    xdoc = XDocument.Parse(webReq.DownloadString(repoUrl));
                    var entries = from el in xdoc.Root.Descendants()
                                  where el.Name.LocalName == "entry"
                                  select el;

                    foreach (var enrty in entries)
                    {
                        var properties = (from el in enrty.Descendants()
                                          where el.Name.LocalName == "content" ||
                                                el.Name.LocalName == "Id" ||
                                                el.Name.LocalName == "Version" ||
                                                el.Name.LocalName == "PackageHash" ||
                                                el.Name.LocalName == "PackageHashAlgorithm"
                                          select el).ToList();

                        string id = properties.Where(el => el.Name.LocalName == "Id").First().Value;
                        string version = properties.Where(el => el.Name.LocalName == "Version").First().Value;

                        if (!isHash)
                        {
                            string filename = $"{parentFolder}{id}.{version}.nupkg";

                            // for performance - don't override exist files
                            if (!File.Exists(filename))
                            {
                                string source = properties.Where(el => el.Name.LocalName == "content").First().Attribute("src").Value;
                                webReq.DownloadFile(source, filename);
                                LogDownloadFile($@"{delimiter}{{""name"": ""{id}.nupkg"", ""extra_data"":{{}}}}");
                            }
                        }
                        else
                        {
                            string PackageHash = properties.Where(el => el.Name.LocalName == "PackageHash").First().Value;
                            string PackageHashAlgorithm = properties.Where(el => el.Name.LocalName == "PackageHashAlgorithm").First().Value;
                            LogDownloadFile($@"{delimiter}{{""name"": ""{id}.nupkg"", ""extra_data"":{{""hash"":""{PackageHash}"",""hash_algorithm"":""{PackageHashAlgorithm}"", ""id"":""{id}"",""version"":""{version}""}}}}");
                        }

                        if (_currentCount == 0)
                            delimiter = ",";

                        _currentCount++;
                        _progress.Report(_currentCount.ToString());
                    }

                    // if more than 1 page then get the next page url and download it too
                    if (top == 0 || top > 100)
                    {
                        var nextPage = (from el in xdoc.Root.Descendants()
                                        where el.Name.LocalName == "link" &&
                                              el.Attribute("rel") != null &&
                                              el.Attribute("rel").Value == "next"
                                        select el).FirstOrDefault();

                        if (nextPage != null)
                            DownloadFiles(nextPage.Attribute("href").Value, top, parentFolder, isHash);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error !!!");
            }
            finally
            {
                xdoc = null;
            }
        }

        // generate filtered request
        // get top X order by Download count
        private string CreateFilteredRequest(string repoUrl, int top)
        {
            string req = $"{repoUrl}?$filter=IsLatestVersion eq true&$orderby=DownloadCount desc";
            if (top > 0)
                req += $"&$top={top}";

            return req;
        }

        #endregion

        private void LogDownloadFile(string line)
        {
            File.AppendAllText(_downloadedPackagesLog, line);
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _currentCount = 0;
                    _progress = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~NugetDownloader() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}
