using UnityEngine;

public struct TestStruct
{
    public string name;

    public string Output()
    {
        return name;
    }
}

public class LuaCallStruct : MonoBehaviour
{
    private void Start()
    {
        XLuaEnv.Instance.DoString("CSharp2Lua/LuaCallStruct");
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Dispose();
    }
}