using System.Text.Json;
using GameDataParser.Model;
using GameDataParser.UserInteraction;

namespace GameDataParser.DataAccess
{
    public class FileContentDeserializer : IFileContentDeserializer
    {
        private readonly IUserInteraction _userInteraction;

        public FileContentDeserializer(IUserInteraction userInteraction)
        {
            _userInteraction = userInteraction;
        }

        public List<Game> DeserializeFrom(string fileName, string fileData)
        {
            if (fileData.Count() > 0)
            {
                try
                {
                    return JsonSerializer.Deserialize<List<Game>>(fileData);
                }
                catch (JsonException ex)
                {
                    _userInteraction.ShowErrorMessage($"\nJSON in the {fileName} was not in a valid format. JSON body:\n{fileData}");
                    throw new JsonException($"{ex.Message} The file is: {fileName}", ex);
                }
            }
            else
            {
                _userInteraction.ShowMessage("\nNo data are present in the input file.\n");
                return new List<Game>();
            }
        }
    }

}
