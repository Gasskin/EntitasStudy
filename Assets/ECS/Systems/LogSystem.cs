using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class LogSystem : ReactiveSystem<GameEntity>
{
    public LogSystem(Contexts contexts): base(contexts.game)
    {
        
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Log);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasLog;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            Debug.Log(entity.log.msg);
        }
    }
}
