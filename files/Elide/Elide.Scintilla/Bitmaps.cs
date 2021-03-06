﻿using System;
using System.Drawing;
using Elide.Scintilla.Images;

namespace Elide.Scintilla
{
    internal static class Bitmaps
	{
        public static Image Load(string key)
        {
            return Load(typeof(NS), key);
        }

		public static Image Load<T>(string key)
		{
			return Load(typeof(T), key);
		}
				
		public static Image Load(Type type, string key)
		{
			var name = key.IndexOf('.') != -1 ? key : key + ".bmp";
			var bmp = (Bitmap)Bitmap.FromStream(type.Assembly.GetManifestResourceStream(
				type.Namespace + "." + name));
			bmp.MakeTransparent(Color.Magenta);
			return bmp;
		}
	}
}
