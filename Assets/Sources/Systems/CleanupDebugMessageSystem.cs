// CleanupDebugMessageSystem.cs
using System;
using Entitas;
 
// 继承于ICleanupSystem
public class CleanupDebugMessageSystem : ICleanupSystem
{
    // 保存game环境
    readonly GameContext _context;
    // 保存所有拥有DebugMessage组件的Entity
    readonly IGroup<GameEntity> _debugMessages;
 
    // 构造函数，添加game环境和保存拥有DebugMessage组件的Group
    public CleanupDebugMessageSystem(Contexts contexts)
    {
        _context       = contexts.game;
        _debugMessages = _context.GetGroup(GameMatcher.DebugMessage);
    }
 
    // Cleanup函数，只要有DebugMessage组件的Entity就直接销毁
    public void Cleanup()
    {
        foreach(var e in _debugMessages.GetEntities())
        {
            e.Destroy();
        }
    }
}