// CommandMoveSystem.cs
using System.Collections.Generic;
using Entitas;
 
// 点击左键后，用于创建移动命令
public class CommandMoveSystem : ReactiveSystem<InputEntity>
{
    readonly IGroup<GameEntity> movers;
 
    // 获取拥有Mover标志Entity的组
    public CommandMoveSystem(Contexts contexts) : base(contexts.input)
    {
        movers = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Mover));
    }
 
    // 过滤左键点击，和右键点击那个System一样
    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.LeftMouse, InputMatcher.MousePosition));
    }
 
    protected override bool Filter(InputEntity entity)
    {
        return entity.hasMousePosition;
    }
 
    // 在Entity上设置移动命令Move
    protected override void Execute(List<InputEntity> entities)
    {
        foreach (InputEntity e in entities)
        {
            GameEntity[] movers = this.movers.GetEntities();
            foreach (GameEntity entity in movers)
                entity.ReplaceMove(e.mousePosition.position);
        }
    }
}