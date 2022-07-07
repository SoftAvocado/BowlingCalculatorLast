using System.Collections.Generic;

namespace Bowling_Calculator
{
    internal class Game
    {
        List<Frame> _results = new List<Frame>();

        void AddFrameScoreToFrame(int frameId, int result)
        {
            if ((_results[frameId].IsStrike || _results[frameId].IsSpare)
                && (_results[frameId].GetAddedThrows().Count < 3))
            {
                _results[frameId].AddFrameScore(result);
            }
        }

        void UpdateTotalScoreOfFrame(int frameId)
        {
            if (frameId + 1 == 1)
            {
                _results[frameId].Total = _results[frameId].FrameScore;
            }
            else
            {
                _results[frameId].Total = _results[frameId - 1].Total + _results[frameId].FrameScore;
            }
        }

        int DefineCurrentFrame()
        {
            int frameId;
            if ((_results.Count == 0)||(_results[(_results.Count) - 1].IsFrameEnded))
            {
                frameId = _results.Count;
                _results.Add(new Frame());
            }
            else
            {
                frameId = _results.Count-1;
            }
            return frameId;
        }

        public void ThrowBall(int result)
        {
            // create new frame if needed
            int frameId = DefineCurrentFrame();

            // 1st frame has been started
            if (frameId == 0)
            {
                _results[frameId].AddResultThrow(result);

                if (_results[frameId].IsFrameEnded)
                {
                    UpdateTotalScoreOfFrame(frameId);
                }
                else
                {
                    _results[frameId].Total = result;
                }
            }
            // 2d frame has been started
            else if (frameId == 1)
            {
                AddFrameScoreToFrame(frameId - 1, result);
                UpdateTotalScoreOfFrame(frameId - 1);
                _results[frameId].AddResultThrow(result);


                if (_results[frameId].IsFrameEnded)
                {
                    UpdateTotalScoreOfFrame(frameId);
                }
                else
                {
                    int previousTotal = _results[frameId - 1].Total;
                    _results[frameId].Total = previousTotal + result;
                }
            }
            // 3d or more frame has been started
            else if ((frameId > 1) && (frameId < 9))
            {
                AddFrameScoreToFrame(frameId - 2, result);
                AddFrameScoreToFrame(frameId - 1, result);
                UpdateTotalScoreOfFrame(frameId - 2);
                UpdateTotalScoreOfFrame(frameId - 1);
                _results[frameId].AddResultThrow(result);

                if (_results[frameId].IsFrameEnded)
                {
                    UpdateTotalScoreOfFrame(frameId);
                }
                else
                {
                    int previousTotal = _results[frameId - 1].Total;
                    _results[frameId].Total = previousTotal + result;
                }
            }
            // 10th frame has been started
            else if (frameId == 9)
            {
                AddFrameScoreToFrame(frameId - 2, result);
                AddFrameScoreToFrame(frameId - 1, result);
                UpdateTotalScoreOfFrame(frameId - 2);
                UpdateTotalScoreOfFrame(frameId - 1);
                _results[frameId].IsBonusThrow = true;

                _results[frameId].AddResultThrow(result);
                UpdateTotalScoreOfFrame(frameId);
            }
        }

        public List<int> GetFrameResult(int frameId)
        {
            return _results[frameId - 1].GetResultThrows();
        }

        public int GetFrameScore(int frameId)
        {
            return _results[frameId - 1].FrameScore;
        }

        public int GetTotal(int frameId)
        {
            return _results[frameId - 1].Total;
        }

        public int GetLatestTotalScore()
        {
            return _results[_results.Count - 1].Total;
        }

    }
}
