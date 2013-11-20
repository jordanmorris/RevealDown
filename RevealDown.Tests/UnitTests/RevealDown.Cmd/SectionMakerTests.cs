using System;
using NUnit.Framework;
using RevealDown.Cmd;

namespace RevealDown.Tests.UnitTests.RevealDown.Cmd
{
    [TestFixture]
    public class SectionMakerTests
    {
        private const string TestMarkdownHtml = @"<!DOCTYPE html>
<html>
<head>
  <meta charset=""utf-8"">
  <meta name=""generator"" content=""pandoc"">
  <meta name=""viewport"" content=""width=device-width, initial-scale=1.0, user-scalable=yes"">
  <title></title>
  <style type=""text/css"">code{white-space: pre;}</style>
  <!--[if lt IE 9]>
    <script src=""http://html5shim.googlecode.com/svn/trunk/html5.js""></script>
  <![endif]-->
</head>
<body>
<h1 id=""in-the-morning"">In the morning</h1>
<p>Fried fish.</p>
<h2 id=""getting-up"">Getting up</h2>
<ul>
<li>Turn off alarm</li>
<li>Get out of bed</li>
</ul>
<h2 id=""breakfast"">Breakfast</h2>
<ul>
<li>Eat eggs</li>
<li>Drink coffee</li>
</ul>
<h1 id=""in-the-evening"">In the evening</h1>
<h2 id=""dinner"">Dinner</h2>
<ul>
<li>Eat spaghetti</li>
<li>Drink wine</li>
</ul>
</body>
</html>
";


        [Test]
        [Ignore("Test not fully implemented, so only useful for manual inspection/debugging")]
        public void GetSections_puts_sections_in_expected_places()
        {
            //arrange
            var sectionMaker = new SectionMaker();

            //act
            var sections = sectionMaker.GetSections(TestMarkdownHtml.Split(new[] { Environment.NewLine }, StringSplitOptions.None));

            //assert
            //breakpoint here
            Assert.Pass();
        }
    }
}
