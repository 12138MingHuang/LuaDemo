using UnityEngine;

public class TestGenericType
{
    public void Output<T>(T data)
    {
        Debug.Log("泛型方法：" + data.ToString());
    }

    public void Output(float data)
    {
        Output<float>(data);
    }

    public void Output(string data)
    {
        Output<string>(data);
    }
}

public class LuaCallGenericType : MonoBehaviour
{
    private void Start()
    {
        XLuaEnv.Instance.DoString("CSharp2Lua/LuaCallGenericType");
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Dispose();
    }
}