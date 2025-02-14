using System;
using UnityEngine;
using XLua;

public class CSharpCallVariable : MonoBehaviour
{
    private void Start()
    {
        XLuaEnv.Instance.DoString("Lua2CSharp/CSharpCallVariable");
        
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