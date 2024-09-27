using GameDataParser.DataAccess;
using GameDataParser.UserInteraction;

namespace GameDataParser.Application
{
    class AppGameDataParser
    {
        private readonly IUserInteraction _userInteraction;
        private readonly IFileReader _localFileReader;
        private readonly IFileContentDeserializer _fileContentDeserializer;
        private readonly IFileDataPrinter _fileDataPrinter;

        public AppGameDataParser(IUserInteraction userInteraction, IFileReader localFileReader, IFileContentDeserializer fileContentDeserializer, IFileDataPrinter fileDataPrinter)
        {
            _userInteraction = userInteraction;
            _localFileReader = localFileReader;
            _fileContentDeserializer = fileContentDeserializer;
            _fileDataPrinter = fileDataPrinter;
        }

        public void AppRun()
        {
            var fileName = _userInteraction.PromptToEnterFileName();
            var fileData = _localFileReader.ReadFile(fileName);
            var deserializedData = _fileContentDeserializer.DeserializeFrom(fileName, fileData); // exception catcher
            _fileDataPrinter.Print(deserializedData);
        }
    }

}
