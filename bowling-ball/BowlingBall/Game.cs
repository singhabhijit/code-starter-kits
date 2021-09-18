using BowlingBall.Interface;
using System.Collections.Generic;
using System.Linq;

namespace BowlingBall
{
    public class Game
    {
        private readonly List<IFrame> frames = new List<IFrame>();

        /// <summary>
        /// allocartes the pins to roll to existing frame and new frames
        /// </summary>
        /// <param name="pins"></param>
        public void Roll(int pins)
        {
          
            if (!frames.Any() || frames.Last().IsClosed())
            {
                frames.Add(FrameFactory.GetFrame(frames.Count));
            }

            frames.Last().RegisterRoll(pins);
        }
        /// <summary>
        /// The get score methods aggregates sum of individual frame
        /// </summary>
        /// <returns></returns>
        public int GetScore()
        {

            int score = 0;

            for (var frameIndex = 0; frameIndex < frames.Count; frameIndex++)
            {

               score += frames[frameIndex].GetScore(frameIndex, this.frames);

            }
            return score;
        }


    }
}
