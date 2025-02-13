using UnityEngine;

public class TestOverLoad
{
    public static void Test(int num)
    {
        Debug.Log("数字类型(int)：" + num);
    }
    public static void Test(float num)
    {
        Debug.Log("数字类型(float)：" + num);
    }
    
    
    public static void Test(string str)
    {
        Debug.Log("字符串类型：" + str);
    }
    
    public static void Test(float num, string name)
    {
        Debug.Log("数字类型：" + num + " 字符串类型：" + name);
    }
}

public class LuaCallOverLoad : MonoBehaviour
{
    private void Start()
    {
        XLuaEnv.Instance.DoString("CSharp2Lua/LuaCallOverLoad");
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Dispose();
    }
}