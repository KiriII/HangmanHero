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

            if (texts.Count == 0)
            {
                throw new System.Exception("Ошибка при чтении текстов. Текстов совсем нет");
            }
        }

        // getters
        public string GetTextByKey(string key)
        {
            var text = "";

            texts.TryGetValue(key, out text);

            return text;
        }
    }
}
