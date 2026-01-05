using TerminalEngine.Graphics;
using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;


namespace terminal_game_engine;

class Program
{
    static void Main(string[] args)
    {
		int FPS = 60;
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		double targetFrameTime = 1000.0 / FPS;
		double elapsedMiliseconds;
		double remainingMiliseconds;

		GameServiceContainer service = new GameServiceContainer();
		ContentManager Content = new ContentManager(service, "Content");

		Sprite box = new Sprite(5, 5, "Sprites/plat1.txt", Content);
		Terminal t = new Terminal(100,40);

		Console.Write("\x1b[?25l\x1b[2J");
		t.DrawBorder();

		bool running = true;
		while(running)
		{
			if (Console.KeyAvailable)
			{
				ConsoleKeyInfo key = Console.ReadKey(true);
				if (key.Key == ConsoleKey.Escape)
				{
					running = false;
				} else if (key.Key == ConsoleKey.RightArrow)
				{
					box.X += 1;
				}
			}
			t.Update();
			t.RefreshScreen();
			box.Draw(t);

			elapsedMiliseconds = stopwatch.Elapsed.TotalMilliseconds;
			remainingMiliseconds = targetFrameTime - elapsedMiliseconds;
			if (remainingMiliseconds > 0)
			{
				Thread.Sleep((int)remainingMiliseconds);
			}
			stopwatch.Restart();
		}
		Console.Write("\x1b[?25h\x1b[2J\x1b[H");
    }
}
