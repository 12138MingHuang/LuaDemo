using UnityEngine;

public class TestGenericType
{
    private void Output<T>(T data)
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
    
    public void Output(double data)
    {

        Output<double>(data);
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