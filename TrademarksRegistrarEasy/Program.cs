HashSet<string> normalizedTrademarks = new (); 
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
    if(normalizedTrademarks.Add(registrant)) //O(1)
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