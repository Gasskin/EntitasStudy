using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ChangeSpriteSystem : ReactiveSystem<GameEntity>
{
    public ChangeSpriteSystem(Contexts contexts) : base(contexts.game)
    {
    }
    
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.MoveComplete);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isMoveComplete && entity.isMover;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.ReplaceSprite("Sprite2");
        }
    }
}
