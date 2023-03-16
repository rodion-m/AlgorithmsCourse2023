namespace MyHashSetLib;

public class MyHashSetString
{
    private Entry?[] _entries = new Entry[1_000];

    private class Entry
    {
        public Entry(string value, int nextIndex)
        {
            Value = value;
            NextIndex = nextIndex;
        }

        public string Value { get; set; }
        public int NextIndex { get; set; }
    }

    //ab, ba
    public void Add(string element)
    {
        var hashCode = GetHashCode(element);
        var index = hashCode % _entries.Length;
        Entry? entry = _entries[index];
        if (entry is null) //когда такой хешкод встречается впервые
        {
            _entries[index] = new Entry(element, 0);
            return;
        }
        
        var isCollision = entry.Value != element;
        if (isCollision)
        {
            var nextElementExists = entry.NextIndex != 0;
            if (nextElementExists)
            {
                var nextEntry = _entries[entry.NextIndex];
                if (nextEntry!.Value == element)
                {
                    return;
                }
                else
                {
                    throw new NotImplementedException(
                        "Больше 2-х элементов с одинаковым хешкодом не поддерживаются");
                }
            }
            else
            {
                //когда есть коллизия, но такой элемент еще не представлен
                index += 1000;
                entry.NextIndex = index;
                _entries[index] = new Entry(element, 0);
            }
        }
        //_entries[index] = true;
    }

    //ddd = 300
    //dddddd..10 = 1000
    //-2млрд до 2млрд = 4ккк вариантов
    private int GetHashCode(string text)
    {
        int counter = 0;
        //char == int16
        char a = 'a'; // = 97
        // for (int i = 0; i < text.Length; i++)
        // {
        //     counter += text[i] * (i + 1); //ab = 17, ba = 16
        // }
        foreach (char chr in text)
        {
            counter += chr;
        }

        return counter;
    }

    //ab
    //ba
    public bool Contains(string element)
    {
        var hashCode = GetHashCode(element);
        var index = hashCode;
        Entry entry = _entries[index];
        if (entry.Value == element)
        {
            return true;
        }
        else if(entry.NextIndex > 0)
        {
            var nextEntryIndex = entry.NextIndex;
            if (_entries[nextEntryIndex].Value == element)
            {
                return true;
            }
        }

        return false;
    }
}