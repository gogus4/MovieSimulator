using MovieSimulator.Common.BoardGame;
using MovieSimulator.Common.BoardGame.Access;
using MovieSimulator.Common.BoardGame.Area;
using MovieSimulator.Common.BoardGame.Factory;
using MovieSimulator.HungerGames.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.HungerGames.Composite;
using System.Xml.Linq;
using System.Reflection;

namespace MovieSimulator.HungerGames
{
    public class FactoryBoardGameHungerGames : FactoryBoardGameAbstract
    {
        public BoardGameHungerGames boardGameHungerGames { get; set; }

        public FactoryBoardGameHungerGames()
        {

        }

        public void LoadBoardGame(string path)
        {
            XElement xelement = XElement.Load(path);
            var areas = from listAreas in xelement.Element("areas").Elements("area")
                        select listAreas;

            string nameSimulation = path.Split('_')[0];

            foreach (XElement area in areas)
            {
                AreaAbstract o = (AreaAbstract)GetInstance(Assembly.GetExecutingAssembly(), nameSimulation, area.Attribute("type").Value);
                o.x = int.Parse(area.Attribute("x").Value);
                o.y = int.Parse(area.Attribute("y").Value);

                boardGameHungerGames.AddArea(o);
            }
        }

        public static object GetInstance(Assembly a,string simulation, string className)
        {
            try
            {
                Type type = a.GetType("MovieSimulator." + simulation + ".Area." + className);
                return Activator.CreateInstance(type); 
            }
            catch (ArgumentNullException) { return null; }
        }

        public void CreateAreas(string path)
        {
            // Load File XML if exist
            

        }

        public void SaveBoardGame()
        {

        }

        public void CreateAreas()
        {
            Random rnd = new Random();

            for (int i = 0; i < boardGameHungerGames.size; i++)
            {
                for (int j = 0; j < boardGameHungerGames.size; j++)
                {
                    int rd = rnd.Next(0, 10);

                    if (rd == 0)
                        boardGameHungerGames.AddArea(new Rock() { x = i, y = j});

                    else if (rd == 1)
                    {
                        boardGameHungerGames.AddArea(new Wall() { x = i, y = j});
                    }

                    else if (rd == 2 || rd == 3)
                    {
                        Potion potion = new Potion("Potion de fruit");
                        potion.Add(new Pomme());
                        potion.Add(new Poire());

                        boardGameHungerGames.AddArea(new Water() { x = i, y = j, item = potion });
                    }

                    else if (rd > 3 && rd < 6)
                        boardGameHungerGames.AddArea(new Grass() { x = i, y = j, item = new Pomme() });

                    else
                        boardGameHungerGames.AddArea(new Square() { x = i, y = j });
                }
            }
        }

        public override BoardGameAbstract CreateBoardGame(int size)
        {
            boardGameHungerGames = new BoardGameHungerGames(size);

            // LoadBoardGame("HungerGames_21.01.2015.xml");

            CreateAreas();

            foreach (AreaAbstract area in boardGameHungerGames.areas)
            {
                setAccess(area);
            }

            return boardGameHungerGames;
        }

        public void setAccess(AreaAbstract area)
        {
            var areas = boardGameHungerGames.areas.Where(x => (x.x == area.x && x.y == area.y - 1) ||
                                                                            (x.x == area.x && x.y == area.y + 1) ||
                                                                            (x.x == area.x - 1 && x.y == area.y) ||
                                                                            (x.x == area.x + 1 && x.y == area.y));

            if (areas != null)
            {
                List<AccessAbstract> areasPossible = new List<AccessAbstract>();
                foreach (AreaAbstract ar in areas)
                {
                    if (ar.isAccessible)
                        areasPossible.Add(new AccessAdjacent(ar));
                }

                area.access = areasPossible;
            }
        }
    }
}