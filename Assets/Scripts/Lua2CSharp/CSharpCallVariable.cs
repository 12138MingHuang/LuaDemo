using System;
using UnityEngine;
using XLua;

public class CSharpCallVariable : MonoBehaviour
{
    private void Start()
    {
        XLuaEnv.Instance.DoString("Lua2CSharp/CSharpCallVariable");

        //LuaEnv提供了一个成员变量Global,它可以用于C#获取Lua的全局变是
        //Global的数据类型是C#实现的LuaTable,LuaTable是xLua实现的C#和Lua中表对应的数据结构
        //xLua会将Lua中的全局变量以Table的方式全部存储在Global中
        //通过运行环境,导出全局变量,类型是LuaTable
        //LuaTable是C#的数据对象,用于和Lua中的全局变量存储的table对应

        LuaTable global = XLuaEnv.Instance.Global;
        
        int num = global.Get<string, int>("num");
        int num1;
        global.Get<string, int>("num", out num1);
        float rate = global.Get<string, float>("rate");
        bool isWoman = global.Get<string, bool>("isWoman");
        string name = global.Get<string, string>("name");
        
        Debug.Log($"num: {num}, num1: {num1}, rate: {rate}, isWoman: {isWoman}, name: {name}");
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