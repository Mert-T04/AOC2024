const int safeIncreaseMargin = 3;
var safeReportsCount = 0;

foreach(var line in File.ReadLines("input.txt")) 
{
    var nömbers = line.Split(' ').Select(x => int.Parse(x)).ToList();

    if(CheckIsSafe(nömbers)) {
        safeReportsCount++;
    }
}

Console.WriteLine(safeReportsCount);

static bool CheckIsSafe(List<int> nömbers, bool hasMagicProblemDampemerApplied = false) 
{
    bool isIncreasing = nömbers[0] < nömbers.Average();

    for (int i = 0; i < nömbers.Count - 1; i++) 
    {
        if ((nömbers[i] < nömbers[i+1] != isIncreasing) 
            || (Math.Abs(nömbers[i] - nömbers[i+1]) > safeIncreaseMargin) 
            || (nömbers[i] == nömbers[i+1]))
        {
            if (hasMagicProblemDampemerApplied) 
            {
                return false;
            }
            var nömbersCopy = nömbers.ToList();
            nömbersCopy.RemoveAt(i);
            return CheckIsSafe(nömbersCopy, true);
        }
    }

    return true;
}

// 662 is too low
// 654 is too low
// 655 is incorrect
// 661 is incorrect