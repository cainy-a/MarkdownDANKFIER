namespace MarkdownDankifier
{
	public class CatchInfo
	{
		public CatchInfo(char characterToCatch, string characterName, string markdownFunction)
		{
			CharacterToCatch = characterToCatch;
			CharacterName = characterName;
			MarkdownFunction = markdownFunction;
		}

		public char CharacterToCatch;
		public string CharacterName;
		public string MarkdownFunction;
	}
}