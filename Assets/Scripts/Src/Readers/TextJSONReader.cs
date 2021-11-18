using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace HangmanHero
{
    public class TextJSONReader
    {

        private Dictionary<string, string> texts;

        public TextJSONReader()
        {
            texts = new Dictionary<string, string>();

            var filePath = Application.dataPath + Constants.textUIruPath;

            parseKeysAndKeys(File.ReadAllText(filePath));
        }

        // it's better parser i've ever seen. Belive me
        private void parseKeysAndKeys(string jsonToString) 
        {
            var splitedJson = jsonToString.Split('\"');

            for (int i = 1; i < splitedJson.Length - 3; i += 4)
            {
                texts.Add(splitedJson[i], splitedJson[i+2]);
            }
        }

        public Dictionary<string, string> GetTexts()
        {
            return texts;
        }
    }
}
