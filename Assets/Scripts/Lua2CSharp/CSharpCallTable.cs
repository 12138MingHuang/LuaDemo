using UnityEngine;
using XLua;

public delegate void OneStringParams(string name);
public delegate void TransSelf(LuaTable self);

public class CSharpCallTable : MonoBehaviour
{
    private void Start()
    {
        XLuaEnv.Instance.DoString("Lua2CSharp/CSharpCallTable");
        
        MapLuaTable();
    }

    // 映射Lua表
    private void MapLuaTable()
    {
        LuaTable global = XLuaEnv.Instance.Global;
        
        // 获取全局变量Core表，因为它是Lua中的表，所以需要通过LuaTable类型来获取
        LuaTable core = global.Get<LuaTable>("Core");
        Debug.Log(core.Get<string>("name"));
        Debug.Log(core.Get<int>("id"));
        core.Set<string, int>("id", 101);
        Debug.Log(core.Get<int>("id"));

        OneStringParams osp = core.Get<OneStringParams>("Func1");
        osp("Hello");

        TransSelf ts = core.Get<TransSelf>("Func3");
        ts(core);
    }
    
    private void Update()
    {
        XLuaEnv.Instance.Tick();
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Dispose();
    }
}