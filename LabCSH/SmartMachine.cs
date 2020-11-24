using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace LabCSH
{
    public class SmartMachine : Player
    {
        public SmartMachine(string NAME, char SYMB) : base(NAME, SYMB)
        {
			type = PlayerType.SmartMachine;
        }

		public Pair WinCombo(Game game, char symb) {
			for (int x = 0; x < game.Size; x++) // проверяем выигрышные комбинации по стобцам
			{
				int num_of_friend_symbs = 0;
				for (int y = 0; y < game.Size; y++)
				{
					if (game.Field[x][y] == symb)
						num_of_friend_symbs++;
				}

				if (num_of_friend_symbs == game.Size - 1)
				{
					for (int y = 0; y < game.Size; y++)
					{
						if (game.Field[x][y] == game.DefSymbol)
							return new Pair(x, y);
					}
				}
			}

			for (int y = 0; y < game.Size; y++) // Проверяем выигрышные комбинации по строкам
			{
				int num_of_friend_symbs = 0;
				for (int x = 0; x < game.Size; x++)
				{
					if (game.Field[x][y] == symb)
						num_of_friend_symbs++;
				}

				if (num_of_friend_symbs == game.Size - 1)
				{
					for (int x = 0; x < game.Size; x++)
					{
						if (game.Field[x][y] == game.DefSymbol)
							return new Pair(x, y);
					}
				}
			}

			{
				int num_of_friend_symbs = 0;

				for (int y = 0, x = 0; x < game.Size; y++, x++)
				{
					if (game.Field[x][y] == symb)
					{
						num_of_friend_symbs++;
						continue;
					}
					else if (game.Field[x][y] != game.DefSymbol && game.Field[x][y] != symb)
						break;
				}
				if (num_of_friend_symbs == game.Size - 1)
				{
					for (int y = 0, x = 0; x < game.Size; y++, x++)
					{
						if (game.Field[x][y] != symb)
							return new Pair(x, y);
					}
				}

				// | Проверка выигрышный комбинации по обратной диагонали
				// |
				num_of_friend_symbs = 0;

				for (int y = 0, x = game.Size - 1; x >= 0; y++, x--)
				{
					if (game.Field[x][y] == symb)
					{
						num_of_friend_symbs++;
						continue;
					}
					else if (game.Field[x][y] != game.DefSymbol && game.Field[x][y] != symb)
						break;
				}
				if (num_of_friend_symbs == game.Size - 1)
				{
					for (int y = 0, x = game.Size - 1; x > 0; y++, x--)
					{
						if (game.Field[x][y] != symb)
							return new Pair(x, y);
					}
				}
			}
			return null;
		}
		public Pair Interference(Game game, char symb) {
			for (int x = 0; x < game.Size; x++) // Проверяем по строкам комбинации противника
			{
				int num_of_enemy_symbs = 0;
				for (int y = 0; y < game.Size; y++)
				{
					if (game.Field[x][y] != game.DefSymbol && game.Field[x][y] != symb)
						num_of_enemy_symbs++;
				}

				if (num_of_enemy_symbs == game.Size - 1)
				{
					for (int y = 0; y < game.Size; y++)
					{
						if (game.Field[x][y] == game.DefSymbol)
							return new Pair(x, y);
					}
				}
			}

			for (int y = 0; y < game.Size; y++) // проверяем по столбцам комбинации противника
			{
				int num_of_enemy_symbs = 0;
				for (int x = 0; x < game.Size; x++)
				{
					if (game.Field[x][y] != game.DefSymbol && game.Field[x][y] != symb)
						num_of_enemy_symbs++;
				}

				if (num_of_enemy_symbs == 2)
				{
					for (int x = 0; x < game.Size; x++)
					{
						if (game.Field[x][y] == game.DefSymbol)
							return new Pair(x, y);
					}
				}
			}

			{
				int num_of_enemy_symbs = 0;

				for (int y = 0, x = 0; x < game.Size; y++, x++)
				{
					if (game.Field[x][y] != game.DefSymbol && game.Field[x][y] != symb)
					{
						num_of_enemy_symbs++;
						continue;
					}
					else if (game.Field[x][y] != game.DefSymbol && game.Field[x][y] != symb)
						break;
				}
				if (num_of_enemy_symbs == game.Size - 1)
				{
					for (int y = 0, x = 0; x < game.Size; y++, x++)
					{
						if (game.Field[x][y] != symb && game.Field[x][y] == game.DefSymbol)
							return new Pair(x, y);
					}
				}

				// | Проверка комбинаций противника по обратной диагонали
				// |
				num_of_enemy_symbs = 0;

				for (int y = 0, x = game.Size - 1; x >= 0; y++, x--)
				{
					if (game.Field[x][y] != game.DefSymbol && game.Field[x][y] != symb)
					{
						num_of_enemy_symbs++;
						continue;
					}
					else if (game.Field[x][y] != game.DefSymbol && game.Field[x][y] != symb)
						break;
				}
				if (num_of_enemy_symbs == game.Size - 1)
				{
					for (int y = 0, x = game.Size - 1; x >= 0; y++, x--)
					{
						if (game.Field[x][y] != symb && game.Field[x][y] == game.DefSymbol)
							return new Pair(x, y);
					}
				}
			}
			return null;
		}

		public override Pair invent_move(Game game)
		{
			if (0 == game.GetFreeCells().Count)
				return new Pair(-1, -1);
			Pair p;
			p = WinCombo(game, Symbol);
			if (p != null) return p;

			p = Interference(game, Symbol);
			if (p != null) return p;

			if (game.Field[0][0] == game.DefSymbol)
				return new Pair(0, 0);
			if (game.Field[game.Size - 1][game.Size - 1] == game.DefSymbol)
				return new Pair(game.Size - 1, game.Size - 1);
			if (game.Field[0][game.Size - 1] == game.DefSymbol)
				return new Pair(0, game.Size - 1);
			if (game.Field[game.Size - 1][0] == game.DefSymbol)
				return new Pair(game.Size - 1, 0);

			Random r = new Random();
			List<Pair> free_cells = game.GetFreeCells();
			if (free_cells.Count != 0)
				return free_cells[(int)r.NextDouble() * (free_cells.Count)];
			else return new Pair(-1, -1);
		}

		public override bool Equals(object obj)
		{
			return obj is Player player &&
				   Name == player.Name &&
				   Symbol == player.Symbol;
		}
		public static bool operator ==(SmartMachine left, Player right) {
			if (object.ReferenceEquals(left, null))
			{
				return object.ReferenceEquals(right, null);
			}

			return left.Equals(right);

		}
		public static bool operator !=(SmartMachine left, Player right)
        {
			return !(left == right);
        }
    }
}
