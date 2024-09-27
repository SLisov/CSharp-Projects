using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CustomCache
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDataDownloader dataDownloader = new CachingDataDownloader(new PrintingDataDownloader(new SlowDataDownloader()));

            Console.WriteLine(dataDownloader.DownloadData("id1"));
            Console.WriteLine(dataDownloader.DownloadData("id2"));
            Console.WriteLine(dataDownloader.DownloadData("id3"));
            Console.WriteLine(dataDownloader.DownloadData("id1"));
            Console.WriteLine(dataDownloader.DownloadData("id3"));
            Console.WriteLine(dataDownloader.DownloadData("id1"));
            Console.WriteLine(dataDownloader.DownloadData("id2"));
            Console.WriteLine("Finish!");

            Console.ReadKey();
        }
    }

    public class CustomChache<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> _cachedData = new();

        public TValue GetCached(TKey idOfData,Func<TKey,TValue> getCacheForFirstTime)
        {
            if (!_cachedData.ContainsKey(idOfData))
            {
                _cachedData[idOfData] = getCacheForFirstTime(idOfData);
            }
            return _cachedData[idOfData];
        }

    }

    // Decorator Design Pattern. we added extension to our method and class (SlowDataDownloader ) without modifying its code.
    // We made it possible through reaching the class and its method through interface IDataDownloader and its instence
    // CachingDataDownloader class is our main wrapper

    public class CachingDataDownloader : IDataDownloader
    {
        private readonly IDataDownloader _dataDownloader;

        private readonly CustomChache<string, string> _customCache = new();

        public CachingDataDownloader(IDataDownloader dataDownloader)
        {
            _dataDownloader = dataDownloader;
        }

        // Use this method extension if caching

        public string DownloadData(string resourceId)
        {
            return _customCache.GetCached(resourceId,_dataDownloader.DownloadData);
        }
    }

    // Adding another Decorator using the same design pattern and implementation through interface class (IDataDownloader) of our main object 

    public class PrintingDataDownloader : IDataDownloader
    {
        private readonly IDataDownloader _dataDownloader;

        public PrintingDataDownloader(IDataDownloader dataDownloader)
        {
            _dataDownloader = dataDownloader;
        }

        // Use this method extension if caching

        public string DownloadData(string resourceId)
        {
            var data = _dataDownloader.DownloadData(resourceId);
            Console.WriteLine("Data is ready");
            return data;
        }
    }

    public interface IDataDownloader
    {
        string DownloadData(string resourceId);
    }
    
    public class SlowDataDownloader : IDataDownloader
    {
        public string DownloadData(string resourceId)
        {
            //let's imagine this method downloads real data,
            //and it does it slowly
            Thread.Sleep(1000);
            return $"Some data for {resourceId}";
        }
    }

    //The Solution below breakes Open-Closed Principle and we changed it with another solution
    #region oldSolutionForCaching
    //public class SlowDataDownloader: IDataDownloader
    //{
    //    CustomChache<string, string> _customChache = new();

    //    public string DownloadData(string resourceId)
    //    {
    //        return _customChache.GetCached(resourceId, DownloadDataWithOutCaching);
    //    }
    //    public string DownloadDataWithOutCaching(string resourceId)
    //    {
    //        //let's imagine this method downloads real data,
    //        //and it does it slowly
    //        Thread.Sleep(1000);
    //        return $"Some data for {resourceId}";
    //    }
    //}
    #endregion
}
