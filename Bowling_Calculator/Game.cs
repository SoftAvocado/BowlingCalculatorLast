using System.Collections.Generic;

namespace Bowling_Calculator
{
    internal class Game
    {
        List<Frame> _results = new List<Frame>();
        static int _frameIdCounter = 1;

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

        void AddAllScores()
        {
            UpdateTotalScoreOfFrame(_frameIdCounter - 1);
            _frameIdCounter++;
        }

        void CreateFrame()
        {
            if ((_results.Count == 0) || (_results[(_results.Count) - 1].IsFrameEnded))
            {
                _results.Add(new Frame());
            }
        }

        public void ThrowBall(int result)
        {
            // create new frame if needed
            int frameId = _frameIdCounter;
            CreateFrame();

            // 1st frame has been started
            if (_frameIdCounter == 1)
            {
                _results[_frameIdCounter - 1].AddResultThrow(result);

                if (_results[_frameIdCounter - 1].IsFrameEnded)
                {
                    AddAllScores();
                }
                else
                {
                    _results[_frameIdCounter - 1].Total = result;
                }
            }
            // 2d frame has been started
            else if (_frameIdCounter == 2)
            {
                AddFrameScoreToFrame(_frameIdCounter - 2, result);
                UpdateTotalScoreOfFrame(_frameIdCounter - 2);
                _results[_frameIdCounter - 1].AddResultThrow(result);


                if (_results[_frameIdCounter - 1].IsFrameEnded)
                {
                    AddAllScores();
                }
                else
                {
                    int previousTotal = _results[_frameIdCounter - 2].Total;
                    _results[_frameIdCounter - 1].Total = previousTotal + result;
                }
            }
            // 3d or more frame has been started
            else if ((_frameIdCounter > 2) && (_frameIdCounter < 10))
            {
                AddFrameScoreToFrame(_frameIdCounter - 3, result);
                AddFrameScoreToFrame(_frameIdCounter - 2, result);
                UpdateTotalScoreOfFrame(_frameIdCounter - 3);
                UpdateTotalScoreOfFrame(_frameIdCounter - 2);
                _results[_frameIdCounter - 1].AddResultThrow(result);

                if (_results[_frameIdCounter - 1].IsFrameEnded)
                {
                    AddAllScores();
                }
                else
                {
                    int previousTotal = _results[_frameIdCounter - 2].Total;
                    _results[_frameIdCounter - 1].Total = previousTotal + result;
                }
            }
            // 10th frame has been started
            else if (_frameIdCounter == 10)
            {
                AddFrameScoreToFrame(_frameIdCounter - 3, result);
                AddFrameScoreToFrame(_frameIdCounter - 2, result);
                UpdateTotalScoreOfFrame(_frameIdCounter - 3);
                UpdateTotalScoreOfFrame(_frameIdCounter - 2);
                _results[_frameIdCounter - 1].IsBonusThrow = true;

                _results[_frameIdCounter - 1].AddResultThrow(result);
                UpdateTotalScoreOfFrame(_frameIdCounter - 1);
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

        public void ReloadFrameIdCounter()
        {
            _frameIdCounter = 1;
        }

    }
}
