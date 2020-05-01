namespace MarkdownDankifier
{
	enum FormatTypes
	{
		Italic,
		Bold
	}

	public partial class MainClass
	{
		public static string DankifyText(string input) => FormatString(input);
		public static string FormatString(string input)
		{
			var toReturn = input;
			var startBold = false;
			for (int i = 0; i < toReturn.Length; i++)
			{
				if (startBold)
				{
					startBold = false;
					goto startBold;
				}
				if (toReturn.Substring(i, 1) == " ") continue;
				
				if (i >= toReturn.Length) return toReturn;
				toReturn = toReturn.Insert(i, "_");
				if (toReturn[i+1] == char.Parse("\\")) i++;
				i += 2;
				toReturn = toReturn.Insert(i++, "_");

				if (i < toReturn.Length)
					if (toReturn.Substring(i, 1) == " ")
					{
						startBold = true;
						continue;
					}
				startBold: ;
				if (i >= toReturn.Length) return toReturn;
				toReturn = toReturn.Insert(i, "**");
				if (toReturn[i+1] == char.Parse("\\")) i++;
				i += 3;
				toReturn = toReturn.Insert(i++, "**");
			}
			return toReturn;
		}
	}
}