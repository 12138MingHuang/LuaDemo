using System;
using System.IO;
using UnityEngine;
using XLua;

public class Loader : MonoBehaviour
{
    private void Start()
    {
        SystemLoader();
        MyLoader();
    }

    private void SystemLoader()
    {
        LuaEnv luaEnv = new LuaEnv();
        
        // 对应test.lua
        // 内置加载器会扫描预制的目录，查找是否存在test.lua
        // xLua存在默认加载器 StreamingAssets目录下可以加载文件
        luaEnv.DoString("require('test')");
        
        luaEnv.Dispose();
    }

    private void MyLoader()
    {
        LuaEnv luaEnv = new LuaEnv();
        // 将自定义的加载器，加入到XLua的解析环境中
        luaEnv.AddLoader(ProjectLoader);
        luaEnv.DoString("require('test1')");
        
        luaEnv.Dispose();
    }

    // 自定义加载器
    // 自定义加载器,会先于系统内置加载器执行
    // 当自定加载器加载到文件后,后续的加载器则不会继续执行
    // 当Lua代码执行require()函数时,自定义加载器会尝试获得文件的内容
    // 参数:被加载Lua文件的路径,返回值:文件的内容，如果加载失败,则返回null
    private byte[] ProjectLoader(ref string filePath)
    {
        string path = Application.dataPath;
        path = path.Substring(0, path.Length - 6) + "DataPath/Lua/" + filePath + ".lua";
        
        return File.Exists(path) ? File.ReadAllBytes(path) : null;
    }
}