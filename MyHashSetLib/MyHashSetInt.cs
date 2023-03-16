namespace MyHashSetLib;

public class MyHashSetInt
{
    private bool[] _elements = new bool[10];
    
    public bool Add(int element)
    {
        if (_elements[element]) return false;
        _elements[element] = true;
        return true;
    }

    public bool Contains(int element)
    {
        return _elements[element];
    }
}
