using BowlingBall.ApplicationConstants;
using System.Collections.Generic;
using System.Linq;


namespace BowlingBall.Interface
{
    internal class Frame :BaseFrame, IBonusFrame
    {
        
        /// <summary>
        /// Number of pins that each Frame should start with
        /// </summary>
        private int standingPins;
        public Frame()
        {
            standingPins = FrameConstants.MaxPinsInFrame;
        }
        /// <summary>
        /// checks if the frame is closed 
        /// </summary>
        /// <returns></returns>
        public override bool IsClosed()
        {
            return standingPins == 0 || RollResults.Count == FrameConstants.MaxRollsInFrame;
        }
        /// <summary>
        /// it registers the pins taken down in a role and maintains the active count of standing pins
        /// </summary>
        /// <param name="pins"></param>
        public override void RegisterRoll(int pins)
        {
            base.RegisterRoll(pins);
            standingPins -= pins;
        }
        /// <summary>
        /// checks if the roll results is of the strike type
        /// </summary>
        /// <returns></returns>
        public bool isStrike()
        {
            return RollResults.First() == FrameConstants.MaxPinsInFrame;
        }
        /// <summary>
        /// checks if the type is of spare
        /// </summary>
        /// <returns></returns>
        public bool isSpare()
        {
            if (RollResults.Count != FrameConstants.MaxRollsInFrame)
                return false;
            return RollResults.Sum() == FrameConstants.MaxPinsInFrame;
        }
        /// <summary>
        /// Calcualtes the Bonus for a spare roll
        /// </summary>
        /// <param name="nextFrame"></param>
        /// <returns></returns>
        private int CalculateSpareBonus(IFrame nextFrame)
        {
            return nextFrame.GetPinsByRoleIndex((int)RollAttemptsEnum.FirstAttempt);
          
        }
        /// <summary>
        /// calculates the bonus if frame is strike 
        /// connditionally checks if the next frame is final frame or is again a strike
        /// </summary>
        /// <param name="frameIndex"></param>
        /// <param name="frames"></param>
        /// <returns></returns>
        private int CalculateStrikeBonus(int frameIndex,IList<IFrame> frames)
        {

            if (frames[frameIndex + 1].GetType() == typeof(FinalFrame))
            {
                return frames[frameIndex + 1].GetPinsByRoleIndex((int)RollAttemptsEnum.FirstAttempt) + frames[frameIndex + 1].GetPinsByRoleIndex((int)RollAttemptsEnum.SecondAttempt);
            }
            else
            {
               var nextFrame = frames[frameIndex + 1] as Frame;
                if (nextFrame.isStrike())
                    return frames[frameIndex + 1].GetPinsByRoleIndex((int)RollAttemptsEnum.FirstAttempt) + frames[frameIndex + 2].GetPinsByRoleIndex((int)RollAttemptsEnum.FirstAttempt);

                return frames[frameIndex + 1].GetPinsSum();

            }

        }
        /// <summary>
        /// Calculates the Score of the frame
        /// </summary>
        /// <param name="frameIndex"></param>
        /// <param name="frames"></param>
        /// <returns></returns>
        public override int GetScore(int frameIndex, IList<IFrame> frames)
        {
            int score = 0;
            var frame = frames[frameIndex] as Frame;
            if (frame.isSpare())
                score += FrameConstants.MaxPinsInFrame + CalculateSpareBonus(frames[frameIndex + 1]);

            else if (frame.isStrike())
                score += FrameConstants.MaxPinsInFrame + CalculateStrikeBonus(frameIndex, frames);
            else
                score += frames[frameIndex].GetPinsSum();
            return score;
        }
    }
}
