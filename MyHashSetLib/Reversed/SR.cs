using System.Dynamic;

namespace MyHashSetLib.Reversed;

public class SRDyn : DynamicObject
{
    public static dynamic SR = new SRDyn();
    
    public override bool TryInvoke(InvokeBinder binder, object?[]? args, out object? result)
    {
        result = binder.ToString();
        return true;
    }
}