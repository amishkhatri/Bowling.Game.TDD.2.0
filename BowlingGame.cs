using System.Collections.Generic;
using System.Linq;

namespace xp.tdd.bowling.game.service
{

    public class BowlingGame
    {

        #region Properties

        private  int[] Rolls = new int[GameConfiguration.MAX_NO_ROLL_LIMIT+1];
        private int IndexRoll = 0;
        
        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        #endregion

        #region Methods
        public int CurrentFrameNumber()
        {
            return IndexRoll % 2 > 0 ? (IndexRoll / 2) + 1 : IndexRoll / 2;
        }

               
        public void PlayRoll(int pinscore)
        {
            Rolls[IndexRoll++] = pinscore;
        }

        
        public bool IsSpareIdentifiedInFrame(int RollPosition)
        {
            bool result = false;
            result = (Rolls[RollPosition] + Rolls[RollPosition + 1]) == 10;

            return result;
        }
        
        public int Score()
        { 
            int score = 0;

            for (int i = 0; i < Rolls.Length; i++)
            {
                score += Rolls[i];
            }

            return score;
        }


        public void PlayMulitpleRolls(int totalrolls, int knockpins)
        {

            for (int i = 0; i < totalrolls; i++)
            {
                PlayRoll(knockpins);
            }

        }




        #endregion

    }
}