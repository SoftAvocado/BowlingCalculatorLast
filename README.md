# BowlingCalculator
This project is a test assignment by Tourmaline Core. It was required to implement the logic of bowling game score calculation and cover all needed cases by unit tests.

Game rules: 
- game consists of 10 frames
- player's goal is to try to knock down 10 pins every frame
- player can throw 1 or 2 balls each game. 1 ball is thrown if player knocked down all 10 pins, otherwise player gets a second throw
- if player knocks down all 10 pins in one throw, it is a strike
- if player knocks down all 10 pins in two throws, it is a spare 
- player gets 1 score for every pin
- every strike frame gets additional scores from 2 following throws 
- every spare frame gets additional scores from 1 following throw
- if 10th frame was a strike, player gets bonus: to throw 2 more balls 
- if 10th frame was a spare, player gets bonus: to throw 1 more ball

Algorithm description:
Object of class Calculator recieves the list of all throws. One by one throws are being passed into ThrowBall method of class Game, that creates the list of frames. Each Frame consists of:
- resultThrows - list of int, collects throws for each frame (1-2 values)
- addedThrows - list of int, collects ordinary and additional throws for each game (2-3 values)
- IsFrameEnded - bool
- IsStrike - bool
- IsSpare - bool
- IsBonusScore - bool
- FrameScore - int, sum of ordinary and additional throws
- Total - int, sum of all trows' scores by the time current fame has ended

CI/CD automated testing is integrated into this project. 
