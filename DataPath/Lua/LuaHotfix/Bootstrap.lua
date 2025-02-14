Bootstrap = {};

Bootstrap.Awake = function ()
    print("Lua Awake");
end

Bootstrap.Start = function ()
    print("Lua Start");
end

Bootstrap.Update = function ()
    print("Lua Update");
end

Bootstrap.OnDestroy = function ()
    print("Lua OnDestroy");
end


-- print("Bootstrap");

-- require("LuaHotfix/Prefabs");

-- Prefabs:Load("TestText");

-- local json = require("LuaJson");
-- local dataTable = json.decode('[true, "abc, 3]');
-- print(dataTable[2]);