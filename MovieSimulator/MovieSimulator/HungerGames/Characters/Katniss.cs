using MovieSimulator.Common;
using MovieSimulator.Common.BoardGame.Area;
using MovieSimulator.Common.BoardGame.Characters;
using MovieSimulator.Common.BoardGame.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.Common.BoardGame.Access;

namespace MovieSimulator.HungerGames.Characters
{
    public class Katniss : Character
    {
        public Katniss(int x, int y)
            : base(x, y)
        {
            command = new CommandUpdateCharacter();
        }

        public Katniss()
        {
            command = new CommandUpdateCharacter();
        }

        public override void Move()
        {
            var area = GamingEnvironment.Instance.boardGame.areas.Where(x => x.x == this.x && x.y == this.y).FirstOrDefault();

            if (area != null)
            {
                if (area.access.Count > 0)
                {
                    List<AccessAbstract> listAccessPossible = new List<AccessAbstract>();

                    foreach (AccessAbstract access in area.access)
                    {
                        var characterInCase = GamingEnvironment.Instance.boardGame.characters.Where(x => x.x == access.areaEnd.x && x.y == access.areaEnd.y).FirstOrDefault();

                        if (characterInCase == null)
                            listAccessPossible.Add(access);

                        else
                            Console.WriteLine("Personnage dans la même case !");
                    }

                    if (listAccessPossible.Count > 0)
                    {
                        Random rnd = new Random();
                        int nb = rnd.Next(0, listAccessPossible.Count);

                        Console.WriteLine(string.Format("Personnage[{0},{1}] se déplace en [{2},{3}]", x, y, listAccessPossible[nb].areaEnd.x, listAccessPossible[nb].areaEnd.y));

                        this.x = listAccessPossible[nb].areaEnd.x;
                        this.y = listAccessPossible[nb].areaEnd.y;

                        area.UpdateGraphic();
                        command.UpdateCharacterBoardGame(this);

                    }
                }
            }
        }

        public override bool Watch()
        {
            //GamingEnvironment.Instance.boardGame.characters.Where(x => x.x <= x)

            /*var areas = boardGameHungerGames.areas.Where(x => (x.x == area.x && x.y == area.y - 1) ||
                                                                (x.x == area.x && x.y == area.y + 1) ||
                                                                (x.x == area.x - 1 && x.y == area.y) ||
                                                                (x.x == area.x + 1 && x.y == area.y));*/


        }
        
        public override void Fight()
        {
            throw new NotImplementedException();
        }
    }
}
