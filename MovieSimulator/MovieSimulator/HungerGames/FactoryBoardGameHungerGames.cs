using MovieSimulator.Common.BoardGame;
using MovieSimulator.Common.BoardGame.Access;
using MovieSimulator.Common.BoardGame.Area;
using MovieSimulator.Common.BoardGame.Factory;
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
            for (int i = 0; i < boardGameHungerGames.size; i++)
            {
                for (int j = 0; j < boardGameHungerGames.size; j++)
                {
                    boardGameHungerGames.AddArea(new Square() { x = i, y = j });
                }
            }
        }

        public override BoardGameAbstract CreateBoardGame(int size)
        {
            boardGameHungerGames = new BoardGameHungerGames(size);

            CreateAreas();

            return boardGameHungerGames;
        }
    }
}