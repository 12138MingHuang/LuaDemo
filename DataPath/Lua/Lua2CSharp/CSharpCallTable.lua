Core = {};
Core.id = 100;
Core.name = "ROOT";
Core.isWoman = false;

Core.Func1 = function (name)
    print("这是Core表的Func1函数，接收到C#的数据" .. name);
end

Core.Func2 = function ()
    return "这是Core表的Func2函数";
end

Core.Func3 = function (self)
    print("这是Core表的Func3函数，Core表的成员变量name是" .. self.name);
end

function Core:Func4()
    print("这是Core表的Func4函数，Core表的成员变量name是" .. self.name);
end