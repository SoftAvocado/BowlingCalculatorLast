using System.Collections.Generic;

namespace Bowling_Calculator
{
    internal class Frame
    {
        List<int> _resultThrows = new List<int>();
        List<int> _addedThrows = new List<int>();
        public bool IsFrameEnded { get; private set; }
        public bool IsStrike { get; private set; }
        public bool IsSpare { get; private set; }
        public int FrameScore { get; private set; }
        public int Total { get; set; }
        public bool IsBonusThrow { get; set; }

        public void AddFrameScore(int resultThrow)
        {
            FrameScore += resultThrow;
            _addedThrows.Add(resultThrow);
        }

        public void AddResultThrow(int resultThrow)
        {
            _resultThrows.Add(resultThrow);
            AddFrameScore(resultThrow);
            Total += resultThrow;
            if (IsFrameEnded != false)
            {
                return;
            }
            if ((resultThrow == 10))
            {
                IsStrike = true;
                if (!IsBonusThrow) { }
                IsFrameEnded = true;
            }
            else if (_addedThrows.Count == 2)
            {
                if ((_addedThrows[0] + _addedThrows[1]) == 10)
                {
                    IsSpare = true;
                }
                IsFrameEnded = true;
            }
            // spare or spare bonus
            if ((IsBonusThrow) && (IsSpare|| IsStrike) && (_addedThrows.Count == 3))
            {
                IsFrameEnded = true;
            }
            else if (IsBonusThrow)
            {
                IsFrameEnded = false;
            }
        }

        public List<int> GetResultThrows()
        {
            return _resultThrows;
        }

        public List<int> GetAddedThrows()
        {
            return _addedThrows;
        }
    }
}
