using Newtonsoft.Json;
using System;
using System.Text;
using System.Web.UI;

namespace LabCSH
{
    public abstract class Player
    {
        protected Random r { get; set; }
        public string Name { get; set; }
        public char Symbol { get; set; }

        protected Type type;

        public string Type { get => type.ToString(); }

        public Player(string name, char symb) {
            Name = name;
            Symbol = symb;
            r = new Random();
        }
        public abstract Tuple<int,int> InventMove(Game game);

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