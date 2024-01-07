using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public abstract class Creature
    {
        public CreaturePosition Position;
        public Color CreatureColor;
        public int Age { get; set; }
        internal int ReproductionAge;
        internal int ReproductionInterval;
        internal int TactsFromLastReproduce;
        internal Random r;
        public Creature(int reproductionAge, int reproductionInterval,CreaturePosition position, Random r, int age)
        {
            Position = position;
            this.r = r;
            Age = age;
            ReproductionAge = reproductionAge;
            ReproductionInterval = reproductionInterval;
            TactsFromLastReproduce = 0;
        }

        internal abstract Creature[,] ProduceOffspring(Creature[,] creatures);
        
            
        
        public Creature[,] SetCreaturePosition(Creature[,] creatures)
        {                  
            CreaturePosition oldPos = new CreaturePosition(this.Position.X, this.Position.Y);
            this.Position.Y = r.Next(0,creatures.GetLength(0));
            this.Position.X = r.Next(0, creatures.GetLength(1));
            if (creatures[ this.Position.Y, this.Position.X] == null)
            {
                creatures[this.Position.Y, this.Position.X] = this;
                creatures[oldPos.Y, oldPos.X] = null;
                return creatures;
            }
            else
            {
                while (creatures[this.Position.Y, this.Position.X] != null)
                {
                    this.Position.Y = r.Next(0, creatures.GetLength(0));
                    this.Position.X = r.Next(0, creatures.GetLength(1));
                }               
                creatures[this.Position.Y, this.Position.X] = this;
                creatures[oldPos.Y, oldPos.X] = null;
                return creatures;             
            }            
        }

        public abstract Creature[,] ChangeCreaturePosition(Creature[,] creatures);       
        
        internal CreaturePosition FixWrongPositionValues(CreaturePosition position, Creature[,] creatures)
        {
            if (position.X < 0)
                position.X = position.X + creatures.GetLength(1);
            if (position.Y < 0)
                position.Y = position.Y + creatures.GetLength(0);
            if (position.X > creatures.GetLength(1) - 1)
                position.X = position.X - creatures.GetLength(1);
            if (position.Y > creatures.GetLength(0) - 1)
                position.Y = position.Y - creatures.GetLength(0);
            return position;
        }

        internal bool CheckForFreeCells(Creature[,] creatures)
        {
            bool isEmpty=false;
            CreaturePosition position = new CreaturePosition(0,0);
            for (int i = this.Position.Y-1; i < this.Position.Y+1; i++)
            {
                for (int j = this.Position.X-1; j < this.Position.X+1; j++)
                {
                    position.Y = i;
                    position.X = j;
                    position = FixWrongPositionValues(position, creatures);                                           
                    if (creatures[position.Y, position.X] == null)
                    {
                        isEmpty = true;
                        return isEmpty;
                    }                      
                }
            }
            return isEmpty;
        }
    }
}
