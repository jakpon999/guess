using NUnit.Framework;
using System;
using Assert = NUnit.Framework.Assert;

namespace Guess.UnitTests
{
    [TestFixture]
    public class GuessGameTests
    {
        private GuessGame _guessGame;

        [SetUp]
        public void SetUp()
        {
            _guessGame = new GuessGame(1, 10);
        }

        [Test]
        [TestCase(0, 10)]
        [TestCase(0, 100)]
        [TestCase(-51, 123)]
        [TestCase(-51, 51)]
        [TestCase(0, 0)]
        public void GenerateNumber_WhenCalled_ReturnNumberInGivenRange(int min, int max)
        {
            int result = _guessGame.GenerateNumber(min, max);
            Assert.That(result, Is.EqualTo(_guessGame.number));
            Assert.That(result, Is.GreaterThanOrEqualTo(min));
            Assert.That(result, Is.LessThanOrEqualTo(max));
        }

        [Test]
        [TestCase(10, 5)]
        [TestCase(3, 5)]
        [TestCase(5, 5)]
        [TestCase(-10, -5)]
        [TestCase(-3, -5)]
        [TestCase(-5, -5)]
        public void Guess_WhenCalled_ReturnNumberWithInformationIfGuessWasCorrect(int guess, int number)
        {
            _guessGame.number = number;
            int result = _guessGame.Guess(guess);
            if(guess > number)
            {
                Assert.That(result, Is.EqualTo(1));
            }
            else if(guess < number)
            {
                Assert.That(result, Is.EqualTo(-1));
            }
            else
            {
                Assert.That(result, Is.EqualTo(0));
            }
        }

        [Test]
        [TestCase("123")]
        [TestCase("-56")]
        [TestCase("asdf")]
        public void ReadGuess_WhenCalled_ReturnResultOfConvertion(string guess)
        {
            int result;
            bool success = _guessGame.ReadGuess(guess, out result);

            int temp;
            if (!Int32.TryParse(guess, out temp))
            {
                Assert.That(success, Is.EqualTo(false));
            }
            else
            {
                Assert.That(success, Is.EqualTo(true));
                Assert.That(result, Is.EqualTo(temp));
            }
        }
    }
}
