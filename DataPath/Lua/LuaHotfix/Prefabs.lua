Prefabs = {};

--[[
    加载预制体
    param1-path：路径
    returns-游戏物体
]]
function Prefabs:Load(path)
    local prefab = CS.UnityEngine.Resources.Load(path);
    local go = CS.UnityEngine.Object.Instantiate(prefab);
    go.name = prefab.name;
    local canvas = CS.UnityEngine.GameObject.Find("/Canvas").transform;

    local trans = go.transform;
    trans:SetParent(canvas);
    trans.localPosition = CS.UnityEngine.Vector3.zero;
    trans.localRotation = CS.UnityEngine.Quaternion.identity;
    trans.localScale = CS.UnityEngine.Vector3.one;

    trans.offsetMin = CS.UnityEngine.Vector2.zero;
    trans.offsetMax = CS.UnityEngine.Vector2.zero;
    
    local rectTrans = go:GetComponent(typeof(CS.UnityEngine.RectTransform));
    rectTrans.sizeDelta = CS.UnityEngine.Vector2(300, 100);


    return go;
end