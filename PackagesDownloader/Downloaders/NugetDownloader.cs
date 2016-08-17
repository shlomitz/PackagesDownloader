using Downloaders.PackagesDownloader;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace PackagesDownloader.Downloaders
{
    class NugetDownloader : IPackageDownloader
    {
        public void DownloadFilesTo(string repoUrl, int top, string parentFolder = @"c:\repository\")
        {
            parentFolder += @"nuget\";
            if (!Directory.Exists(parentFolder))
                Directory.CreateDirectory(parentFolder);

            string filteredRepoUrl = CreateFilteredRequest(repoUrl, top);
            DownloadFiles(filteredRepoUrl, top, parentFolder);
        }

        private void DownloadFiles(string repoUrl, int top, string parentFolder)
        {
            XDocument xdoc = new XDocument();
            WebClient webReq = new WebClient();

            try
            {
                xdoc = XDocument.Parse(webReq.DownloadString(repoUrl));              
                var entries = from el in xdoc.Root.Descendants()
                              where el.Name.LocalName == "entry"
                              select el;

                foreach (var enrty in entries)
                {
                    var properties = (from el in enrty.Descendants()
                                      where el.Name.LocalName == "content" ||
                                            el.Name.LocalName == "Id" ||
                                            el.Name.LocalName == "Version"
                                      select el).ToList();

                    string id = properties.Where(el => el.Name.LocalName == "Id").First().Value;
                    string version = properties.Where(el => el.Name.LocalName == "Version").First().Value;
                    string filename = $"{parentFolder}{id}.{version}.nupkg";

                    if (!File.Exists(filename))
                    {
                        string source = properties.Where(el => el.Name.LocalName == "content").First().Attribute("src").Value;
                        webReq.DownloadFile(source, filename);
                    }
                }

                if (top == 0 || top > 100)
                {
                    var nextPage = (from el in xdoc.Root.Descendants()
                                       where el.Name.LocalName == "link" &&
                                             el.Attribute("rel") != null &&
                                             el.Attribute("rel").Value == "next"
                                       select el).FirstOrDefault();
                     
                    if(nextPage != null)
                        DownloadFiles(nextPage.Attribute("href").Value, top, parentFolder);
                }
            }
            catch (Exception ex)
            { }
        }

        private string CreateFilteredRequest(string repoUrl, int top)
        {
            //return $"{feedUrlBase}?$filter=IsLatestVersion eq true&$orderby=DownloadCount desc&$top={top}";
            string req = $"{repoUrl}?$filter=IsLatestVersion eq true&$orderby=DownloadCount desc";
            if (top > 0)
                req += $"&$top={top}";

            return req;
        }

        public void DownloadHashTo(string repoUrl, int top, string parentFolder)
        {
            throw new NotImplementedException();
        }
    }
}
