using Newtonsoft.Json;
using System;
using System.Text;
using System.Web.UI;

namespace LabCSH
{
    public enum PlayerType { 
        Machine, SmartMachine
    }
    public abstract class Player
    {

        public string Name { get; set; }
        public char Symbol { get; set; }

        public PlayerType type { get; set; }

        public Player(string NAME, char SYMB) {
            Name = NAME;
            Symbol = SYMB;
        }
        public abstract Pair invent_move(Game game);

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append(Name);
            s.Append(" ");
            s.Append(Symbol);
            return s.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is Player player &&
                   Name == player.Name &&
                   Symbol == player.Symbol;
        }

        public static bool operator == (Player left, Player right)
        {
            if (object.ReferenceEquals(left, null))
            {
                return object.ReferenceEquals(right, null);
            }

            return left.Equals(right);

        }
        public static bool operator !=(Player left, Player right)
        {
            return !(left==right);
        }

        public string Serialize() {
            return JsonConvert.SerializeObject(this);
        }
    }
}