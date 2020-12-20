using System;
using System.Collections.Generic;
using System.Web.UI;

namespace LabCSH
{
    public class Machine : Player
    {
        public Machine(string name, char symb): base(name, symb) {
            type = this.GetType();
        }

        public override Tuple<int,int> InventMove(Game game)
        {
            List<Tuple<int, int>> freeCells;
            freeCells = game.GetFreeCells();
            if (freeCells.Count==0)
                return new Tuple<int, int>(-1,-1);
            return freeCells[r.Next(0,freeCells.Count)];   
        }
        public override bool Equals(object obj)
        {
            return obj is Player player &&
                   Name == player.Name &&
                   Symbol == player.Symbol;
        }

        public static bool operator ==(Machine left, Player right)
        {
            if (object.ReferenceEquals(left, null))
            {
                return object.ReferenceEquals(right, null);
            }

            return left.Equals(right); 

        }
        public static bool operator !=(Machine left, Player right) {
            return !(left == right);
        }
    }
}
