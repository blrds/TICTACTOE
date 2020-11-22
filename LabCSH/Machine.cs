using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace LabCSH
{
    class Machine : Player
    {
        public Machine(string NAME, char SYMB): base(NAME, SYMB) { 
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

        public static bool operator ==(Machine left, Player right)
        {
            if (left.Name == right.Name && left.Symbol == right.Symbol) return true;
            else return false;

        }
        public static bool operator !=(Machine left, Player right) {
            if (left.Name == right.Name && left.Symbol == right.Symbol) return false;
            else return true;
        }
    }
}
