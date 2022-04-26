using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class PositionSystem : ReactiveSystem<GameEntity>
{
    public PositionSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Positon);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPositon && entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.view.view.transform.position = new Vector3(entity.positon.pos.x, entity.positon.pos.y, 0);
        }
    }
}
