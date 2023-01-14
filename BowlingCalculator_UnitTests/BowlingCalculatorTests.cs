using Bowling_Calculator;
using NUnit.Framework;
using System.Collections.Generic;

namespace BowlingCalculator.Tests
{
    public class Tests
    {
        [Test]
        public void calculate_Throws_standartThrows_lastThrowIsSpare()
        {
            var throws = new List<int>() { 10, 7, 3, 7, 2, 9, 1, 10, 10, 10, 2, 3, 6, 4, 7, 3, 3 };
            var expexted_result = new List<int>() { 10, 24, 30, 44, 46, 55, 56, 76, 96, 126, 132, 138, 144, 148, 162, 165, 168 };

            var calc = new Calculator();
            var actual_result = calc.CalculateThrows(throws);

            CollectionAssert.AreEqual(expexted_result, actual_result);
        }

        [Test]
        public void calculate_Throws_standartThrows_lastThrowNoBonus()
        {
            var throws = new List<int>() { 10, 7, 3, 7, 2, 9, 1, 10, 10, 10, 2, 3, 6, 4, 7, 2 };
            var expexted_result = new List<int>() { 10, 24, 30, 44, 46, 55, 56, 76, 96, 126, 132, 138, 144, 148, 162, 164 };

            var calc = new Calculator();
            var actual_result = calc.CalculateThrows(throws);

            CollectionAssert.AreEqual(expexted_result, actual_result);
        }

        [Test]
        public void calculate_Throws_perfectThrows()
        {
            var throws = new List<int>() { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            var expexted_result = new List<int>() { 10, 30, 60, 90, 120, 150, 180, 210, 240, 270, 290, 300 };

            var calc = new Calculator();
            var actual_result = calc.CalculateThrows(throws);

            CollectionAssert.AreEqual(expexted_result, actual_result);
        }

        [Test]
        public void calculate_Throws_otherTrows_lastThrowIsStrike()
        {
            var throws = new List<int>() { 2, 1, 9, 1, 10, 5, 5, 10, 4, 6, 6, 2, 7, 3, 10, 10, 10, 10 };
            var expexted_result = new List<int>() { 2, 3, 12, 13, 33, 43, 53, 73, 81, 93, 105, 107, 114, 117, 137, 157, 177, 187 };

            var calc = new Calculator();
            var actual_result = calc.CalculateThrows(throws);

            CollectionAssert.AreEqual(expexted_result, actual_result);
        }

        [Test]
        public void get_FrameResults_FromStandardThrowsFrame()
        {
            var throws = new List<int>() { 10, 7, 3, 7, 2, 9, 1, 10, 10, 10, 2, 3, 6, 4, 7, 3, 3 };
            var frame_id = 2;
            var expexted_result = new List<int>() { 7, 3 };

            var calc = new Calculator();
            calc.CalculateThrows(throws);
            var actual_result = calc.GetFrameResults(frame_id);

            CollectionAssert.AreEqual(expexted_result, actual_result);
        }

        [Test]
        public void get_FrameScores_FromStandardThrowsFrame()
        {
            var throws = new List<int>() { 10, 7, 3, 7, 2, 9, 1, 10, 10, 10, 2, 3, 6, 4, 7, 3, 3 };
            var frame_id = 2;
            var expexted_result = 17;

            var calc = new Calculator();
            calc.CalculateThrows(throws);
            var actual_result = calc.GetFrameScores(frame_id);

            Assert.AreEqual(expexted_result, actual_result);
        }

        [Test]
        public void get_FrameTotal_FromStandardThrowsFrame()
        {
            var throws = new List<int>() { 10, 7, 3, 7, 2, 9, 1, 10, 10, 10, 2, 3, 6, 4, 7, 3, 3 };
            var frame_id = 2;
            var expexted_result = 37;

            var calc = new Calculator();
            calc.CalculateThrows(throws);
            var actual_result = calc.GetFrameTotal(frame_id);

            Assert.AreEqual(expexted_result, actual_result);
        }
    }
}