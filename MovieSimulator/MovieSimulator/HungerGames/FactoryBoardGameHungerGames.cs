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
using System.Xml;

namespace MovieSimulator.HungerGames
{
    public class FactoryBoardGameHungerGames : FactoryBoardGameAbstract
    {
        public FactoryBoardGameHungerGames()
        {
            boardGame = new BoardGameHungerGames();
        }

        public void CreateAreas()
        {
            Random rnd = new Random();

            for (int i = 0; i < boardGame.size; i++)
            {
                for (int j = 0; j < boardGame.size; j++)
                {
                    int rd = rnd.Next(0, 10);

                    if (rd == 0)
                        boardGame.AddArea(new Rock() { x = i, y = j });

                    else if (rd == 1)
                    {
                        boardGame.AddArea(new Wall() { x = i, y = j });
                    }

                    else if (rd == 2 || rd == 3)
                    {
                        Potion potion = new Potion("Potion de fruit");
                        potion.Add(new Pomme());
                        potion.Add(new Poire());

                        boardGame.AddArea(new Water() { x = i, y = j, item = potion });
                    }

                    else if (rd > 3 && rd < 6)
                        boardGame.AddArea(new Grass() { x = i, y = j, item = new Pomme() });

                    else
                        boardGame.AddArea(new Square() { x = i, y = j });
                }
            }
        }

        public override BoardGameAbstract CreateBoardGame(int size)
        {
            boardGame = new BoardGameHungerGames(size);

            LoadBoardGame("XML/HungerGames.xml");

            //CreateAreas();

            // SaveBoardGame("toto");

            foreach (AreaAbstract area in boardGame.areas)
            {
                setAccess(area);
            }

            return boardGame;
        }

        public void setAccess(AreaAbstract area)
        {
            var areas = boardGame.areas.Where(x => (x.x == area.x && x.y == area.y - 1) ||
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