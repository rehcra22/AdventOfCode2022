var input = await File.ReadAllLinesAsync("input.txt");

PartTwo(input);

void PartOne(string[] input)
{
    const string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    var prioritySum = 0;

    foreach (var packs in input)
    {
        var charToSplitOn = packs.Length / 2;

        var firstCompartment = packs.Substring(0, charToSplitOn);
        var secondCompartment = packs.Substring(charToSplitOn, charToSplitOn);

        var duplicateValue = firstCompartment.Intersect(secondCompartment).FirstOrDefault();

        prioritySum += (characters.IndexOf(duplicateValue) + 1);
    }

    Console.WriteLine(prioritySum);
}

void PartTwo(string[] input)
{
    const string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    var prioritySum = 0;

    for (int i = 0; i < input.Length; i += 3)
    {
        var currentItem = input[i];
        var nextItem = input[i + 1];
        var lastItem = input[i + 2];

        var badge = currentItem.Intersect(nextItem).Intersect(lastItem).FirstOrDefault();

        prioritySum += (characters.IndexOf(badge) + 1);
    }

    Console.WriteLine(prioritySum);
}