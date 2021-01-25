// LogMouseClickSystem.cs
using UnityEngine;
using Entitas;
 
// 继承IExecuteSystem，添加到系统集的System，会每帧执行Execute方法
public class LogMouseClickSystem :IExecuteSystem
{
    // game的环境
    readonly GameContext _context;
    public LogMouseClickSystem(Contexts contexts)
    {
        _context = contexts.game;
    }
 
    public void Execute()
    {
        // 获取到左右按键，就创建个Entity，并添加一个DebguMessage组件
        if (Input.GetMouseButtonDown(0))
            _context.CreateEntity().AddDebugMessage("Left Mouse Button Clicked");
        if(Input.GetMouseButtonDown(1))
            _context.CreateEntity().AddDebugMessage("Right Mouse Button Clicked");
    }
}