using TerminalEngine.Graphics;
using TerminalEngine.Input;
using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;


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
		InputManager input = new InputManager();

		Sprite box = new Sprite(5, 5, "Sprites/plat1.txt", Content);

		Terminal t = new Terminal(100,40);
		Console.Write("\x1b[?25l");
		Console.Clear();
		t.DrawBorder();

		bool running = true;
		while(running)
		{
			input.Update();
			if (input.Keyboard.WasKeyJustPressed(Keys.Q))
			{
				running = false;
			}
			t.Update();
			box.Draw(t.StartX, t.StartY);

			elapsedMiliseconds = stopwatch.Elapsed.TotalMilliseconds;
			remainingMiliseconds = targetFrameTime - elapsedMiliseconds;
			if (remainingMiliseconds > 0)
			{
				Thread.Sleep((int)remainingMiliseconds);
			}
			stopwatch.Restart();
		}
		Console.Write("\x1b[?25h");
    }
}
