using System;
using UnityEngine;

public class TestSingleton : MonoBehaviour
{
    private void Start()
    {
        XLuaEnv.Instance.DoString("test1.lua");
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Dispose();
    }
}
