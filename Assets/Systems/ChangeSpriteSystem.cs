// ChangeSpriteSystem.cs
using UnityEngine;
using Entitas;
 
public class ChangeSpriteSystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _sprites;
 
    // 获取所有拥有Sprite的组
    public ChangeSpriteSystem(Contexts contexts)
    {
        _sprites = contexts.game.GetGroup(GameMatcher.Sprite);
    }
 
    // 如果按下的中键，则替换
    public void Execute()
    {
        if(Input.GetMouseButtonDown(2))
        {
            foreach(GameEntity e in _sprites.GetEntities())
            {
                e.ReplaceSprite("head2");
            }
        }
    }
}