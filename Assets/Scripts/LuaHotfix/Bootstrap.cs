using System;
using UnityEngine;
using XLua;

[CSharpCallLua]
public delegate void LifeCycle();

[GCOptimize]
public struct LuaBootstrap
{
    public LifeCycle Awake;
    public LifeCycle Start;
    public LifeCycle Update;
    public LifeCycle OnDestroy;
}

public class Bootstrap : MonoBehaviour
{
    public LuaBootstrap _luaBootstrap;
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
        XLuaEnv.Instance.DoString("LuaHotfix/Bootstrap");
        
        _luaBootstrap = XLuaEnv.Instance.Global.Get<LuaBootstrap>("Bootstrap");
        _luaBootstrap.Awake();
    }
    
    private void Start()
    {
        _luaBootstrap.Start();
    }
    
    private void Update()
    {
        XLuaEnv.Instance.Tick();
        _luaBootstrap.Update();
    }

    private void OnDestroy()
    {
        _luaBootstrap.OnDestroy();
        
        _luaBootstrap.Awake = null;
        _luaBootstrap.Start = null;
        _luaBootstrap.Update = null;
        _luaBootstrap.OnDestroy = null;
        
        XLuaEnv.Instance.Dispose();
    }
}