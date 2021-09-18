using BowlingBall.ApplicationConstants;
using BowlingBall.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class FrameFactory
    {
        /// <summary>
        /// Factoory to check the frame count if is 
        /// </summary>
        /// <param name="frameCount"></param>
        /// <returns></returns>
        public static IFrame GetFrame(int frameCount)
        {

            switch (frameCount)
            {
                case FrameConstants.MaximumFramesInGame-1: return new FinalFrame();
                default:
                    return new Frame();
            }
        }
    }
}
