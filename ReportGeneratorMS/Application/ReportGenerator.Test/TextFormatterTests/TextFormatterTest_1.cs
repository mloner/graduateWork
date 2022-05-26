using NUnit.Framework;


namespace ReportGeneratorTests.TextFormatterTests
{
    public class TextFormatterTest_1
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TextFormatterTest_Normal_Italic_Bold_Colors()
        {
            //new TestSection().FormattedText("abc {b}def{i}g{color=80,80,80}hij{/b}klm{/color}n{/i}");

            // var space = " ";
            // var normalText1 = "Normal text 1";
            // var redBoldText = "@color=249,169,173;bold=true{red bold}";
            // var normalText2 = "normal text 2";
            // var blueBoldText = "@color=111,147,178;italic=true{blue bold}";
            // var normalText3 = "normal text 3";
            // var testString = normalText1 + space +
            //                  redBoldText + space +
            //                  normalText2 + space +
            //                  blueBoldText + space +
            //                  normalText3;
            //
            // //expected
            // var expectedParagraph = new Paragraph();
            // expectedParagraph.AddFormattedText(normalText1 + space);
            // expectedParagraph.AddFormattedText("red bold", new Font() { Color = new Color(249, 169, 173), Bold = true });
            // expectedParagraph.AddFormattedText(space + normalText2 + space);
            // expectedParagraph.AddFormattedText("blue bold", new Font() { Color = new Color(111, 147, 178), Italic = true});
            // expectedParagraph.AddFormattedText(space + normalText3);

            //actual
            //var actualParagraph = (new TestSection().FormattedText(testString));

            // AssertParagraphsAreAqual(expectedParagraph, actualParagraph);
        }
        
        // public void AssertParagraphsAreAqual(Paragraph expectedParagraph, Paragraph actualParagraph)
        // {
        //     Assert.AreEqual(expectedParagraph.Elements.Count, actualParagraph.Elements.Count);
        //
        //     for (int i = 0; i < expectedParagraph.Elements.Count; i++)
        //     {
        //         var excpectedParhEl = expectedParagraph.Elements[i] as FormattedText;
        //         var actualParEl = actualParagraph.Elements[i] as FormattedText;
        //
        //         AssertFormattedTextsAreEqual(excpectedParhEl, actualParEl);
        //     }
        // }
        
        // public void AssertFormattedTextsAreEqual(FormattedText expectedFormattedText, FormattedText actualFormattedText)
        // {
        //     Assert.That(expectedFormattedText.Elements.Count == actualFormattedText.Elements.Count);
        //     for (int i = 0; i < expectedFormattedText.Elements.Count; i++)
        //     {
        //         var expEl = expectedFormattedText.Elements[i] as Text;
        //         var actEl = actualFormattedText.Elements[i] as Text;
        //
        //         Assert.That(expEl.Content.Length == actEl.Content.Length);
        //         Assert.That(expEl.Content == actEl.Content);
        //     }
        //     Assert.That(expectedFormattedText.Elements.Count == actualFormattedText.Elements.Count);
        //     Assert.That(expectedFormattedText.Bold == actualFormattedText.Bold);   
        //     Assert.That(expectedFormattedText.Color == actualFormattedText.Color); 
        //     Assert.That(expectedFormattedText.Italic == actualFormattedText.Italic); 
        //     Assert.That(expectedFormattedText.Size == actualFormattedText.Size); 
        //     Assert.That(expectedFormattedText.Style == actualFormattedText.Style); 
        //     Assert.That(expectedFormattedText.Subscript == actualFormattedText.Subscript); 
        //     Assert.That(expectedFormattedText.Superscript == actualFormattedText.Superscript);
        // }
    }
}