using System;
using UnityEngine;

public enum TestEnum
{
    LOL = 0,
    Dota2 = 1,
    Overwatch = 2,
}

public class LuaCallEnum : MonoBehaviour
{
    private void Start()
    {
        XLuaEnv.Instance.DoString("CSharp2Lua/LuaCallEnum");
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Dispose();
    }
}