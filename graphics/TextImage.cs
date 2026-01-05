using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace TerminalEngine.Graphics;

public struct TextImage
{
	public List<string> Lines;
	public int Width;
	public int Height;

	public TextImage(List<string> lines)
	{
		Lines = lines;
		Height = Lines.Count;
		Width = 0;

		for (int i = 0; i<Lines.Count; i++)
		{
			if (Lines[i].Length > Width) Width = Lines[i].Length;
		}
	}
	public TextImage(string path, ContentManager content)
	{
		Lines = new List<string>();
		string filePath = Path.Combine(content.RootDirectory, path);

		using (StreamReader sr = new StreamReader(filePath))
		{
			string line;
			while ((line = sr.ReadLine()) != null)
			{
				Lines.Add(line);
			}
		}

		Height = Lines.Count;
		Width = 0;

		for (int i = 0; i<Lines.Count; i++)
		{
			if (Lines[i].Length > Width) Width = Lines[i].Length;
		}
	}
}
