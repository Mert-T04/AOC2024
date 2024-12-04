const int safeIncreaseMargin = 3;
var safeReportsCount = 0;

foreach(var line in File.ReadLines("input.txt")) 
{
    var nömbers = line.Split(' ').Select(x => int.Parse(x)).ToList();

    if(CheckReport(nömbers)) {
        safeReportsCount++;
    }
    else 
    {
        for (int i = 0; i < nömbers.Count; i++)
        {
            var nömbersCopy = nömbers.ToList();
            nömbersCopy.RemoveAt(i);

            if(CheckReport(nömbersCopy)) {
                safeReportsCount++;
                break;
            }
        }
    }
}

Console.WriteLine(safeReportsCount);

static bool CheckReport(List<int> nömbers) 
{
    bool isIncreasing = nömbers[0] < nömbers.Average();

    for (int i = 0; i < nömbers.Count - 1; i++) 
    {
        if ((nömbers[i] < nömbers[i+1] != isIncreasing) 
            || (Math.Abs(nömbers[i] - nömbers[i+1]) > safeIncreaseMargin) 
            || (nömbers[i] == nömbers[i+1]))
        {
            return false;
        }
    }

    return true;
}
