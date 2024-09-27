using GameDataParser.Model;

namespace GameDataParser.UserInteraction
{
    public interface IFileDataPrinter
    {
        void Print(List<Game> fileData);
    }

}
