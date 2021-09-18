using BowlingBall.ApplicationConstants;
using System.Collections.Generic;
using System.Linq;
namespace BowlingBall.Interface
{
    internal class FinalFrame : BaseFrame
    {


        public override int GetScore(int frameIndex, IList<IFrame> frame)
        {
            return GetPinsSum();
        }

        /// <summary>
        /// No more rolls can be registered on a closed Frame
        /// it is closed in scenarios such that the rollresult is completely filled or the role result is not a spare in first two attempts
        /// </summary>
        public override bool  IsClosed()
        {
            return RollResults.Count == FrameConstants.MaxRollsInFinalFrame || (RollResults.Sum() < FrameConstants.MaxPinsInFrame && RollResults.Count == FrameConstants.MaxRollsInFinalFrame - 1);
        }
      
    }
}
