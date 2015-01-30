using MovieSimulator.Common.BoardGame;
using MovieSimulator.Common.BoardGame.Characters;
using MovieSimulator.Common.BoardGame.Factory;
using MovieSimulator.Common.BoardGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace MovieSimulator.Common
{
    public class GamingEnvironment
    {
        private static GamingEnvironment _instance;
        public static GamingEnvironment Instance 
        { 
            get
            {
                if (_instance == null)
                    _instance = new GamingEnvironment();

                return _instance;
            }
        }

        public BoardGameAbstract boardGame { get; set; }

        public GamingEnvironment()
        {
            _instance = this;
        }

        public void CreateBoardGame(FactoryBoardGameAbstract factory,int size)
        {
            boardGame = factory.CreateBoardGame(size);
        }

        public void LoadBoardGame(string path)
        {
            boardGame.characters.Clear();

            XElement xelement = XElement.Load(path);
            var characters = from listCharacters in xelement.Element("characters").Elements("character")
                             select listCharacters;

            string nameSimulation = Configuration.Instance.CurrentSimulator;

            Character o;

            foreach (XElement character in characters)
            {
                o = (Character)ReflexionHelper.Instance.GetInstance(Assembly.GetExecutingAssembly(), nameSimulation, character.Attribute("type").Value,"Characters");

                o.x = int.Parse(character.Attribute("x").Value);
                o.y = int.Parse(character.Attribute("y").Value);

                boardGame.AddCharacter(o);
            }
        }

        public void SaveBoardGame(string path)
        {
            XmlWriter writer = XmlWriter.Create(path);

            writer.WriteStartElement("boardgame");
            writer.WriteStartElement("characters");

            foreach (Character character in boardGame.characters)
            {
                writer.WriteStartElement("character");
                writer.WriteAttributeString("x", character.x.ToString());
                writer.WriteAttributeString("y", character.y.ToString());
                writer.WriteAttributeString("type", character.GetType().Name);
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.Close();
        }
    }
}