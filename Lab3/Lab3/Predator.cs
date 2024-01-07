using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Predator : Creature
    {

        int CanStarve;
        int TactsStarving;
        public Predator(int reproductionAge, int reproductionInterval, int canStarve, int age, CreaturePosition position, Random r) : base(reproductionAge, reproductionInterval, position, r, age)
        {
            this.CanStarve = canStarve;            
            this.CreatureColor = Color.Red;
            this.TactsStarving = 0;
        }

        
        public override Creature[,] ChangeCreaturePosition(Creature[,] creatures)
        {
            CreaturePosition victimPosition = CheckForVictimsAround(creatures);
            if (victimPosition.X==-1)
            {
                if (CheckForFreeCells(creatures))
                {
                    CreaturePosition newPosition = new CreaturePosition(r.Next(this.Position.X - 1, this.Position.X + 1), r.Next(this.Position.Y - 1, this.Position.Y + 1));
                    newPosition = FixWrongPositionValues(newPosition, creatures);
                    while (creatures[newPosition.Y, newPosition.X] != null)
                    {
                        newPosition = new CreaturePosition(r.Next(this.Position.X - 1, this.Position.X + 1), r.Next(this.Position.Y - 1, this.Position.Y + 1));
                        newPosition = FixWrongPositionValues(newPosition, creatures);
                    }
                    creatures[this.Position.Y, this.Position.X] = null;
                    this.Position = newPosition;
                    creatures[this.Position.Y, this.Position.X] = this;                    
                }                
                TactsStarving++;
                if(TactsStarving>CanStarve)
                {
                    creatures[this.Position.Y,this.Position.X] = null;
                }
                else
                {                    
                    Age++;
                    if (Age > ReproductionAge)
                    {
                        TactsFromLastReproduce++;
                        creatures = (Creature[,])ProduceOffspring(creatures).Clone();
                    }                    
                }                               
            }
            else 
            {
                creatures[this.Position.Y, this.Position.X] = null;
                this.Position = victimPosition;
                creatures[this.Position.Y, this.Position.X] = this;
                TactsStarving = 0;
                Age++;
                if (Age > ReproductionAge)
                {
                    TactsFromLastReproduce++;
                    creatures = (Creature[,])ProduceOffspring(creatures).Clone();
                }
            }
            return creatures;
        }

        internal override Creature[,] ProduceOffspring(Creature[,] creatures)
        {
            if (TactsFromLastReproduce > ReproductionInterval)
            {
                if (CheckForFreeCells(creatures))
                {
                    CreaturePosition childPosition = new CreaturePosition(r.Next(this.Position.X - 1, this.Position.X + 1), r.Next(this.Position.Y - 1, this.Position.Y + 1));
                    childPosition = FixWrongPositionValues(childPosition, creatures);
                    while (creatures[childPosition.Y, childPosition.X] != null)
                    {
                        childPosition = new CreaturePosition(r.Next(this.Position.X - 1, this.Position.X + 1), r.Next(this.Position.Y - 1, this.Position.Y + 1));
                        childPosition = FixWrongPositionValues(childPosition, creatures);
                    }
                    creatures[childPosition.Y, childPosition.X] = new Predator(this.ReproductionAge, this.ReproductionInterval, this.CanStarve, 0, childPosition, r);
                    this.TactsFromLastReproduce = 0;
                }
            }
            return creatures;
        }

        private CreaturePosition CheckForVictimsAround(Creature[,] creatures)
        {
            CreaturePosition position = new CreaturePosition(-1, -1);            
            CreaturePosition tempPosition = new CreaturePosition(0, 0);
            for (int i = this.Position.Y - 1; i < this.Position.Y + 1; i++)
            {
                for (int j = this.Position.X - 1; j < this.Position.X + 1; j++)
                {
                    tempPosition.Y = i;
                    tempPosition.X = j;
                    tempPosition = FixWrongPositionValues(tempPosition, creatures);
                    if (creatures[tempPosition.Y, tempPosition.X] !=null && creatures[tempPosition.Y, tempPosition.X].GetType() == typeof(Victim))
                    {
                        position = creatures[tempPosition.Y, tempPosition.X].Position;
                    }
                }
            }
            return position;
        }
    }
}
