using System.Collections.Generic;
using Entitas;
using UnityEngine;
 
public class CreateMoverSystem : ReactiveSystem<InputEntity>
{
    readonly GameContext gameContext;
    
    public CreateMoverSystem(Contexts contexts) : base(contexts.input)
    {
        gameContext = contexts.game;
    }
 
    // 收集有RightMouse和MouseDown的InputEntity
    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.RightMouse, InputMatcher.MousePosition));
    }
 
    // 第二过滤，直接返回true也无所谓
    protected override bool Filter(InputEntity entity)
    {
        return entity.hasMousePosition;
    }
 
    // 执行，每次按下右键，设置Mover标志，添加Position、Direction，并添加表现该Entity的图片名称
    protected override void Execute(List<InputEntity> entities)
    {
        foreach (InputEntity e in entities)
        {
            GameEntity mover = gameContext.CreateEntity();
            mover.isMover = true;
            mover.AddPosition(e.mousePosition.position);
            mover.AddDirection(Random.Range(0, 360));
            mover.AddSprite("Sprite");
        }
    }
}