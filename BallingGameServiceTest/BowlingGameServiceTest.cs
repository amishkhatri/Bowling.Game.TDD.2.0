using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace xp.tdd.bowling.game.service.test
{
    public class BowlingGameServiceTest
    {
        #region "Constant"

            public const int ROLL_1 = 1;
            public const int ROLL_2 = 2;
            public const int FRAME_1 = 1;
            public const int FRAME_2 = 2;
            public const int FRAME_3 = 3;
            public const int FRAME_4 = 4;
            public const int FRAME_5 = 5;
            public const int FRAME_6 = 6;
            public const int FRAME_7 = 7;
            public const int FRAME_8 = 8;
            public const int FRAME_9 = 9;
            public const int FRAME_10 = 10;

        #endregion

        private BowlingGame game;

        public BowlingGameServiceTest()
        {
            game = new BowlingGame();
        }

        
        #region "Acceptance Criteria"

        //Acceptance Criteria: (Sprint 1)
        //1.A game should have 10 frames.
        //2.Each frame would have max of 2 rolls to knock down 10 pins.
        //3.The total score of a frame should be sum of pins knocked in 2 rolls plus score till last frame.
        //4.Last frame shows the total score of the game.
        //5. Game should not allow to play game after 10th frame as its end of the game.

        //Acceptance Criteria: (Sprint 2)

        //1.The bonus for Spare frame is the number of pins knocked down by the next one roll.
        //2.The bonus for Strike frame is the number of pins knocked down by next two rolls.
        //3. Assume, there is no spare or strike in 10th frame.

        //4. For double strike, take the consecutive two strikes value and 2 rolls in the next frame.

        #endregion

        [Test]
        public void Should_Return_Pass_When_Play_A_Roll()
        {
            int pinScore = 8;

            game.PlayRoll(pinScore);
            
            Assert.AreEqual(8, game.Score());
        }

        // Sprint 1 AC2 
        [Test]
        public void Should_Return_Pass_When_Play_2_Rolls_With_Score_1()
        {

            BowlingGame _game = new BowlingGame();

            int pinScore = 0;

            _game.PlayRoll(pinScore);
            _game.PlayRoll(pinScore);

            Assert.AreEqual(0, _game.Score());
        }

        [Test]
        public void Should_Return_Pass_When_Play_Rolls_With_No_Score()
        {
            BowlingGame _game = new BowlingGame();

            _game.PlayMulitpleRolls(20, 0);
            Assert.AreEqual(0, _game.Score());

        }

        // Sprint 1 AC 3
        [Test]
        public void Should_Return_Cumulative_Sum_Of_All_Played_Rolls()
        {
            BowlingGame _game = new BowlingGame();

            _game.PlayRoll(8);
            _game.PlayRoll(1);
            _game.PlayRoll(3);
            _game.PlayRoll(6);

            Assert.AreEqual(18, _game.Score());
        }

        // Sprint 1 AC 4
        [Test]
        public void Should_Return_Cumulative_Score_After_All_10_Fame_Played()
        {
            BowlingGame _game = new BowlingGame();

            _game.PlayRoll(8);
            _game.PlayRoll(8);
            _game.PlayRoll(8);
            _game.PlayRoll(8);
            _game.PlayRoll(8);
            _game.PlayRoll(8);
            _game.PlayRoll(8);
            _game.PlayRoll(8);
            _game.PlayRoll(6);
            _game.PlayRoll(5);

            _game.PlayRoll(8);
            _game.PlayRoll(8);
            _game.PlayRoll(8);
            _game.PlayRoll(8);
            _game.PlayRoll(8);
            _game.PlayRoll(8);
            _game.PlayRoll(8);
            _game.PlayRoll(8);
            _game.PlayRoll(6);
            _game.PlayRoll(5);

            Assert.AreEqual(150, _game.Score());
        }


        //Should Identify Spare and return true
        [Test]
        public void Should_Return_Pass_When_Two_Rolls_Score_Is_10_In_One_Frame()
        {
            BowlingGame _game = new BowlingGame();

            _game.PlayRoll(0);
            _game.PlayRoll(10);

            Assert.IsTrue(_game.IsSpareIdentifiedInFrame(0));
        }



        [OneTimeTearDown]
        public void TearDown()
        {
            game = null;
        }



    }
}