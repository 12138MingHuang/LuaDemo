func1 =  function ()
    print("这是Lua中的无参无返回值的func1函数");
end

func2 = function (name)
    print("这是Lua中的有参无返回值的func2函数，参数是：" .. name);
end

func3 = function ()
    return "这是Lua中的有返回值的func3函数";
end

func4 = function ()
    return "这是Lua中的多返回值的func4函数" , 20;
end