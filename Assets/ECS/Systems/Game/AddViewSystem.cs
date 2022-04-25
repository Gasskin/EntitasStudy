using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;
 
public class AddViewSystem : ReactiveSystem<GameEntity>
{
    // 为了好看，所有ViewGameObject都放在该父节点下
    readonly Transform viewContainer = new GameObject("Game Views").transform;
    readonly GameContext context;
 
    public AddViewSystem(Contexts contexts) : base(contexts.game)
    {
        context = contexts.game;
    }
 
    // 创建Sprite的过滤器
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Sprite);
    }
 
    // 第二次过滤，没有View，没有关联上GameObject的情况
    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSprite && !entity.hasView;
    }
 
    // 创建一个View的GameObject，并进行关联
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity e in entities)
        {
            GameObject go = new GameObject("Game View");
            go.transform.SetParent(viewContainer, false);
            e.AddView(go);  // Entity关联GameObject
            go.Link(e);   // GameObject关联Entity
        }
    }
}
