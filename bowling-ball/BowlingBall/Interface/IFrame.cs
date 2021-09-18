using System.Collections.Generic;
namespace BowlingBall.Interface
{
    public interface IFrame
    {

        bool IsClosed();
        void RegisterRoll(int pins);

        int GetPinsSum();

        int GetPinsByRoleIndex(int index);

        int GetScore(int frameIndex,IList<IFrame> frame);


    }
}
