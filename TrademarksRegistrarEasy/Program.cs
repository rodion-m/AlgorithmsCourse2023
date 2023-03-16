Console.WriteLine(new HashSet<string>().GetHashCode());
Console.WriteLine(new Program().GetHashCode());
Console.WriteLine(new AB().GetHashCode());
Console.WriteLine(new AB().GetHashCode());
Console.WriteLine(new AB(0, 1).GetHashCode());
Console.WriteLine(new AB(2, 2).GetHashCode());
Console.WriteLine(new AB(2, 1).GetHashCode());
Console.WriteLine(new AB(1, 2).GetHashCode());

bool ContainsDuplicate0(int[] nums)
{
    for (int i = 0; i < nums.Length; i++)
    {
        for (int j = i + 1; j < nums.Length; j++)
        {
            if (nums[i] == nums[j])
            {
                return true;
            }
        }
    }
    return false;
}

bool ContainsDuplicate1(int[] nums)
{
    var hashSet = new HashSet<int>();
    foreach (var item in nums)
    {
        if (!hashSet.Add(item))
            return true;
    }

    return false;
}


bool ContainsDuplicate2(int[] nums)
{
    return nums.Distinct().Count() != nums.Length;
}

HashSet<string> normalizedTrademarks = new();
// Count = 1.000.000
// ближе к 1.000.000 = O(n)
// ближе к 1 трлн = O(n^2)

// n = 1.000.000 (кол-во тов. знаков), k - среднее кол-во символов в каждом товарном (10)
// O(n), O(1)
bool Register(string name) //Goo Gle
{
    string registrant = RemoveWhitespaces(name).ToLower(); //"google"

    //n раз выполняем k операций O(n * k)
    // 1.000.000 * 10 = 10.000.000 = O(n)
    if (normalizedTrademarks.Add(registrant)) //O(1)
    {
        throw new Exception("Товарный знак уже зарегистрирован");
    }

    //Успешно зарегистрировали
    return true;
}

string RemoveWhitespaces(string input)
{
    return input
        .Replace(" ", "")
        .Replace("\t", "")
        .Replace("\n", "");
}

struct AB
{
    public int A { get; set; }
    public int B { get; set; }

    public AB(int a, int b)
    {
        A = a;
        B = b;
    }
}