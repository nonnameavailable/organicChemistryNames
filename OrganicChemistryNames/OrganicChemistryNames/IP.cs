using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace OrganicChemistryNames
{
	static class IP
	{

		public static int clamp(int value, int min, int max)
		{
			return (value < min) ? min : (value > max) ? max : value;
		}

		public static Color negativeColor(Color c)
		{
			return (Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
		}

		public static Color lerpColor(Color c1, Color c2, double amount)
		{
			int newR = (int)(c1.R + (c2.R - c1.R) * amount);
			int newG = (int)(c1.G + (c2.G - c1.G) * amount);
			int newB = (int)(c1.B + (c2.B - c1.B) * amount);
			return Color.FromArgb(newR, newG, newB);
		}

		public static Color contrastColor(Color c)
		{
			if (c.R + c.G + c.B > 382)
			{
				return Color.Black;
			}
			{
				return Color.White;
			}
		}

		public static Font fontToFitRect(string str, double sqWidth, double sqHeight, string fontName)
		{
			float resultSize = (float)(sqHeight);
			Font result = new Font(fontName, resultSize);
			SizeF strSize = TextRenderer.MeasureText(str, result);
			while (strSize.Height > sqHeight * 1.2)
			{
				resultSize *= 0.95F;
				result = new Font(fontName, resultSize);
				strSize = TextRenderer.MeasureText(str, result);
			}
			while (strSize.Width > sqWidth * 1.2)
			{
				resultSize *= 0.95F;
				result = new Font(fontName, resultSize);
				strSize = TextRenderer.MeasureText(str, result);
			}
			return result;
		}

		public static Font fontToFitRectSmaller(string str, double sqWidth, double sqHeight, string fontName)
		{
			float resultSize = (float)(sqHeight);
			Font result = new Font(fontName, resultSize);
			SizeF strSize = TextRenderer.MeasureText(str, result);
			while (strSize.Height > sqHeight * 1.2)
			{
				resultSize *= 0.95F;
				result = new Font(fontName, resultSize);
				strSize = TextRenderer.MeasureText(str, result);
			}
			while (strSize.Width > sqWidth * 1.2)
			{
				resultSize *= 0.95F;
				result = new Font(fontName, resultSize);
				strSize = TextRenderer.MeasureText(str, result);
			}
			resultSize *= 0.5F;
			result = new Font(fontName, resultSize);
			return result;
		}

		public static string arrToString(int[][] arr)
		{
			string result = "";
			for (int j = 0; j < arr.Length; j++)
			{
				result += "[";
				for (int i = 0; i < arr[0].Length; i++)
				{
					int val = arr[j][i];
					result += val + (i == arr[0].Length - 1 ? "]" + System.Environment.NewLine : ", ");
				}
			}
			return result;
		}

		public static int[][] arrCopy(int[][] arr)
		{
			int[][] result = new int[arr.Length][];
			for (int j = 0; j < arr.Length; j++)
			{
				result[j] = new int[arr[0].Length];
				for (int i = 0; i < arr[0].Length; i++)
				{
					result[j][i] = arr[j][i];
				}
			}
			return result;
		}

		public static List<Element> elementListCopy(List<Element> elementList)
        {
			List<Element> result = new List<Element>();
			foreach(Element e in elementList)
            {
				Element ne = new Element(e.X, e.Y, e.Type);
				ne.CarbonChainConnection = e.CarbonChainConnection;
				result.Add(ne);
            }
			return result;
        }

		public static List<Element> invertedElementList(List<Element> elementList)
        {
			List<Element> result = new List<Element>();
			for (int i = elementList.Count - 1; i >= 0; i--)
			{
				Element nC = new Element(elementList[i].X, elementList[i].Y, elementList[i].Type);
				nC.CarbonChainConnection = elementList[i].CarbonChainConnection;
				result.Add(nC);
			}
			return result;
		}
		public static void Increment<T>(this Dictionary<T, int> dictionary, T key)
		{
			int count;
			dictionary.TryGetValue(key, out count);
			dictionary[key] = count + 1;
		}
		public static void AddToList<T>(this Dictionary<T, List<int>> dictionary, T key, int newPosition)
		{
			if (dictionary.TryGetValue(key, out List<int> positions))
			{
				positions.Add(newPosition);
			}
			else
			{
				positions = new List<int> { newPosition };
				dictionary[key] = positions;
			}
		}
		public static void AddToList<T>(this Dictionary<T, List<Element>> dictionary, T key, Element newPosition)
		{
			if (dictionary.TryGetValue(key, out List<Element> positions))
			{
				positions.Add(newPosition);
			}
			else
			{
				positions = new List<Element> { newPosition };
				dictionary[key] = positions;
			}
		}
		public static void AddToList<T>(this Dictionary<T, List<MoleculeNamer>> dictionary, T key, MoleculeNamer newPosition)
		{
			if (dictionary.TryGetValue(key, out List<MoleculeNamer> positions))
			{
				positions.Add(newPosition);
			}
			else
			{
				positions = new List<MoleculeNamer> { newPosition };
				dictionary[key] = positions;
			}
		}

		public static string listToString(List<int> list, string separator)
        {
			string result = "";
			foreach(int o in list)
            {
				result += o.ToString() + separator;
            }
			return result.Substring(0, result.Length - separator.Length);
        }
		public static string listToString(List<Element> list, string separator)
		{
			string result = "";
			if (list.Count == 0) return result;
			foreach (Element e in list)
			{
				result += e.CarbonChainConnection.ToString() + separator;
			}
			return result.Substring(0, result.Length - separator.Length);
		}

		public static string listToString(List<MoleculeNamer> list, string separator)
		{
			string result = "";
			foreach (MoleculeNamer e in list)
			{
				result += e.CarbonChainConnection.ToString() + separator;
			}
			return result.Substring(0, result.Length - separator.Length);
		}
		public static string listToString(List<TypedString> list, string separator)
		{
			string result = "";
			foreach (TypedString e in list)
			{
				result += e.Text + separator;
			}
			return result.Substring(0, result.Length);
		}
		public static void removeLastHyphen(List<TypedString> list)
        {
			if (list.Count == 0) return;
			list.RemoveAll(n => n.Text.Equals(""));
			TypedString lastTs = list.Last();
            if (lastTs.Text.Last().ToString() == "-")
            {
				list[list.Count - 1] = new TypedString(lastTs.Text.Substring(0, lastTs.Text.Length - 1), lastTs.Type);
			}
        }
	}
}