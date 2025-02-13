-- Lua调用枚举

-- CS.命名空间.枚举名.枚举值
-- 枚举获取的是userdata自定义数据类型
print(CS.TestEnum.LOL);
print(CS.TestEnum.Dota2);

print(type(CS.TestEnum.Overwatch));

-- 转换获取枚举值
print(CS.TestEnum.__CastFrom(0));
print(CS.TestEnum.__CastFrom("Dota2"));