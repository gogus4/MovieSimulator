using MovieSimulator.Common;
using MovieSimulator.Common.BoardGame.Area;
using MovieSimulator.Common.BoardGame.Characters;
using MovieSimulator.Common.BoardGame.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSimulator.HungerGames.Characters
{
    public class Katniss : Character
    {
        public Katniss(int x, int y) : base(x,y)
        {
            command = new CommandUpdateCharacter();
        }

        public Katniss()
        {
            command = new CommandUpdateCharacter();
            // Random x et y
        }

        public override void Move()
        {
            var area = GamingEnvironment.Instance.boardGame.areas.Where(x => x.x == this.x && x.y == this.y).FirstOrDefault();

            Random rnd = new Random();
            int nb = rnd.Next(0, area.access.Count);

            this.x = area.access[nb].areaEnd.x;
            this.y = area.access[nb].areaEnd.y;

            area.UpdateGraphic();
            command.UpdateCharacterBoardGame(this);
        }

        public override bool Watch()
        {
            throw new NotImplementedException();
        }

        public override void Fight()
        {
            throw new NotImplementedException();
        }
    }
}
