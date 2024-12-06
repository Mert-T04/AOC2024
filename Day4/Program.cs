using System.Collections.Frozen; 

const string searchTerm = "XMAS";
const string searchTermBackwards = "SAMX";
var input = File.ReadLines("input.txt");
var inputList = new List<char[]>();

for(int i = 0; i < 3; i++) 
{
    inputList.Add(Enumerable.Repeat('.', input.First().Length + 6).ToArray());
}

foreach(var line in input)
{
    inputList.Add(Enumerable.Repeat('.', 3).Concat(line).Concat(Enumerable.Repeat('.', 3)).ToArray());
}

for(int i = 0; i < 3; i++) 
{
    inputList.Add(Enumerable.Repeat('.', input.First().Length + 6).ToArray());
}

var inputArray = inputList.ToArray();
var xmasCount = 0;
for(var y = 3; y < inputArray.Length - 3; y++) 
{
    for(var x = 3; x < inputArray[0].Length - 3; x++)
    {
        if(SearchCircle(x, y)) 
        {
            xmasCount++;
        }
    }
}

Console.WriteLine($"Found XMAS {xmasCount} times.");

// 1070 is too low

// Kein Bock meh uf da, i skip de Tag. Matrix-Search isch en Scheiss.

bool SearchCircle(int x, int y) 
{
    // ☹
    if(SearchDirection(1, 1)) return true;
    if(SearchDirectionBackwards(1, 1)) return true;
    if(SearchDirection(0, 1)) return true;
    if(SearchDirectionBackwards(0, 1)) return true;
    if(SearchDirection(-1, 1)) return true;
    if(SearchDirectionBackwards(-1, 1)) return true;
    if(SearchDirection(-1, 0)) return true;
    if(SearchDirectionBackwards(-1, 0)) return true;
    if(SearchDirection(-1, -1)) return true;
    if(SearchDirectionBackwards(0, -1)) return true;
    if(SearchDirection(-1, -1)) return true;
    if(SearchDirectionBackwards(0, -1)) return true;
    if(SearchDirection(1, -1)) return true;
    if(SearchDirectionBackwards(1, 0)) return true;
    if(SearchDirection(1, -1)) return true;
    if(SearchDirectionBackwards(1, 0)) return true;

    return false;

    bool SearchDirection(int dirX, int dirY)
    {
        // 😭
        if(inputArray[x][y] != searchTerm.First()) 
        {
            return false;
        }

        foreach(var letter in searchTerm.Skip(1))
        {
            if(inputArray[x + dirX][y + dirY] != letter) 
            {
                return false;
            }

            dirX += dirX;
            dirY += dirY;
        }

        return true;
    }

        bool SearchDirectionBackwards(int dirX, int dirY)
    {
        if(inputArray[x][y] != searchTermBackwards.First()) 
        {
            return false;
        }

        foreach(var letter in searchTermBackwards.Skip(1))
        {
            if(inputArray[x + dirX][y + dirY] != letter) 
            {
                return false;
            }

            dirX += dirX;
            dirY += dirY;
        }

        return true;
    }
}