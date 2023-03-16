using TrademarksRegistrar;

var registrar = new Registrar();
string[] queries =
{
    "Booble", "yyyess", "oooops", "oooooopppss", "Boooble", "yyessss", "oooops", "ooooppssss"
};

foreach (var query in queries)
{
    registrar.Register(query);
}


Console.WriteLine(registrar.Count);