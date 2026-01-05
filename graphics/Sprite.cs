using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace TerminalEngine.Graphics;

public class Sprite
{
	public TextImage Image;
	public int X;
	public int Y;

	public int Width
	{
		get { return Image.Width; }
	}
	public int Height
	{
		get { return Image.Height; }
	}

	public Sprite(int x, int y, List<string> lines)
	{
		Image = new TextImage(lines);
		X = x;
		Y = y;
	}
	public Sprite(int x, int y, string path, ContentManager content)
	{
		Image = new TextImage(path, content);
		X = x;
		Y = y;
	}
	public Sprite()
	{
		X = 0;
		Y = 0;
	}

	public virtual void Draw(Terminal screen)
	{
		Console.Write("\x1b[1D\x1b[0m");
		for (int i = 0; i<Image.Lines.Count; i++)
		{
			Console.Write($"\x1b[{screen.StartY + Y + i};{screen.StartX + X}H{(Image.Lines[i][0] == '‰' ? "\x1b[0D" : Image.Lines[i][0])}");
			for (int n = 1; n<Image.Lines[i].Length; n++)
			{
				if (Image.Lines[i][n] == '‰')
				{
					Console.Write("\x1b[0D");
				} else
				{
					Console.Write(Image.Lines[i][n]);
				}
			}
		}
	}
}
