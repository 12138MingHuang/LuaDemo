-- Lua调用静态类

-- 规则 CS.命名空间.类名.成员变量
print(CS.ZB.TestStatic.id);

-- 给静态属性赋值
CS.ZB.TestStatic.Name = "admin";
print(CS.ZB.TestStatic.Name)

-- 静态成员方法调用
-- 规则 CS.命名空间.类名.方法名
print(CS.ZB.TestStatic.Output());

CS.ZB.TestStatic.Default();
CS.ZB.TestStatic.Default("def");