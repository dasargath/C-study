namespace EventStudy


{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var downloader = new ImageDownloader();

            downloader.DownloadStarted += (fileName) => Console.WriteLine($"Скачивание {fileName} началось...");
            downloader.DownloadFinished += (fileName) => Console.WriteLine($"Скачивание {fileName} завершено.");

            string remoteUri = "https://webneel.com/beautiful-clouds-photos-formation";
			CancellationTokenSource cts = new CancellationTokenSource();

            string saveDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Downloaded images");

            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }

            IEnumerable<string> imageUrls = await downloader.GetImageUrlsAsync(remoteUri, 10, cts.Token);

            var downloadTasks = new List<Task>();
            var fileNames = new List<string>();

            int index = 1;
            foreach (var imageUrl in imageUrls)
            {
	            string fileName = $"image_{index++}.jpg";
                string fullFilePath = Path.Combine(saveDirectory, fileName);
                
                fileNames.Add(fullFilePath);

	            try
	            {
		            var downloadTask = downloader.DownloadImagesAsync(imageUrl, fullFilePath, cts.Token);
		            downloadTasks.Add(downloadTask);
	            }
	            catch (Exception ex)
	            {
		            Console.WriteLine($"Ошибка при скачивании {fileName}: {ex.Message}");
	            }
            }


            await Task.WhenAll(downloadTasks);
            Console.WriteLine("Все загрузки завершены.");


            Console.WriteLine("Нажмите клавишу A для выхода или любую другую клавишу для проверки статуса скачивания");
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.A)
                {
                    break;
                }
                else
                {
                    for (int i = 0; i < downloadTasks.Count; i++)
                    {
                        Console.WriteLine(
                            $"Загрузка {Path.GetFileName(fileNames[i])} завершена: {downloadTasks[i].IsCompleted}");
                    }
                }
            }
        }
    }
}
