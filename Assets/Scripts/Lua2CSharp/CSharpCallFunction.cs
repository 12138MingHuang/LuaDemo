using System;
using UnityEngine;
using XLua;

public delegate void Func1();
public delegate void Func2(string name);
public delegate string Func3();

[CSharpCallLua]
public delegate void Func4(out string name, ref int age);

public class CSharpCallFunction : MonoBehaviour
{
    private void Start()
    {
        XLuaEnv.Instance.DoString("Lua2CSharp/CSharpCallFunction");
        
        MapDelegate();
        
        MapLuaFunction();
    }
    
    // 映射到Delegate
    private void MapDelegate()
    {
        LuaTable global = XLuaEnv.Instance.Global;
        
        Func1 func1 = global.Get<string, Func1>("func1");
        func1();
        
        Func2 func2 = global.Get<string, Func2>("func2");
        func2("admin");
        
        Func3 func3 = global.Get<string, Func3>("func3");
        Debug.Log(func3() + ", 被C#调用!");
        
        Func4 func4 = global.Get<string, Func4>("func4");
        string name;
        int age = 18;
        func4(out name, ref age);
        
        Debug.Log($"name: {name}, age: {age}");
    }

    // 映射到LuaFunction
    private void MapLuaFunction()
    {
        LuaTable global = XLuaEnv.Instance.Global;
        
        LuaFunction func1 = global.Get<string, LuaFunction>("func1");
        func1.Call();
        
        LuaFunction func2 = global.Get<string, LuaFunction>("func2");
        func2.Call("admin");
        
        LuaFunction func3 = global.Get<string ,LuaFunction>("func3");
        object[] fun3Return = func3.Call();
        Debug.Log((string)fun3Return[0] + ", 被C#调用!");
        
        LuaFunction func4 = global.Get<string ,LuaFunction>("func4");
        object[] fun4Return = func4.Call();
        Debug.Log($"name: {(string)fun4Return[0]}, age: {(Int64)fun4Return[1]}");
        
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