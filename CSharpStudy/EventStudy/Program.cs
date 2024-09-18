namespace EventStudy


{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var downloader = new ImageDownloader();

            downloader.DownloadStarted += (fileName) =>
                Console.WriteLine($"Скачивание {Path.GetFileName(fileName)} началось...");
            downloader.DownloadFinished += (fileName) =>
                Console.WriteLine($"Скачивание {Path.GetFileName(fileName)} завершено.");

            string remoteUrl = "https://webneel.com/beautiful-clouds-photos-formation";

            string saveDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Downloaded images");

            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }

            List<string> imageUrls = await downloader.GetImageUrlsAsync(remoteUrl);

            var selectedImages = imageUrls.Take(10).ToList();
            var downloadTasks = new List<Task>();
            var fileNames = new List<string>();

            for (int i = 0; i < selectedImages.Count; i++)
            {
                string imageUrl = selectedImages[i];
                string localFleName = Path.Combine(saveDirectory, $"image_{(i + 1):D2}.jpg");

                try
                {
                    var task = downloader.DownloadImagesAsync(imageUrl, localFleName);
                    downloadTasks.Add(task);
                    fileNames.Add(localFleName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при скачивании {localFleName}: {ex.Message}");
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
