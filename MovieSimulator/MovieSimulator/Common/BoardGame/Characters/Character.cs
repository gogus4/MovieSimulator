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
    public abstract class Character : ComponentDecoratorAbstract, ICloneable, IObserver
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
                            Console.WriteLine("Personnage dans la même case !");
                    }

                    if (listAccessPossible.Count > 0)
                    {
                        Random rnd = new Random();
                        int nb = rnd.Next(0, listAccessPossible.Count);

                        Console.WriteLine(string.Format("Personnage[{0},{1}] se déplace en [{2},{3}]", x, y, listAccessPossible[nb].areaEnd.x, listAccessPossible[nb].areaEnd.y));

                        this.x = listAccessPossible[nb].areaEnd.x;
                        this.y = listAccessPossible[nb].areaEnd.y;

                        AddDecoratorToDoMyReport(listAccessPossible[nb].areaEnd);

                        if (listAccessPossible[nb].areaEnd.item != null)
                        {
                            this.hp += listAccessPossible[nb].areaEnd.item.getHealPower();
                            Console.WriteLine(string.Format("Personnage[{0},{1}] a trouver {2}. Son hp augmente de : {3}", x, y, listAccessPossible[nb].areaEnd.item.ToString(), listAccessPossible[nb].areaEnd.item.getHealPower()));
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
            Console.WriteLine(String.Format("{0}[{3},{4}] attaque {1}[{5},{6}] : hp restants ==> {2}", this, toAttack, toAttack.hp, this.x, this.y, toAttack.x, toAttack.y));
            toAttack.GetAssaultFrom(this);
        }

        public void GetAssaultFrom(Character fromAttack) {
            hp -= fromAttack.strategyFight.Degats();
            if (hp > 0)
            {
                Console.WriteLine(String.Format("{0}[{3},{4}] est attaqué par {1}[{5},{6}] : hp restants ==> {2}", this, fromAttack, this.hp, this.x, this.y, fromAttack.x, fromAttack.y));
            }
            else
            {
                Console.WriteLine(String.Format("{0}[{1},{2}] is dead ...", this, this.x, this.y));

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
                    toReturn = name + " hear a message ! It says : \"" + message + "\"";
                    break;
                case EMode.DoMyReport:
                    toReturn = UseMyDecoratorToDoMyReport();
                    break;
                default:
                    toReturn = "No comportement setted or not implemented yet";
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
                }

                if (!isAlreadyDecorated)
                {
                    newDecorator.SetComponent(decorator);
                    decorator = newDecorator;
                }
            }
            else
            {
                decorator = newDecorator;
            }
            

        }

        public string UseMyDecoratorToDoMyReport()
        {
            if (decorator != null)
            {
                return decorator.DoMyReport();
            }
            else
            {
                return DoMyReport();
            }
        }

        public override string DoMyReport()
        {
            return "My name is " + name + " and i have " + hp + " health points";
        }
    }

}