Bootstrap = {};

-- 核心table，存储所有控制器
Bootstrap.Controllers = {};

Bootstrap.Awake = function ()
    print("Lua Awake");
end

Bootstrap.Start = function ()
    print("Lua Start");

    Bootstrap.LoadController("MainMenuController");
end

Bootstrap.Update = function ()
    print("Lua Update");

    for key, controller in pairs(Bootstrap.Controllers) do
        if(controller ~= nil) then
            controller:Update();
        end
    end
end

Bootstrap.OnDestroy = function ()
    print("Lua OnDestroy");
end

--[[
    提供一个核心table函数用于加载页面控制器
    参数是脚本名称
]]
Bootstrap.LoadController = function (name)
    -- 加载Controller目录下对应的脚本
    local controller = require("LuaHotfix/Controller/" .. name);
    Bootstrap.Controllers[name] = controller;
    controller.Start();
end


-- print("Bootstrap");

-- require("LuaHotfix/Prefabs");

-- Prefabs:Load("TestText");

-- local json = require("LuaJson");
-- local dataTable = json.decode('[true, "abc, 3]');
-- print(dataTable[2]);