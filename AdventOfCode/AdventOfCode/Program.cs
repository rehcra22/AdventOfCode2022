var input = await File.ReadAllLinesAsync("input.txt");

var maxValue = 0;
var currentValue = 0;

foreach(var calorieLine in input)
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

Console.WriteLine(maxValue);