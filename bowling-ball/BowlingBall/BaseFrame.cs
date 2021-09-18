using BowlingBall.Interface;
using System.Collections.Generic;
using System.Linq;

namespace BowlingBall
{
    public abstract class BaseFrame: IFrame
    {
        
        protected List<int> RollResults { get; } = new List<int>();
        /// <summary>
        /// registers the roll results inside a frame
        /// </summary>
        /// <param name="pins"></param>
        public virtual void RegisterRoll(int pins)
        {
            RollResults.Add(pins);
        }
        /// <summary>
        /// abstract class for finding to check closure of specific frame
        /// </summary>
        /// <returns></returns>
        public abstract bool IsClosed();
        /// <summary>
        /// gets the score by calculating possible bonus and visiting all possible frames
        /// </summary>
        /// <param name="frameIndex"></param>
        /// <param name="frame"></param>
        /// <returns></returns>
        public abstract int GetScore(int frameIndex, IList<IFrame> frame);
        /// <summary>
        /// evaluates the total sum of pins hit in a frame
        /// </summary>
        /// <returns></returns>
        public int GetPinsSum()
        {
            return RollResults.Sum();
        }
        /// <summary>
        /// gets the pins for a specific rolled index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int GetPinsByRoleIndex(int index)
        {
            return RollResults[index];
        }
    }
}
