string sample = "Hello World";
List<string> lines = new List<string>();
int lineCount = 5;
lines.Add(sample);

for (int i = 0; i < lineCount - 1; i++)
{
    lines.Add("_");
}

foreach (string line in lines)
{
    Console.WriteLine(line);
}

// Output:
// Hello World
// _
// _
// _
// _
