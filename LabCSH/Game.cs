using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace LabCSH
{
    public class Game
    {
        public char DefSymbol { get; set; }

        public int Size { get; set; }

        public List<List<char>> Field { get; set; }

        public List<Player> Players { get; set; }

        public Player OrderedPlayer { get; set; }
		
		public double Time { get; set; }
        public Game(List<Player> players, int size = 3, double time =0,char empty = ' ') {
            Players = players;
            Size = size;
            DefSymbol = empty;
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

        public bool Set(Pair coords, char symb) {
            if ((int)coords.First!= -1 && (int)coords.Second != -1)
               Field[(int)coords.First][(int)coords.Second] = symb;

            if (CheckWin(symb))
                return true;
            else
                return false;
        }

        public List<Pair> GetFreeCells() {
            List<Pair> free_cells = new List<Pair>();
            for (int y = 0; y < Size; y++)
                for (int x = 0; x < Size; x++)
                    if (Field[x][y] == DefSymbol)
                        free_cells.Add(new Pair(x, y));
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
			int marker = 0;
			marker += Convert.ToInt32(ColumCheck(symb));
			marker += Convert.ToInt32(LineCheck(symb));
			marker += Convert.ToInt32(DiagonalCheck(symb));
			return marker>0 ?true : false;
		}

        public void Clear() {
            for (int x = 0; x < Size; x++)
                for (int y = 0; y < Size; y++)
                    Field[x][y] = DefSymbol;
        }
		// public void GenerateField(int size)

		public string Serialize() {
			return JsonConvert.SerializeObject(this);
		}
		public static Game Deserialize(string json) {
			PlayerConverter playerConverter = new PlayerConverter();


			return JsonConvert.DeserializeObject<Game>(json, playerConverter);

		}
    }
}
