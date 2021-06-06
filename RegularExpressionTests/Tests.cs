using NUnit.Framework;

namespace RegularExpressionTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void EmailEmptyString_Fail()
        {
            Assert.IsFalse(RegularExpression.MainWindow.ValidEmail(""));
        }

        [Test]
        public void EmailWithMatchingPattern_Pass()
        {
            Assert.IsTrue(RegularExpression.MainWindow.ValidEmail("asd@asd.asd"));
            Assert.IsTrue(RegularExpression.MainWindow.ValidEmail("asd_asd@asd.asd.asd"));
            Assert.IsTrue(RegularExpression.MainWindow.ValidEmail("Asd@asd.asd"));
            Assert.IsTrue(RegularExpression.MainWindow.ValidEmail("asd.asd@asd.asd"));
        }

        [Test]
        public void EmailWithSpecialChars_Fail()
        {
            Assert.IsFalse(RegularExpression.MainWindow.ValidEmail("asd:asd@asd.asd"));
            Assert.IsFalse(RegularExpression.MainWindow.ValidEmail("asd-asd@asd.asd"));
            Assert.IsFalse(RegularExpression.MainWindow.ValidEmail("asd?asd@asd.asd"));
            Assert.IsFalse(RegularExpression.MainWindow.ValidEmail("asd!asd@asd.asd"));
        }

        [Test]
        public void EmailWithLongDomain_Fail()
        {
            Assert.IsFalse(RegularExpression.MainWindow.ValidEmail("asd@asd.asdd"));
            
        }

        [Test]
        public void EmailWithoutAtSign_Fail()
        {
            Assert.IsFalse(RegularExpression.MainWindow.ValidEmail("asd.asd"));
            Assert.IsFalse(RegularExpression.MainWindow.ValidEmail("asd.asddd"));
            Assert.IsFalse(RegularExpression.MainWindow.ValidEmail("asd.asd.asd"));
        }

        [Test]
        public void EmailFirstOrLastCharSpace_Fail()
        {
            Assert.IsFalse(RegularExpression.MainWindow.ValidEmail(" asd@asd.asd"));
            Assert.IsFalse(RegularExpression.MainWindow.ValidEmail("asd@asd.asd "));
        }
        
        [Test]
        public void NameEmptyString_Fail()
        {
            Assert.IsFalse(RegularExpression.MainWindow.ValidName(""));
        }

        [Test]
        public void NameWithOneChar_Fail()
        {
            Assert.IsFalse(RegularExpression.MainWindow.ValidName("a"));
            Assert.IsFalse(RegularExpression.MainWindow.ValidName(" "));
            Assert.IsFalse(RegularExpression.MainWindow.ValidName("?"));
        }

        [Test]
        public void NameWithMinTwoWordsAndTwoChars_pass()
        {
            Assert.IsTrue(RegularExpression.MainWindow.ValidName("as as"));
            Assert.IsTrue(RegularExpression.MainWindow.ValidName("asd asd"));
            Assert.IsTrue(RegularExpression.MainWindow.ValidName("as as as"));
            Assert.IsTrue(RegularExpression.MainWindow.ValidName("a-s as as"));
        }

        [Test]
        public void NameWithMoreThanThreeWords_Fail()
        {
            Assert.IsFalse(RegularExpression.MainWindow.ValidName("as as as "));
            Assert.IsFalse(RegularExpression.MainWindow.ValidName("as as as -"));
        }

        [Test]
        public void NameWithInvalidChars_Fail()
        {
            Assert.IsFalse(RegularExpression.MainWindow.ValidName("as a-"));
            Assert.IsFalse(RegularExpression.MainWindow.ValidName("as as-"));
        }
        
        [Test]
        public void PhoneEmptyString_Fail()
        {
            Assert.IsFalse(RegularExpression.MainWindow.ValidPhone(""));
        }

        [Test]
        public void PhoneWithCorrectInput_Pass()
        {
            Assert.IsTrue(RegularExpression.MainWindow.ValidPhone("(123) 123-1234"));
        }

        [Test]
        public void PhoneWithNonDigits_Fail()
        {
            Assert.IsFalse(RegularExpression.MainWindow.ValidPhone("(asd) asd-asdd"));
            Assert.IsFalse(RegularExpression.MainWindow.ValidPhone("(123) asd-1234"));
        }

        [Test]
        public void PhoneWithMoreOrLessThenRequiredAmountOfChars_Fail()
        {
            Assert.IsFalse(RegularExpression.MainWindow.ValidPhone("(123) 123-123444"));
            Assert.IsFalse(RegularExpression.MainWindow.ValidPhone("(123) 123-1"));
        }

        [Test]
        public void PhoneWithIncorrectPattern_Fail()
        {
            Assert.IsFalse(RegularExpression.MainWindow.ValidPhone("(123 1)23-1234"));
            Assert.IsFalse(RegularExpression.MainWindow.ValidPhone("123) 1-231234("));
        }
    }
}