-- Lua调用事件

-- C#添加事件 TestEvent.StaticEvent += TestEvent.StaticFunc



-- Lua添加事件
CS.TestEvent.StaticEvent("+", CS.TestEvent.StaticFunc);
CS.TestEvent.CallStatic();
CS.TestEvent.StaticEvent("-", CS.TestEvent.StaticFunc);



-- 添加动态成员变量
local func = function ()
    print("这是Lua调用C#动态事件触发");
end

local obj = CS.TestEvent();
obj:DelegateEvent("+", func);
obj:CallDynamic();
obj:DelegateEvent("+", func);