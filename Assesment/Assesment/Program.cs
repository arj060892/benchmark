// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

//int sum = Add(input: Console.ReadLine());
int sum = Add("1,-2,-3");
//Console.WriteLine(sum.ToString());
Console.WriteLine("1\n2,3,1233");
Console.ReadLine();

static int Add(string input)
{
    if (string.IsNullOrEmpty(input))
    {
        return 0;
    }

    if (input.Contains(",\n") || input.Contains("\n,"))
    {
        throw new ArgumentException("Invalid Format");
    }

    char[] delimeters = new[] { ',', '\n' };

    if (input.StartsWith("//"))
    {
        string[] tmp = input.Split('\n');
        delimeters = tmp.First().Remove(0, 2).ToCharArray();
        input = tmp.Last();
    }

    IEnumerable<int> query = input.Split(delimeters, StringSplitOptions.RemoveEmptyEntries)
            .Select(c => int.TryParse(c, out int num) && num <= 1000 ? num : 0);

    List<int> negativeNumbers = query.Where(n => n < 0)
            .ToList();

    if (negativeNumbers.Count > 0)
    {
        throw new ArgumentException("Contains negative nnumber " + string.Join(',', negativeNumbers));
    }

    return query.Sum();


}