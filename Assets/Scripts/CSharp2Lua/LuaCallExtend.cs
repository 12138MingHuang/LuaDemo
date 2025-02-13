using UnityEngine;
using XLua;

public class TestExtend
{
    public void Output()
    {
        Debug.Log("类本身的方法");
    }
}

// 类拓展，需要给拓展方法编写的静态类添加特性[LuaCallCSharp], 这样才可以被Lua调用。
[LuaCallCSharp]
public static class MyExtend
{
    public static void Show(this TestExtend obj)
    {
        Debug.Log("类拓展实现的方法");
    }
}

public class LuaCallExtend : MonoBehaviour
{
    private void Start()
    {
        XLuaEnv.Instance.DoString("CSharp2Lua/LuaCallExtend");
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Dispose();
    }
}