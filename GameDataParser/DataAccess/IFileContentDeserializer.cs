using GameDataParser.Model;

namespace GameDataParser.DataAccess
{
    public interface IFileContentDeserializer
    {
        List<Game> DeserializeFrom(string fileName, string fileData);
    }

}
