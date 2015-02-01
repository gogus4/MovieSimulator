using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.Common.BoardGame;
using MovieSimulator.Common.BoardGame.Access;
using MovieSimulator.Common.BoardGame.Area;
using MovieSimulator.Common.BoardGame.Factory;
using MovieSimulator.PrisonBreak.Area;

namespace MovieSimulator.PrisonBreak
{
    public class FactoryBoardGamePrisonBreak : FactoryBoardGameAbstract
    {
        public FactoryBoardGamePrisonBreak()
        {
            boardGame = new BoardGamePrisonBreak();
        }

        public void CreateAreas()
        {
            Random rnd = new Random();

            for (int i = 0; i < boardGame.size; i++)
            {
                for (int j = 0; j < boardGame.size; j++)
                {
                    int rd = rnd.Next(0, 10);

                    if (rd == 0 || rd == 1)
                        boardGame.AddArea(new Grid() { x = i, y = j });

                    else if (rd == 2 || rd == 3)
                    {
                        boardGame.AddArea(new Wall() { x = i, y = j });
                    }
                    /*   
                    else if (rd == 2 || rd == 3)
                    {
                        Potion potion = new Potion("Potion de fruit");
                        potion.Add(new Pomme());
                        potion.Add(new Poire());

                        boardGame.AddArea(new Water() { x = i, y = j, item = potion });
                    }
                    */
                    else if (rd == 4)
                        boardGame.AddArea(new Door() { x = i, y = j });

                    else
                        boardGame.AddArea(new Ground() { x = i, y = j });
                }
            }
        }

        public override BoardGameAbstract CreateBoardGame(int size)
        {
            boardGame = new BoardGamePrisonBreak(size);

            //LoadBoardGame("HungerGames_23.01.2015.xml");

            FillBoardGame("XML/PrisonBreak.xml");

            // CreateAreas();

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
