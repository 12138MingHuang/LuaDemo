using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class DoString : MonoBehaviour
{
    private void Start()
    {
        LuaCallCSharpCode();
        LuaReturnData();
    }
    
    private void LuaCallCSharpCode()
    {
        LuaEnv luaEnv = new LuaEnv();
        
        // Lua脚本中调用C#代码(CS.命名空间.类名.方法名(参数))
        luaEnv.DoString("CS.UnityEngine.Debug.Log('Hello, C#!')");
        
        luaEnv.Dispose();
    }

    private void LuaReturnData()
    {
        LuaEnv luaEnv = new LuaEnv();
        
        object[] data = luaEnv.DoString("return 100, true");
        Debug.Log(data[0].ToString());
        Debug.Log(data[1].ToString());
        
        luaEnv.Dispose();
    }
}
