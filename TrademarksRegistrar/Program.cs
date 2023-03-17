using TrademarksRegistrar;

var registrar = new Registrar();
string[] queries = //8 (n^2)
{
    "Booble", //+ //до n
    "yyyess", //+ //до n
    "oooops", //+ //oops
    "oooooopppss", //+ //ooppss
    "Boooble", //-
    "yyessss",  //-
    "oooops", //-
    "ooooppssss" //- //ooppss
};
//Решение:
// 1. Получаем нормализованную строку по ТЗ в соответствии с условиями
// 2. Сравнить получившийся ТЗ со списком зарегистрированных ТЗ в нормализованном виде
// Если хранить зарегистрированные ТЗ в массиве,то сложность регистрации нового ТЗ будет O(n)
// 3. Если есть совпадение, то ТЗ не зарегистрировано

foreach (var query in queries)
{
    registrar.TryRegister(query); //O(1)
}

Console.WriteLine(registrar.Count);