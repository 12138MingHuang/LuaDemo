using System.Collections.Generic;
using UnityEngine;
using XLua;

public delegate void OneStringParams(string name);
public delegate void TransSelf(LuaTable self);

public delegate string OneStringReturn();

[CSharpCallLua]
public delegate void TransMy(LuaCore self);

[GCOptimize] // 标记为结构体，可以减少GC
public struct LuaCore
{
    public int id;
    public string name;
    public bool isWoman;
    
    public OneStringParams Func1;
    public OneStringReturn Func2;
    public TransSelf Func3;
    public TransMy Func4;
}

[CSharpCallLua]
public interface ILuaCore
{
    public int id { get; set; }
    public string name { get; set; }
    public bool isWoman { get; set; }
    
    void Func1(string name);
    string Func2();
    void Func3();
    void Func4();
}

public class CSharpCallTable : MonoBehaviour
{
    private void Start()
    {
        XLuaEnv.Instance.DoString("Lua2CSharp/CSharpCallTable");
        
        // MapLuaTable();
        // MapStruct();
        // MapInterface();
        MapDictAndList();
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

    // 映射结构体
    private void MapStruct()
    {
        LuaTable global = XLuaEnv.Instance.Global;
        LuaCore core = global.Get<LuaCore>("Core");
        Debug.Log(core.id);
        core.Func4(core);
    }
    
    // 映射接口
    private void MapInterface()
    {
        LuaTable global = XLuaEnv.Instance.Global;
        ILuaCore iCore = global.Get<ILuaCore>("Core");
        // 修改table中某键的值
        global.SetInPath<int>("Core.id", 1010);
        
        string name = iCore.name;
        int id = iCore.id;
        bool isWoman = iCore.isWoman;
        Debug.Log($"name: {name}, id: {id}, isWoman: {isWoman}");
        
        // 引用类型映射
        iCore.name = "Lucy";
        Debug.Log(global.Get<string>("Core.name"));
        
        // iCore.Func1("Hello");
        Debug.Log(iCore.Func2());
        iCore.Func3();
        iCore.Func4();
    }
    
    private void MapDictAndList()
    {
        LuaTable global = XLuaEnv.Instance.Global;
        Dictionary<string, object> dict = new Dictionary<string, object>();
        dict = global.Get<Dictionary<string, object>>("Core");
        foreach (var item in dict)
        {
            Debug.Log($"{item.Key}: {item.Value}");
        }
        
        List<int> list = new List<int>();
        list = global.Get<List<int>>("Core");
        foreach (var item in list)
        {
            Debug.Log($"{item}: {item}");
        }
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