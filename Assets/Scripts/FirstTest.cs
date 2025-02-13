using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class FirstTest : MonoBehaviour
{
    private void Start()
    {
        // Lua是解释型语言，所以需要获得Lua的解析器
        // XLua解析器获取
        LuaEnv env = new LuaEnv();
        
        // 解析器运行Lua代码，把字符串当成Lua代码执行
        env.DoString("print('Hello, Lua')");
        
        // 释放解析器
        env.Dispose();
    }
}
