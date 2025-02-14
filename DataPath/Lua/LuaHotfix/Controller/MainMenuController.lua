local Controller = {};

-- 控制器被加载时，Start声明周期函数执行
-- Lua模拟Start生命周期函数
function Controller:Start()
    print("MainMenu:Start");
end

-- 每帧都会被调用
function Controller:Update()
    print("MainMenu:Update");
end

return Controller;