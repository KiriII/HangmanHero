using System.Collections.Generic;

namespace HangmanHero
{
    public class TextsModel
    {
        private Dictionary<string, string> texts;

        public TextsModel()
        {
            var textJSONReader = new TextJSONReader();

            texts = textJSONReader.GetTexts();
        }

        public string GetTextByKey(string key)
        {
            var text = "";

            texts.TryGetValue(key, out text);

            return text;
        }
    }
}
