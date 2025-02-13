using UnityEngine;

public class Father
{
    public string name;

    public void Talk()
    {
        Debug.Log("这是父类中的方法");
    }

    public virtual void Say()
    {
        Debug.Log("这是父类中的虚方法");
    }
}

public class Child : Father
{
    public override void Say()
    {
        Debug.Log("这是子类中的重写方法");
    }
}

public class LuaCallBase : MonoBehaviour
{
    private void Start()
    {
        XLuaEnv.Instance.DoString("CSharp2Lua/LuaCallBase");
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Dispose();
    }
}