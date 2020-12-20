using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace LabCSH
{
    public class Game
    {
		char defSymbol;
        public char DefSymbol { get=>defSymbol;}

		int size;
        public int Size { get=>size; }

        public List<List<char>> Field { get; set; }

		List<Player> players;
        public List<Player> Players { get=>players;}

        public Player OrderedPlayer { get; set; }
		
		public double Time { get; set; }
        public Game(List<Player> players, int size = 3, double time =0,char empty = ' ') {
            this.players = players;
            this.size = size;
            defSymbol = empty;
			Field = new List<List<char>>();
			OrderedPlayer = null;
			Time = time;
            for (int x = 0; x < size; x++)
            {
                List<char> A= new List<char>();
                for (int y = 0; y < size; y++)
                    A.Add(DefSymbol);
                Field.Add(A);
            }
        }

        public bool Set(Tuple<int,int> coords, char symb) {
			if (coords.Item1 != -1 && coords.Item2 != -1 && Field[coords.Item1][coords.Item2] != DefSymbol)
				Field[coords.Item1][coords.Item2] = symb;
			else throw new Exception("Wrong coords");

            if (CheckWin(symb))
                return true;
            else
                return false;
        }

        public List<Tuple<int,int>> GetFreeCells() {
            List<Tuple<int,int>> free_cells = new List<Tuple<int,int>>();
            for (int y = 0; y < Size; y++)
                for (int x = 0; x < Size; x++)
                    if (Field[x][y] == DefSymbol)
                        free_cells.Add(new Tuple<int,int>(x, y));
            return free_cells;
        }

		private bool ColumCheck(char symb) {
			for (int x = 0; x < Size; x++) {
				bool marker = false;
				for (int y = 0; y < Size; y++)
				{
					if (Field[x][y] == symb)
						continue;
					else
					{
						marker = true;
						break;
					}
				}
				if (!marker)
					return true;
			}
			return false;
		}

		private bool LineCheck(char symb) {
			for (int y = 0; y < Size; y++) // проверка на строки
			{
				bool marker = false;
				for (int x = 0; x < Size; x++)
				{
					if (Field[x][y] == symb)
						continue;
					else
					{
						marker = true;
						break;
					}
				}
				if (!marker)
					return true;
			}
			return false;
		}

		private bool DiagonalCheck(char symb) {
			bool marker = false;
			for (int y = 0, x = 0; y < Size; y++, x++) //поиск победы на пр¤мой диагонали
			{
				if (Field[x][y] == symb)
					continue;
				else
				{
					marker = true;
					break;
				}
			}
			if (!marker)
				return true;

			marker = false;
			for (int y = 0, x = Size - 1; x >= 0; y++, x--) //поиск победы на обратной диагонали
			{
				if (Field[x][y] == symb)
					continue;
				else
				{
					marker = true;
					break;
				}
			}
			if (!marker)
				return true;

			return false;
		}

        public bool CheckWin(char symb) {
			return ColumCheck(symb) || LineCheck(symb) || DiagonalCheck(symb);
		}

        public void Clear() {
            for (int x = 0; x < Size; x++)
                for (int y = 0; y < Size; y++)
                    Field[x][y] = DefSymbol;
        }
		public string Serialize() {
			return JsonConvert.SerializeObject(this);
		}
		public static Game Deserialize(string json) {
			PlayerConverter playerConverter = new PlayerConverter();


			return JsonConvert.DeserializeObject<Game>(json, playerConverter);

		}
    }
}
