-- Lua调用参数带ref out 的方法

local return1 = CS.TestOutRef.Func1();
print(return1);

-- C# out返回的变量，会赋值给Lua的第二个接受返回值变量
local out2;
local return2, out1 = CS.TestOutRef.Func2("admin", out2);
print(return2, out1, out2);

-- C# ref返回的变量，会赋值给Lua的第二个接受返回值变量
local ref2;
local return3, ref1 = CS.TestOutRef.Func3("ROOT", ref2);
print(return3, ref1, ref2);

-- 即使out ref作为第一个参数，其结果依然会以Lua的多个返回值进行返回
local ref4;
local return4, ref3 = CS.TestOutRef.Func4(ref4, "test");
print(return4, ref3, ref4);