using MovieSimulator.Common.BoardGame.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.Common.BoardGame.Strategy;
using MovieSimulator.HungerGames.Strategy;
using MovieSimulator.Common.BoardGame.Access;
using MovieSimulator.Common.BoardGame.Observer;
using MovieSimulator.Common.BoardGame.Characters.Decorator;
using MovieSimulator.Common.BoardGame.Area;
using MovieSimulator.HungerGames.Area;
using MovieSimulator.HungerGames.Characters.Decorator;

namespace MovieSimulator.Common.BoardGame.Characters
{
    public abstract class Character : DecoratorAbstract, ICloneable, IObserver
    {
        public String name { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public int hp { get; set; }

        public string pathBackground { get; set; }

        public CommandAbstract command { get; set; }

        public StrategyFight strategyFight { get; set; }

        public EMode boardgameMode { get; set; }

        public DecoratorAbstract decorator { get; set; }

        public Character(int x, int y)
            : this()
        {
            this.x = x;
            this.y = y;
        }

        public Character()
        {
            strategyFight = new StrategyFightWithArm();
            hp = 100;
        }

        public void Action()
        {
            var character = this.Watch();

            if (character != null) {
                this.Fight(character);
            }
            else {
                this.Move();
            }

            command.UpdateCharacterBoardGame(this);
        }

        public void Move()
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
                            GameSimulator.Instance.actionText.AppendText("Personnage dans la même case !");
                    }

                    if (listAccessPossible.Count > 0)
                    {
                        Random rnd = new Random();
                        int nb = rnd.Next(0, listAccessPossible.Count);

                        GameSimulator.Instance.actionText.AppendText(string.Format("{4}[{0},{1}] se déplace en [{2},{3}]{5}", x, y, listAccessPossible[nb].areaEnd.x, listAccessPossible[nb].areaEnd.y, this.name, Environment.NewLine));

                        this.x = listAccessPossible[nb].areaEnd.x;
                        this.y = listAccessPossible[nb].areaEnd.y;

                        AddDecoratorToDoMyReport(listAccessPossible[nb].areaEnd);

                        if (listAccessPossible[nb].areaEnd.item != null)
                        {
                            this.hp += listAccessPossible[nb].areaEnd.item.getHealPower();
                            GameSimulator.Instance.actionText.AppendText(string.Format("{4}[{0},{1}] a trouver {2}. Son hp augmente de : {3}{5}", x, y, listAccessPossible[nb].areaEnd.item.ToString(), listAccessPossible[nb].areaEnd.item.getHealPower(), this.name, Environment.NewLine));
                            listAccessPossible[nb].areaEnd.item = null;
                        }

                        area.UpdateGraphic();
                        //command.UpdateCharacterBoardGame(this);
                    }
                }
            }
        }

        public Character Watch() {
            var character = GamingEnvironment.Instance.boardGame.characters
                            .Where(x => (x.x != this.x && x.y != this.y))
                            .Where(x =>
                                (x.x <= this.x + this.strategyFight.Range() && x.x >= this.x - this.strategyFight.Range()) &&
                                (x.y <= this.y + this.strategyFight.Range() && x.y >= this.y - this.strategyFight.Range())
                            ).FirstOrDefault();
            return character;
        }
            
        public void Fight(Character toAttack) {
            GameSimulator.Instance.actionText.AppendText(String.Format("{0}[{3},{4}] attaque {1}[{5},{6}] : hp restants ==> {2}{7}", this.name, toAttack.name, toAttack.hp, this.x, this.y, toAttack.x, toAttack.y, Environment.NewLine));
            toAttack.GetAssaultFrom(this);
        }

        public void GetAssaultFrom(Character fromAttack) {
            hp -= fromAttack.strategyFight.Degats();
            if (hp > 0)
            {
                GameSimulator.Instance.actionText.AppendText(String.Format("{0}[{3},{4}] est attaqué par {1}[{5},{6}] : hp restants ==> {2}{7}", this.name, fromAttack.name, this.hp, this.x, this.y, fromAttack.x, fromAttack.y, Environment.NewLine));
            }
            else
            {
                GameSimulator.Instance.actionText.AppendText(String.Format("{0}[{1},{2}] is dead ...{3}", this.name, this.x, this.y, Environment.NewLine));

                if (this.strategyFight.Degats() < fromAttack.strategyFight.Degats())
                    this.strategyFight = fromAttack.strategyFight;

                //GamingEnvironment.Instance.boardGame.characters.Remove(this);
                GamingEnvironment.Instance.boardGame.areas.Where(x => x.x == this.x && x.y == this.y).FirstOrDefault().UpdateGraphic();
            }
        }

        public Object Clone()
        {
            Character othercopy = (Character)this.MemberwiseClone();
            return othercopy;
        }

        public void Update()
        {
            this.boardgameMode = GamingEnvironment.Instance.boardGame.staff.ObserverMode;
        }


        public string ExecuteBoardgameStrategy()
        {
            string toReturn = null;
            switch (this.boardgameMode)
            {
                case EMode.ListenMessage:
                    string message = GameSimulator.Instance.sendMessageBox.Text;
                    toReturn = name + " entend un message ! Le message dit : \"" + message + "\"" + Environment.NewLine;
                    break;
                case EMode.DoMyReport:
                    toReturn = UseMyDecoratorToDoMyReport();
                    break;
                default:
                    toReturn = "Ce comportement n'a pas encore été implémenté";
                    break;
            }

            return toReturn;
        }

        public void AddDecoratorToDoMyReport(AreaAbstract area)
        {
            Boolean isAlreadyDecorated = false;
            Boolean needToAddADecorator = false;
            DecoratorAbstract dec = decorator;
            DecoratorAbstract newDecorator = null;

            if (typeof(Grass).Equals(area.GetType())){
                newDecorator = new GrassDecorator();
                needToAddADecorator = true;
            }
            else if (typeof(Water).Equals(area.GetType()))
            {
                newDecorator = new WaterDecorator();
                needToAddADecorator = true;
            }

            if (dec != null && needToAddADecorator)
            {
                while (dec != null)
                {
                    if (dec.GetType().Equals(newDecorator.GetType()))
                    {
                        isAlreadyDecorated = true;
                        break;
                    }
                    dec = dec.component;
                }

                if (!isAlreadyDecorated)
                {
                    newDecorator.SetComponent(decorator);
                    decorator = newDecorator;
                }
            }
            else
            {
                if (newDecorator != null)
                {
                    newDecorator.SetComponent(this);
                    decorator = newDecorator;
                }
            }            
        }

        public string UseMyDecoratorToDoMyReport()
        {
            if (decorator != null)
            {
                return decorator.DoMyReport() + Environment.NewLine;
            }
            else
            {
                return DoMyReport() + Environment.NewLine;
            }
        }

        public override string DoMyReport()
        {
            return base.DoMyReport() + "Je m'apppelle " + name + " et il me reste " + hp + " points de vie";
        }
    }

}