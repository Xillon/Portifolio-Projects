using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Engnine
{
	public enum PocketState
	{
		O,
		X,
		None
	}

	public class Game
	{
		// get input from IO
		public static int Keyreader()
		{
			Console.Write("input Cell number:");
			var Char = Console.ReadKey().KeyChar;  

			if (Char != ' ')
			{
				var inp = (Console.ReadKey().KeyChar);

				return inp;
			}
			else
			{
				Console.WriteLine();
				return -1;

			}

		}

		// push through to game state
		// if valid push GameState output back to I
		// else default IO to invalid entry
		// await input from IO
	}

	public class GameState
	{
		internal PocketState[,] grid;

		internal readonly int gridSize;

		public GameState(PocketState[,] initialGrid)
		{

			this.grid = initialGrid.Clone() as PocketState[,];

			this.gridSize = initialGrid.GetLength(0);
		}

		public GameState(int widthHeight)
		{
			this.grid = new PocketState[widthHeight, widthHeight];
			this.gridSize = widthHeight;
			for (int row = 0; row < widthHeight; row++)
			{
				for (int column = 0; column < widthHeight; column++)
				{
					this.grid[row, column] = PocketState.None;
				}
			}
		}

		public void fillRandomly()
		{
			var rng = new Random();

			for (int row = 0; row < this.gridSize; row++)
			{
				for (int column = 0; column < this.gridSize; column++)
				{
					int randomInt = rng.Next(0, 10);
					switch (randomInt)
					{
						case 0:
							this.grid[row, column] = PocketState.X;
							break;

						case 1:
							this.grid[row, column] = PocketState.O;
							break;

						default:
							this.grid[row, column] = PocketState.None;
							break;

					}

				} 
			}
		}

		class Program
		{
			static void Main(string[] args)
			{
				do
				{
					Console.WriteLine();
					var input = Game.Keyreader();
					Console.WriteLine(input);
				}
				while (Console.ReadKey().Key != ConsoleKey.Escape);
				var nomralInt = 2;
				var ArrayInt = new int[3] { 1, 2, 3 };
				var ArrayInt2d = new int[2, 2] { { 1, 2 }, { 3, 4 } };

				var state1 = new GameState(new PocketState[3, 3]
										{ { PocketState.O, PocketState.None, PocketState.O },
										{ PocketState.None, PocketState.X, PocketState.None },
										{ PocketState.None, PocketState.None, PocketState.X }});

				var State2 = new GameState(5);

				Draw.Game(state1);
				Console.ReadLine();
				Draw.Game(State2);
				Console.ReadLine();

				do
				{
					State2.fillRandomly();
					Draw.Game(State2);
				} while (Console.ReadKey().Key == ConsoleKey.Enter);
				

			}

		}
	}
	public static class Draw
	{
		private static string Cell(PocketState cell_state)
		{
			string symbol;

			switch (cell_state)
			{
				case PocketState.O:
					symbol = "O";
					break;
				case PocketState.X:
					symbol = "X";
					break;
				case PocketState.None:
					default:
					symbol = " ";
					break;
			}
			return string.Format($"   {symbol}  |");
		}
		public static void Game(GameState gameState)
		{
			int size = gameState.gridSize;

			string topRow = " " + string.Concat(Enumerable.Repeat("_______", size));
			string midRows = "|" + string.Concat(Enumerable.Repeat("      |", size));
			string botRows = "|" + string.Concat(Enumerable.Repeat("______|", size));

			string gameStateView = $"{topRow}\n";

			for (int row = 0; row < size; row++)
			{
				gameStateView += midRows + "\n";

				gameStateView += "|";
				for (int column = 0; column < size; column++)
				{
					gameStateView += Draw.Cell(gameState.grid[row, column]);
				}
				gameStateView += "\n" + botRows + "\n";
			}
			Console.SetCursorPosition(0, 0);
			Console.WriteLine(gameStateView);
		}

	}
	
}