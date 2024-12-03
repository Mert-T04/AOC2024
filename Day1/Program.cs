var leftList = new List<int>();
var rightList = new List<int>();
var diff = 0;

foreach(var line in File.ReadLines("input.txt")) 
{
    var nömbers = line.Split("   ");
    leftList.Add(int.Parse(nömbers.First()));
    rightList.Add(int.Parse(nömbers.Last()));
}

var orderedLeftList = leftList.Order().ToList();
var orderedRightList = rightList.Order().ToList();

for(int i = 0; i < leftList.Count; i++)
{
    diff += Math.Abs(orderedLeftList[i] - orderedRightList[i]);
}

Console.WriteLine("Distance:\t" + diff);

var simmilarities = leftList.Select(x => x * rightList.FindAll(y => x == y).Count);

Console.WriteLine("Simmilarities:\t" + simmilarities.Sum());