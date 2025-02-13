using System;
using UnityEngine;

namespace ZB
{
    public static class TestStatic
    {
        public static int id = 99;
        
        public static string Name
        {
            get;
            set;
        }

        public static string Output()
        {
            return "Static Method";
        }

        public static void Default(string str = "abc")
        {
            Debug.Log(str);
        }
    }
}

public class LuaCallStatic : MonoBehaviour
{
    private void Start()
    {
        XLuaEnv.Instance.DoString("CSharp2Lua/LuaCallStatic");
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Dispose();
    }
}