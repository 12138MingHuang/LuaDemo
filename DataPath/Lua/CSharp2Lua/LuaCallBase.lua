-- Lua调用类继承

-- 调用父类
local father = CS.Father();
print(father.name);
father:Talk();
father:Say();

-- 调用Child
local child = CS.Child();
print(child.name);
child:Talk();
child:Say();