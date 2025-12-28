using System;

namespace TerminalEngine.Graphics;

class Terminal
{
	private int _terminalWidth;
	private int _terminalHeight;

	public readonly int Width;
	public readonly int Height; 

	public string borderColor = "";

	public Terminal()
	{
		_terminalWidth = Console.WindowWidth;
		_terminalHeight = Console.WindowHeight;

		Width = _terminalWidth;
		Height = _terminalHeight;
	}
	public Terminal(int width, int height)
	{
		_terminalWidth = Console.WindowWidth;
		_terminalHeight = Console.WindowHeight;

		Width = width;
		Height = height;
	}
	private void DrawBorder()
	{
		if (_terminalWidth < Width || _terminalHeight < Height)
		{
			Console.WriteLine("console too small");
		} else
		{
			int diffX = _terminalWidth - Width;
			int diffY = _terminalHeight - Height;

			int topMargin = diffY / 2;
			int bottomMargin = diffY - topMargin;

			int leftMargin = diffX / 2;
			int rightMargin = diffX - leftMargin;

			for (int i = 0; i<_terminalHeight; i++)
			{
				for (int n = 0; n<_terminalWidth; n++)
				{
				}
			}
		}
	}
}
