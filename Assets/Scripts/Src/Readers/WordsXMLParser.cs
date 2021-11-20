using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

namespace HangmanHero
{
    public class WordsXMLParser
    {
        public ArrayList GetAllKnownWords()
        {
            var allKnownWords = new ArrayList();

            ParseFromXML(ref allKnownWords);

            return allKnownWords;
        }

        private void ParseFromXML(ref ArrayList words)
        {
            XmlDocument xDoc = new XmlDocument();

            var textAssetXML = Resources.Load<TextAsset>(Constants.wordsXMLpath);
            xDoc.LoadXml(textAssetXML.text);

            //string levelFolder = AssetsFolderPath + "/Resources/Levels";
            XmlElement xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    words.Add(xnode.InnerText.ToUpper());
                }
            }
        }
    }
}
