using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class ViewSystem : ReactiveSystem<GameEntity>
{
    private Transform parent;
    
    public ViewSystem(Contexts contexts) : base(contexts.game)
    {
        parent = new GameObject("Views").transform;
        parent.position=Vector3.zero;
    }
    
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Asset);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasAsset && !entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var prefab = Resources.Load<GameObject>(entity.asset.assetName);
            var view = Object.Instantiate(prefab, parent);
            entity.AddView(view);
            view.Link(entity);
        }
    }
}
