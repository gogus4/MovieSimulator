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

namespace MovieSimulator.HungerGames
{
    public class FactoryBoardGameHungerGames : FactoryBoardGameAbstract
    {
        public BoardGameHungerGames boardGameHungerGames { get; set; }

        public FactoryBoardGameHungerGames()
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
                        boardGameHungerGames.AddArea(new Rock() { x = i, y = j });

                    else if (rd == 1)
                        boardGameHungerGames.AddArea(new Wall() { x = i, y = j });


                    else if (rd == 2 || rd == 3)
                        boardGameHungerGames.AddArea(new Water() { x = i, y = j });

                    else if (rd > 3 && rd < 6)
                        boardGameHungerGames.AddArea(new Grass() { x = i, y = j });

                    else
                        boardGameHungerGames.AddArea(new Square() { x = i, y = j });
                }
            }
        }

        public override BoardGameAbstract CreateBoardGame(int size)
        {
            boardGameHungerGames = new BoardGameHungerGames(size);

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