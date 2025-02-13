-- Lua调用对象类

local npc = CS.Npc();
npc.Hp = 100;

print(npc.Hp);

local npc2 = CS.Npc("admin")
print(npc2.name)

-- 表方法希望调用表成员变量(表:函数())
-- 用冒号是因为，对象引用成员变量时候，会隐性调用this等同于Lua中的self
print(npc2:Output())

-- Lua实例化Unity的GameObject对象
local go = CS.UnityEngine.GameObject("LuaCreateGO");
-- Lua为Unity物体对象添加碰撞体组件
go:AddComponent(typeof(CS.UnityEngine.BoxCollider));