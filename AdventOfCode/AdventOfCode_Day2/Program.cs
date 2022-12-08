var input = await File.ReadAllLinesAsync("input.txt");

var totalPoints = 0;

Console.WriteLine(PartOne());
Console.WriteLine(PartTwo());

int PartOne()
{
    foreach (var round in input)
    {
        var roundChoices = round.Split();

        var opponentChoice = roundChoices[0];
        var playerChoice = roundChoices[1];

        totalPoints += FindPointsForChoice(playerChoice) + FindPointsForRoundOutcome(playerChoice, opponentChoice);
    }

    return totalPoints;
}

int PartTwo()
{
    foreach (var round in input)
    {
        var roundChoices = round.Split();

        var opponentChoice = roundChoices[0];
        var expectedRoundOutcome = roundChoices[1];

        var playerChoice = GetChoiceForExpectedOutcome(opponentChoice, expectedRoundOutcome);

        totalPoints += FindPointsForChoice(playerChoice) + FindPointsForRoundOutcome(playerChoice, opponentChoice);
    }

    return totalPoints;
}

string GetChoiceForExpectedOutcome(string opponentChoice, string expectedRoundOutcome)
{
    switch (expectedRoundOutcome)
    {
        case ExpectedRoundOutcomes.Win:
            if (opponentChoice == OpponentChoices.Rock) return PlayerChoices.Paper;
            if (opponentChoice == OpponentChoices.Paper) return PlayerChoices.Scissors;
            if (opponentChoice == OpponentChoices.Scissors) return PlayerChoices.Rock;
            break;
        case ExpectedRoundOutcomes.Draw:
            if (opponentChoice == OpponentChoices.Rock) return PlayerChoices.Rock;
            if (opponentChoice == OpponentChoices.Paper) return PlayerChoices.Paper;
            if (opponentChoice == OpponentChoices.Scissors) return PlayerChoices.Scissors;
            break;
        case ExpectedRoundOutcomes.Lose:
            if (opponentChoice == OpponentChoices.Rock) return PlayerChoices.Scissors;
            if (opponentChoice == OpponentChoices.Paper) return PlayerChoices.Rock;
            if (opponentChoice == OpponentChoices.Scissors) return PlayerChoices.Paper;
            break;
    }

    throw new ArgumentOutOfRangeException();
}

int FindPointsForChoice(string choice)
{
    switch (choice)
    {
        case PlayerChoices.Rock:
            return 1;
        case PlayerChoices.Paper:
            return 2;
        case PlayerChoices.Scissors:
            return 3;
        default:
            return 0;
    }
}

int FindPointsForRoundOutcome(string playerChoice, string opponentChoice)
{
    var outcome = RoundOutcome(playerChoice, opponentChoice);
    return outcome == RoundOutcomes.Win ? 6 : outcome == RoundOutcomes.Draw ? 3 : 0;
}

RoundOutcomes RoundOutcome(string playerChoice, string opponentChoice)
{
    if ((playerChoice == PlayerChoices.Rock && opponentChoice == OpponentChoices.Paper)
        || (playerChoice == PlayerChoices.Paper && opponentChoice == OpponentChoices.Scissors)
        || (playerChoice == PlayerChoices.Scissors && opponentChoice == OpponentChoices.Rock))
    {
        return RoundOutcomes.Loss;
    }

    if ((playerChoice == PlayerChoices.Paper && opponentChoice == OpponentChoices.Rock)
        || (playerChoice == PlayerChoices.Scissors && opponentChoice == OpponentChoices.Paper)
        || (playerChoice == PlayerChoices.Rock && opponentChoice == OpponentChoices.Scissors))
    {
        return RoundOutcomes.Win;
    }

    return RoundOutcomes.Draw;
}

enum RoundOutcomes
{
    Win,
    Draw,
    Loss
}

static class PlayerChoices
{
    public const string Rock = "X";
    public const string Paper = "Y";
    public const string Scissors = "Z";
}

static class OpponentChoices
{
    public const string Rock = "A";
    public const string Paper = "B";
    public const string Scissors = "C";
}

static class ExpectedRoundOutcomes
{
    public const string Win = "Z";
    public const string Lose = "X";
    public const string Draw = "Y";
}
