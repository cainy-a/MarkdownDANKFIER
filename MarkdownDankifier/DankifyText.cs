namespace MarkdownDankifier
{
	enum FormatTypes
	{
		Italic,
		Bold
	}

	partial class MainClass
	{
		public static string DankifyText(string input) => FormatString(input);
		public static string FormatString(string input)
		{
			var toReturn = input;
			for (int i = 0; i < toReturn.Length; i++)
			{
				if (toReturn.Substring(i, 1) == " ")
				{
					continue;
				}
				toReturn = toReturn.Insert(i, "_");
				i += 2;
				toReturn = toReturn.Insert(i++, "_");

				toReturn = toReturn.Insert(i, "**");
				i += 3;
				toReturn = toReturn.Insert(i++, "**");
			}
			return toReturn;
		}
	}
}