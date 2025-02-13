using UnityEngine;

public delegate void DelegateLua();

public class TestDelegate
{
    public static DelegateLua StaticDelegate;
    
    public DelegateLua DynamicDelegate;

    public static void StaticFunc()
    {
        Debug.Log("StaticFunc");
    }
}

public class LuaCallDelegate : MonoBehaviour
{
    private void Start()
    {
        XLuaEnv.Instance.DoString("CSharp2Lua/LuaCallDelegate");
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Dispose();
    }
}