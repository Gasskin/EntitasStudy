using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ProcessInputSystem : ReactiveSystem<InputEntity>
{
    readonly Contexts contexts;

    public ProcessInputSystem(Contexts contexts) : base(contexts.input)
    {
        this.contexts = contexts;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) => context.CreateCollector(InputMatcher.Input);

    protected override bool Filter(InputEntity entity) => entity.hasInput;

    protected override void Execute(List<InputEntity> entities)
    {
        var inputEntity = entities.SingleEntity();
        var input = inputEntity.input;
        var entity = contexts.game.GetEntityWithPositon(input.pos);
        Object.Destroy(entity.view.view);
    }
}
