using System;
using System.Collections.Generic;
using System.Web.UI;

namespace LabCSH
{
    public class Machine : Player
    {
        public Machine(string NAME, char SYMB): base(NAME, SYMB) {
            type = PlayerType.Machine;
        }

        public override Pair invent_move(Game game)
        {
            if (game.GetFreeCells().Count==0)
                return new Pair(-1,-1);
            Random r = new Random();
            List<Pair> free_cells;
            free_cells = game.GetFreeCells();
            return free_cells[(int)r.NextDouble() * (free_cells.Count)];   
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
