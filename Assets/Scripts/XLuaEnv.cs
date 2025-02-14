using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

public class XLuaEnv
{
    private LuaEnv _luaEnv;

    public LuaTable Global
    {
        get { return _luaEnv.Global; }
    }
    
    private XLuaEnv()
    {
        _luaEnv = new LuaEnv();
        _luaEnv.AddLoader(ProjectLoader);
    }
    
    private static XLuaEnv _instance;
    public static XLuaEnv Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new XLuaEnv();
            }
            return _instance;
        }
    }

    private byte[] ProjectLoader(ref string filePath)
    {
        string path = Application.dataPath;
        path = path.Substring(0, path.Length - 6) + "DataPath/Lua/" + filePath + ".lua";
        
        return File.Exists(path) ? File.ReadAllBytes(path) : null;
    }

    /// <summary>
    /// 执行Lua脚本
    /// </summary>
    /// <param name="fileName"> Lua脚本文件名包括路径（后缀可带课不带）</param>
    /// <returns></returns>
    public object[] DoString(string fileName)
    {
        if (fileName.EndsWith(".lua"))
        {
            fileName = fileName.Replace(".lua", "");
        }

        return _luaEnv.DoString($"require('{fileName}')");
    }
    
    /// <summary>
    /// 更新Lua环境。
    /// </summary>
    public void Tick()
    {
        _luaEnv.Tick();
    }
    
    /// <summary>
    /// 释放Lua环境资源。
    /// </summary>
    public void Dispose()
    {
        _luaEnv.Dispose();
        _instance = null;
        Debug.Log("XLuaEnv 已释放");
    }
}
