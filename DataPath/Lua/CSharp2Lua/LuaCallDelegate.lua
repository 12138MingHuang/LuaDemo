-- Lua调用委托

-- C#给委托赋值
-- TestDelegate.StaticDelegate = StaticDelegate.StaticFunc;
-- TestDelegate.StaticDelegate += StaticDelegate.StaticFunc;
-- TestDelegate.StaticDelegate -= StaticDelegate.StaticFunc;
-- TestDelegate.StaticDelegate();

CS.TestDelegate.StaticDelegate = CS.TestDelegate.StaticFunc;
CS.TestDelegate.StaticDelegate();
-- Lua中如果添加了函数到静态委托变量中后，在委托不使用后，要释放添加的委托
CS.TestDelegate.StaticDelegate = nil;

local func = function ()
    print("这是Lua的函数,用于静态委托");
end

-- 覆盖添加委托
CS.TestDelegate.StaticDelegate = func;
CS.TestDelegate.StaticDelegate = CS.TestDelegate.StaticDelegate + func;
CS.TestDelegate.StaticDelegate = CS.TestDelegate.StaticDelegate - func;
CS.TestDelegate.StaticDelegate();
CS.TestDelegate.StaticDelegate = nil;

-- 调用前判断
-- if(CS.TestDelegate.StaticDelegate ~= nil)
-- then
--     CS.TestDelegate.StaticDelegate();
-- end

-- 根据委托判定赋值方法
-- if(CS.TestDelegate.StaticDelegate ~= nil)
-- then
--     CS.TestDelegate.StaticDelegate = func;
-- else
--     CS.TestDelegate.StaticDelegate = CS.TestDelegate.StaticDelegate + func;
-- end


local func = function ()
    print("这是Lua的函数,用于对象委托");
end
local obj = CS.TestDelegate();
obj.DynamicDelegate = func;
obj.DynamicDelegate();
obj.DynamicDelegate = nil;