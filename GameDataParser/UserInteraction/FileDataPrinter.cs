using GameDataParser.Model;

namespace GameDataParser.UserInteraction
{
    public class FileDataPrinter : IFileDataPrinter
    {
        private readonly IUserInteraction _userInteraction;

        public FileDataPrinter(IUserInteraction userInteraction)
        {
            _userInteraction = userInteraction;
        }

        public void Print(List<Game> fileData)
        {
            _userInteraction.ShowMessage("\nLoaded games are:");
            foreach (var item in fileData)
            {
                _userInteraction.ShowMessage(item.ToString());
            }
        }
    }

}
