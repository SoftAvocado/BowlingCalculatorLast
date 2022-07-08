using System.Collections.Generic;

namespace Bowling_Calculator
{
    public class Calculator
    {
        Game _game;

        public List<int> CalculateThrows(List<int> throws)
        {
            _game = new Game();
            List<int> calculatorResults = new List<int>();

            foreach (int score in throws)
            {
                _game.ThrowBall(score);
                calculatorResults.Add(_game.GetLatestTotalScore());
            }

            return calculatorResults;
        }

        public List<int> GetFrameResults(int frameId)
        {
            return _game.GetFrameResult(frameId);
        }

        public int GetFrameScores(int frameId)
        {
            return _game.GetFrameScore(frameId);
        }

        public int GetFrameTotal(int frameId)
        {
            return _game.GetTotal(frameId);
        }
    }
}
