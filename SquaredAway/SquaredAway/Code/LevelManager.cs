using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;


namespace SquaredAway.Code
{
    static class LevelManager
    {
        static public Level[] Levels;

        static public Level GetLevelFromName(string name)
        {
            foreach(Level l in Levels)
            {
                if(l.Name == name)
                {
                    return l;
                }
            }

            return null;
        }
        static public int LastLevelPlayed { get; set; }
        static public void Initilize(string saveFile)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), saveFile);
            var xml = new XmlDocument();
            xml.Load(path);

            int numberOfLevels = Int32.Parse(xml.DocumentElement.Attributes["Count"].Value);

            Levels = new Level[numberOfLevels];

            LastLevelPlayed = Int32.Parse(xml.DocumentElement.Attributes["LastLevelPlayed"].Value);

            int levelCount = 0;
            foreach(XmlNode levelData in xml.DocumentElement.SelectSingleNode("Levels").ChildNodes)
            {
                string name = levelData.Attributes["Name"].Value;

                int size = Int32.Parse(levelData.Attributes["Size"].Value);
                string tiles = levelData.InnerText;
                tiles = Regex.Replace(tiles, @"\s+", "");
                int[,] tileArr = new int[size, size];

                for(int i = 0; i < size; i++)
                {
                    for(int j = 0; j < size; j++)
                    {
                        tileArr[i, j] = (int)Char.GetNumericValue(tiles[i*size + j]);
                    }
                }

                Levels[levelCount] = new Level(name, size, tileArr);
                levelCount++;
            }
           
        }

    }
}
