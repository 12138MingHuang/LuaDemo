using UnityEngine;

public delegate void EventLua();

public class TestEvent
{
    public static event EventLua StaticEvent;
    public static void StaticFunc()
    {
        Debug.Log("这是C#静态事件触发");
    }
    public static void CallStatic()
    {
        if (StaticEvent != null)
            StaticEvent();
    }
    
    public event EventLua DelegateEvent;
    public void CallDynamic()
    {
        if (DelegateEvent != null)
            DelegateEvent();
    }
}

public class LuaCallEvent : MonoBehaviour
{
    private void Start()
    {
        XLuaEnv.Instance.DoString("CSharp2Lua/LuaCallEvent");
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Dispose();
    }
}