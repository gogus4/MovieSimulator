using MovieSimulator.Common.BoardGame;
using MovieSimulator.Common.BoardGame.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}