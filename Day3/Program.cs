using System.Text.RegularExpressions;

var input = File.ReadAllText("input.txt");
var mulRegex = new Regex(@"mul\((\d{0,3}),(\d{0,3})\)|do\(\)|don't\(\)");
var res = 0;
var calcAllowed = true;

foreach(Match match in mulRegex.Matches(input))
{
    if(match.Groups[0].Value == "do()") {
        calcAllowed = true;
        continue;
    }
    if(match.Groups[0].Value == "don't()") {
        calcAllowed = false;
        continue;
    }

    if(calcAllowed) {
        res += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
    }
}

Console.WriteLine(res);
