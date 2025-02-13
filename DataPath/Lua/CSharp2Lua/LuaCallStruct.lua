-- Lua调用结构体

-- 和对象调用保持一致
local obj = CS.TestStruct();

obj.name = "admin";

print(obj.name);
print(obj:Output());