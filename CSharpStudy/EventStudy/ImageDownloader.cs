using System.Net;
using System.Text.RegularExpressions;

namespace EventStudy


{
    public class ImageDownloader
    {
        public event Action<string>? DownloadStarted;
        public event Action<string>? DownloadFinished;

        private static readonly Regex _imageRegex = new Regex("<img[^>]+src=\"(.*?)\"", RegexOptions.IgnoreCase);

        public async Task DownloadImagesAsync(string remoteUrl, string fileName,
            CancellationToken cancellationToken = default)
        {
            using (var client = new WebClient())
            {
                DownloadStarted?.Invoke(fileName);
                await client.DownloadFileTaskAsync(remoteUrl, fileName);
                DownloadFinished?.Invoke(fileName);
            }
        }
        
        public async Task<IEnumerable<string>> GetImageUrlsAsync(string url, int count,
            CancellationToken cancellationToken = default)
        {
            var imageUrls = new List<string>();

            using (var client = new HttpClient())
            {
                string html = await client.GetStringAsync(url);

                MatchCollection matches = _imageRegex.Matches(html);

                foreach (Match match in matches)
                {
                    string src = match.Groups[1].Value;

                    if (src.EndsWith(".jpg"))
                        imageUrls.Add(src);

                    if (imageUrls.Count >= count)
                        break;
                }
            }
            return imageUrls;
        }
    }
}
