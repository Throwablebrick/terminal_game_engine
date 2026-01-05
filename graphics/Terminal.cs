using System;

namespace TerminalEngine.Graphics;

class Terminal
{
	private int _prevWidth;
	private int _prevHeight;
	private int _terminalWidth;
	private int _terminalHeight;

	public readonly int Width;
	public readonly int Height; 
	public int StartX;
	public int StartY;

	public string borderColor = $"\x1b[38;5;15m\x1b[48;5;70m";
	public string backgroundColor = "\x1b[38;5;16m\x1b[48;5;16m";
	public string screenColor = "\x1b[39m\x1b[49m";

	public char backgroundChar = '#';
	public char borderSidesChar = '|';
	public char borderHorizontalChar = '-';
	public char screenChar = ' ';

	public char cornerTopLeft = '┌';
	public char cornerTopRight = '┐';
	public char cornerBottomLeft = '└';
	public char cornerBottomRight = '┘';

	public Terminal()
	{
		_terminalWidth = Console.WindowWidth;
		_terminalHeight = Console.WindowHeight;
		_prevWidth = _terminalWidth;
		_prevHeight = _terminalHeight;

		Width = _terminalWidth;
		Height = _terminalHeight;
	}
	public Terminal(int width, int height)
	{
		_terminalWidth = Console.WindowWidth;
		_terminalHeight = Console.WindowHeight;
		_prevWidth = _terminalWidth;
		_prevHeight = _terminalHeight;

		Width = width;
		Height = height;
	}

	public void Update()
	{
		_prevWidth = _terminalWidth;
		_prevHeight = _terminalHeight;
		_terminalWidth = Console.WindowWidth;
		_terminalHeight = Console.WindowHeight;
		if (_prevWidth != _terminalWidth || _prevHeight != _terminalHeight)
		{
			DrawBorder();
		}
	}

	public void DrawBorder()
	{
		Console.Write("\x1b[H");
		if (_terminalWidth < Width || _terminalHeight < Height)
		{
			Console.WriteLine("console too small");
		} else
		{
			int diffX = _terminalWidth - Width;
			int diffY = _terminalHeight - Height;

			int topMargin = diffY / 2;
			StartY = topMargin + 1;
			int bottomMargin = diffY - topMargin;
			bottomMargin = _terminalHeight - bottomMargin;
			topMargin -= 1;

			int leftMargin = diffX / 2;
			StartX = leftMargin + 1;
			int rightMargin = diffX - leftMargin;
			rightMargin = _terminalWidth - rightMargin;
			leftMargin -= 1;

			//Console.WriteLine($"width {_terminalWidth} height {_terminalHeight}");
			//Console.WriteLine($"topMargin {topMargin} bottomMargin {bottomMargin}");
			//Console.WriteLine($"leftMargin {leftMargin} rightMargin {rightMargin}");

			for (int i = 0; i<_terminalHeight; i++)
			{
				for (int n = 0; n<_terminalWidth; n++)
				{
					if (i < topMargin || i > bottomMargin)
					{
						if (n == 0)
						{
							Console.Write($"{backgroundColor}{backgroundChar}");
						} else if (n == _terminalWidth - 1)
						{
							if (i != _terminalHeight - 1)
							{
								Console.WriteLine($"{backgroundChar}");
							}else
							{
								Console.Write($"{backgroundChar}");
							}
						} else
						{
							Console.Write($"{backgroundChar}");
						}
					}else if (i == topMargin || i == bottomMargin)
					{
						if (n < leftMargin || n > rightMargin)
						{
							if (n == 0)
							{
								Console.Write($"{backgroundColor}{backgroundChar}");
							} else if (n == _terminalWidth - 1)
							{
								Console.WriteLine($"{backgroundChar}");
							} else
							{
								Console.Write($"{backgroundChar}");
							}
						} else if (n == leftMargin)
						{
							if (i == topMargin)
							{
								Console.Write($"{borderColor}{cornerTopLeft}");
							}else
							{
								Console.Write($"{borderColor}{cornerBottomLeft}");
							}
						}else if (n == rightMargin)
						{
							if (i == topMargin)
							{
								Console.Write($"{cornerTopRight}{backgroundColor}");
							}else
							{
								Console.Write($"{cornerBottomRight}{backgroundColor}");
							}
						} else
						{
							Console.Write($"{borderHorizontalChar}");
						}
					} else
					{
						if (n < leftMargin || n > rightMargin)
						{
							if (n == 0)
							{
								Console.Write($"{backgroundColor}{backgroundChar}");
							} else if (n == _terminalWidth)
							{
								Console.WriteLine($"{backgroundChar}");
							} else
							{
								Console.Write($"{backgroundChar}");
							}
						} else if (n == leftMargin || n == rightMargin)
						{
							Console.Write($"{borderColor}|{backgroundColor}");
						}else if (n == leftMargin + 1)
						{
							Console.Write($"{screenColor}{screenChar}");
						}else
						{
							Console.Write($"{screenChar}");
						}
					}
				}
			}
		}
	}
}
