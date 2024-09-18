namespace EventStudy


{
    public class ImageDownloader
    {
        public event Action<string>? DownloadStarted;
        public event Action<string>? DownloadFinished;

        public async Task DownloadImagesAsync(string remoteUrl, string fileName)
        {
            var client = new System.Net.WebClient();

            DownloadStarted?.Invoke(fileName);
            await client.DownloadFileTaskAsync(remoteUrl, fileName);
            DownloadFinished?.Invoke(fileName);

        }


        public async Task<List<string>> GetImageUrlsAsync(string url)
        {
            var imageUrls = new List<string>();

            var client = new System.Net.Http.HttpClient();
            string html = await client.GetStringAsync(url);

            var regex = new System.Text.RegularExpressions.Regex("<img[^>]+src=\"(.*?)\"",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            var matches = regex.Matches(html);

            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                string src = match.Groups[1].Value;

                if (!src.StartsWith("http") && !src.StartsWith("https"))
                    src = new Uri(new Uri(url), src).ToString();

                if (src.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase))
                    imageUrls.Add(src);
            }

            return imageUrls;
        }
    }
}
    