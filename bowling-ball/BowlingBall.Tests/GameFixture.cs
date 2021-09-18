using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        private  Game game;
        /// <summary>
        /// method to roll a spare 
        /// </summary>
        private void rollSpare()
        {
            game.Roll(6);
            game.Roll(4);
        }
        /// <summary>
        /// helper methods to Roll and set pins iteratively over the provided number of times for roll
        /// </summary>
        /// <param name="game"></param>
        /// <param name="pins"></param>
        /// <param name="times"></param>
        private void Roll(Game game, int pins, int times)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }
        /// <summary>
        /// helper methods that take game and array of pins and iterates over the pin to assign it to each of the element
        /// </summary>
        /// <param name="game"></param>
        /// <param name="pins"></param>
        private void Roll(Game game, int[] pins)
        {
            for (int i = 0; i < pins.Length; i++)
            {
                game.Roll(pins[i]);
            }
        }

        [TestInitialize]
        public void Setup()
        {
            game = new Game();
        }
        /// <summary>
        /// To test the scenario of a gutter game where all pins in roll is 0
        /// </summary>
        [TestMethod]
        public void GutterGameTest()
        {
           
            Roll(game, 0, 20);
            Assert.AreEqual(0, game.GetScore());
        }

        /// <summary>
        /// test if no bonus is applied such that all the rolls are 1
        /// </summary>
        [TestMethod]
        public void TestAllOnes()
        {
            Roll(game,20, 1);
            Assert.AreEqual(20, game.GetScore());
        }
        /// <summary>
        /// test to verify single Spare score calculation
        /// </summary>
        [TestMethod]
        public void TestOneSpare()
        {
            rollSpare();
            game.Roll(4);
            Roll(game,17, 0);
            Assert.AreEqual(18, game.GetScore());
        }
        /// <summary>
        /// Test to test score of a single strike
        /// </summary>

        [TestMethod]
        public void TestOneStrike()
        {
            game.Roll(10);
            game.Roll(4);
            game.Roll(5);
            Roll(game,17, 0);
            Assert.AreEqual(28, game.GetScore());
        }

        /// <summary>
        /// test case for all strike hit 
        /// </summary>
        [TestMethod]
        public void TestPerfectGame()
        {
            Roll(game,10, 12);
            Assert.AreEqual(300, game.GetScore());
        }
        /// <summary>
        /// test case such that the final frame is neither a strike nor a spare
        /// </summary>
        [TestMethod]
        public void TestRandomGameNoExtraRoll()
        {
            Roll(game,new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 });
            Assert.AreEqual(131, game.GetScore());
        }
        /// <summary>
        /// test with spares and strike at the end
        /// </summary>
        [TestMethod]
        public void TestRandomGameWithSpareThenStrikeAtEnd()
        {
            Roll(game,new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 1, 10 });
            Assert.AreEqual(143, game.GetScore());
        }
        /// <summary>
        /// test to calculate three strike at the end 
        /// </summary>
        [TestMethod]
        public void TestRandomGameWithThreeStrikesAtEnd()
        {
            Roll(game,new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 10, 10, 10 });
            Assert.AreEqual(163, game.GetScore());
        }
        /// <summary>
        /// random game test with three strike in beteen to calculate the bonus
        /// </summary>
        [TestMethod]
        public void TestRandomGameWithThreeStrikesInBetween()
        {
            Roll(game,new int[] { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9,1,10 });
            Assert.AreEqual(187, game.GetScore());
        }

     }
}
