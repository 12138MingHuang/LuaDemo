using UnityEngine;

public class Npc
{
    public string name;
    public int Hp
    {
        get;
        set;
    }

    public Npc()
    {
        
    }

    public Npc(string name)
    {
        this.name = name;
    }

    public string Output()
    {
        return name;
    }
}

public class LuaCallObject : MonoBehaviour
{
    private void Start()
    {
        XLuaEnv.Instance.DoString("CSharp2Lua/LuaCallObject");
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Dispose();
    }
}