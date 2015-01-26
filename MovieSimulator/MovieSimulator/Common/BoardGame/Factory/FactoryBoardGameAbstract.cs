using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using MovieSimulator.Common.BoardGame.Area;
using MovieSimulator.Common.BoardGame.Utils;

namespace MovieSimulator.Common.BoardGame.Factory
{
    public abstract class FactoryBoardGameAbstract
    {
        public BoardGameAbstract boardGame { get; set; }

        public FactoryBoardGameAbstract()
        {

        }

        public abstract BoardGameAbstract CreateBoardGame(int size);

        public void LoadBoardGame(string path)
        {
            XElement xelement = XElement.Load(path);
            var areas = from listAreas in xelement.Element("areas").Elements("area")
                        select listAreas;

            string nameSimulation = path.Split('_')[0];
            AreaAbstract o;

            foreach (XElement area in areas)
            {
                if (area.Attribute("type").Value != "Square")
                    o = (AreaAbstract)ReflexionHelper.Instance.GetInstance(Assembly.GetExecutingAssembly(), nameSimulation, area.Attribute("type").Value);

                else
                    o = new Square();

                o.x = int.Parse(area.Attribute("x").Value);
                o.y = int.Parse(area.Attribute("y").Value);

                boardGame.AddArea(o);
            }
        }

        public void SaveBoardGame(string path)
        {
            XmlWriter writer = XmlWriter.Create("books.xml");

            writer.WriteStartElement("boardgame");

            writer.WriteStartElement("areas");

            foreach (AreaAbstract area in boardGame.areas)
            {
                writer.WriteStartElement("area");
                writer.WriteAttributeString("x", area.x.ToString());
                writer.WriteAttributeString("y", area.y.ToString());
                writer.WriteAttributeString("type", area.GetType().Name);
                writer.WriteEndElement();
            }

            // Add characters
            writer.WriteStartElement("characters");
            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.Close();
        }
    }
}
