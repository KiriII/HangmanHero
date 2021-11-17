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
            xDoc.Load(Constants.wordsXMLpath);
            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    words.Add(xnode.InnerText);
                }
            }
        }
    }
}
