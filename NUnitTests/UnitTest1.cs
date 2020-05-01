using System.Collections.Generic;
using MarkdownDankifier;
using NUnit.Framework;
using static MarkdownDankifier.MainClass;

namespace Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}
		[Test]
		public void PlainTextTest()
		{
			Assert.AreEqual("_t_**e**_s_**t**", DankifyText(
				"test"));
		}
		
		[Test]
		public void PlainTextSpacesTest()
		{
			Assert.AreEqual("_t_**e**_s_**t**_s_ **t**_e_**s**_t_**s**", DankifyText(
				"tests tests"));
		}

		[Test]
		public void BasicFormatting()
		{
			Assert.AreEqual(@"_\*_**t**_e_**s**_t_**\***", DankifyText(
				FixMarkdown(
					"*test*", 
					new List<Fixes>
						{Fixes.Asterisk})));
		}
		
		[Test]
		public void BasicFormattingSpaces()
		{
			Assert.AreEqual(@"", DankifyText(
				FixMarkdown(
					"*test* _test_", 
					new List<Fixes>
					{
						Fixes.Asterisk, 
						Fixes.Underscore
					})));
		}

		[Test]
		public void TheWholeMix()
		{
			Assert.AreEqual(
				@"",
				DankifyText(
					FixMarkdown(
						@"## - *test* test _ \`Hello`",
						new List<Fixes>
						{
							Fixes.Asterisk,
							Fixes.Underscore,
							Fixes.Backslash,
							Fixes.Backtick,
							Fixes.Hashtag,
							Fixes.Hyphen
						})));
		}
	}
}