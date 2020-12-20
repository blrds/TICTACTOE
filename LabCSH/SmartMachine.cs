using System;
using System.Collections.Generic;
using System.Web.UI;

namespace LabCSH
{
    public class SmartMachine : Player
    {
        public SmartMachine(string name, char symb) : base(name, symb)
        {
			type = this.GetType();	
        }


		private Tuple<int, int> ColumnWin(Game game, char symb) {// проверяем выигрышные комбинации по стобцам
			for (int x = 0; x < game.Size; x++) 
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
							return new Tuple<int, int>(x, y);
					}
				}
			}
			return null;
		}

		private Tuple<int, int> RowWin(Game game, char symb)// Проверяем выигрышные комбинации по строкам
		{
			for (int y = 0; y < game.Size; y++) 
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
							return new Tuple<int, int>(x, y);
					}
				}
			}
			return null;
		}

		private Tuple<int, int> MainDiagWin(Game game, char symb)// Проверяем выигрышные комбинации по главной диагонали
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
						return new Tuple<int, int>(x, y);
				}
			}
			return null;
		}

		private Tuple<int, int> SecondDiagWin(Game game, char symb)// Проверяем выигрышные комбинации по побочной диагонали
		{
			int num_of_friend_symbs = 0;

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
						return new Tuple<int, int>(x, y);
				}
			}
			return null;
		}
		public Tuple<int,int> WinCombo(Game game, char symb) {

			Tuple<int, int> answer;
			answer = ColumnWin(game, symb);
			if (answer != null) return answer;
			answer = RowWin(game, symb);
			if (answer != null) return answer;
			answer = MainDiagWin(game, symb);
			if (answer != null) return answer;
			answer = SecondDiagWin(game, symb);
			if (answer != null) return answer;

			return null;
		}

		private Tuple<int, int> EnemyColumn(Game game, char symb) {// Проверяем по строкам комбинации противника
			for (int x = 0; x < game.Size; x++) 
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
							return new Tuple<int, int>(x, y);
					}
				}
			}
			return null;
		}

		private Tuple<int, int> EnemyRow(Game game, char symb)// проверяем по столбцам комбинации противника
		{
			for (int y = 0; y < game.Size; y++) 
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
							return new Tuple<int, int>(x, y);
					}
				}
			}
			return null;
		}

		private Tuple<int, int> EnemyMainDiag(Game game, char symb)// Проверяем по главной диагонали комбинации противника
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
						return new Tuple<int, int>(x, y);
				}
			}
			return null;
		}
		private Tuple<int, int> EnemySecondDiag(Game game, char symb)// Проверяем по побочной диагонали комбинации противника
		{
			int num_of_enemy_symbs = 0;

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
						return new Tuple<int, int>(x, y);
				}
			}
			return null;
		}

		public Tuple<int,int> Interference(Game game, char symb) {
			Tuple<int, int> answer;
			answer = EnemyColumn(game, symb);
			if (answer != null) return answer;
			answer = EnemyRow(game, symb);
			if (answer != null) return answer;
			answer = EnemyMainDiag(game, symb);
			if (answer != null) return answer;
			answer = EnemySecondDiag(game, symb);
			if (answer != null) return answer;

			return null;
		}

		public override Tuple<int,int> InventMove(Game game)
		{
			if (0 == game.GetFreeCells().Count)
				return new Tuple<int, int>(-1,-1);
			Tuple<int,int> p;
			p = WinCombo(game, Symbol);
			if (p != null) return p;

			p = Interference(game, Symbol);
			if (p != null) return p;

			if (game.Field[0][0] == game.DefSymbol)
				return new Tuple<int, int>(0, 0);
			if (game.Field[game.Size - 1][game.Size - 1] == game.DefSymbol)
				return new Tuple<int, int>(game.Size - 1, game.Size - 1);
			if (game.Field[0][game.Size - 1] == game.DefSymbol)
				return new Tuple<int, int>(0, game.Size - 1);
			if (game.Field[game.Size - 1][0] == game.DefSymbol)
				return new Tuple<int, int>(game.Size - 1, 0);

			List<Tuple<int,int>> freeCells = game.GetFreeCells();
			if (freeCells.Count != 0)
				return freeCells[r.Next(0,freeCells.Count)];
			else return new Tuple<int, int>(-1, -1);
		}

		public override bool Equals(object obj)
		{
			return obj is Player player &&
				   Name == player.Name &&
				   Symbol == player.Symbol;
		}
		
    }
}
