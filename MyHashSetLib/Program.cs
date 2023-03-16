using MyHashSetLib;

HashSetDemo.Run();

return;
//2:
var hashSetString = new MyHashSetString();
hashSetString.Add("ab");
Console.WriteLine(hashSetString.Contains("ab")); //true
Console.WriteLine(hashSetString.Contains("ba")); //false
Console.WriteLine();
hashSetString.Add("ba");
Console.WriteLine(hashSetString.Contains("ab")); //true
Console.WriteLine(hashSetString.Contains("ba")); //true



// hashSetString.Add("a"); //O(1)
// hashSetString.Add("b"); //O(1)
// hashSetString.Add("c"); //O(1)
//
// if(hashSetString.Contains("a")) //O(1)
// {
//     Console.WriteLine("a is in the set");
// }

return;
var hashSet = new MyHashSetInt();

//1: +
hashSet.Add(0); //O(1)
hashSet.Add(5); //O(1)
hashSet.Add(9); //O(1)
hashSet.Add(5); //O(1)

hashSet.Add(777777); //O(1)

if(hashSet.Contains(5)) //O(1)
{
    Console.WriteLine("5 is in the set");
}

for (int i = 0; i < 1_000_000; i++)
{
    hashSet.Add(5); //O(1)
}

