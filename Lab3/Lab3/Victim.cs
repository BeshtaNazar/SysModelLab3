using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Victim : Creature
    {                
        public Victim(int reproductionAge, int reproductionInterval, int age, CreaturePosition position, Random r) :base(reproductionAge,reproductionInterval,position, r, age)
        {            
            this.Age = age;
            this.CreatureColor = Color.Green;            
        }

        public override Creature[,] ChangeCreaturePosition(Creature[,] creatures)
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
                this.Age++;
                if (this.Age > this.ReproductionAge)
                {
                    this.TactsFromLastReproduce++;
                    creatures = (Creature[,])ProduceOffspring(creatures).Clone();                    
                }
            }
            else
            {                
                this.Age++;
                if(this.Age > this.ReproductionAge) 
                    this.TactsFromLastReproduce++;
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
                    creatures[childPosition.Y, childPosition.X] = new Victim(this.ReproductionAge, this.ReproductionInterval, 0, childPosition, r);
                    this.TactsFromLastReproduce = 0;                    
                }                
            }
            return creatures;
        }
    }
}
