using UnityEngine;

public class TestOutRef
{
    public static string Func1()
    {
        return "Func1";
    }

    public static string Func2(string str1, out string str2)
    {
        str2 = "Func2 Out";
        return str1;
    }

    public static string Func3(string str1, ref string str2)
    {
        str2 = "Func3 Ref";
        return str1;
    }
    
    public static string Func4(ref string str1, string str2)
    {
        str1 = "Func4 Ref";
        return str2;
    }
}

public class LuaCallOutRef : MonoBehaviour
{
    private void Start()
    {
        XLuaEnv.Instance.DoString("CSharp2Lua/LuaCallOutRef");
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Dispose();
    }
}