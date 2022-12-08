static async Task<int> GetMaxValue()
{
    var input = await File.ReadAllLinesAsync("input.txt");

    var maxValue = 0;
    var currentValue = 0;

    foreach (var calorieLine in input)
    {
        if (calorieLine == "")
        {
            if (currentValue > maxValue)
            {
                maxValue = currentValue;
            }

            currentValue = 0;

            continue;
        }

        currentValue = currentValue + int.Parse(calorieLine.Trim());
    }

    return maxValue;
}

static async Task<int> GetSumOfHighestValues(int numberOfTopValues)
{
    var input = await File.ReadAllLinesAsync("input.txt");

    var topValues = new int[numberOfTopValues];

    var currentValue = 0;

    foreach (var calorieLine in input)
    {
        if (calorieLine == "")
        {
            if (currentValue > topValues.Min())
            {
                var arrayIndex = Array.IndexOf(topValues, topValues.Min());

                topValues[arrayIndex] = currentValue;
            }

            currentValue = 0;

            continue;
        }

        currentValue = currentValue + int.Parse(calorieLine.Trim());
    }

    return topValues.Sum();
}

Console.WriteLine(await GetSumOfHighestValues(3));
