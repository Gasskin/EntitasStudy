using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Random = System.Random;

public class BoardSystem : ReactiveSystem<GameEntity>,IInitializeSystem
{
    private Contexts contexts;
    private Random random;
    private int boardSize = 10;
    
    public BoardSystem(Contexts contexts) : base(contexts.game)
    {
        this.contexts = contexts;
        random = new Random();
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.GameItem, GameMatcher.Positon));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isGameItem && entity.hasPositon;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.positon.pos.x > contexts.game.board.size || entity.positon.pos.y > contexts.game.board.size) 
            {
                
            }
        }
    }

    public void Initialize()
    {
        contexts.game.ReplaceBoard(boardSize);

        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                var entity = contexts.game.CreateEntity();
                entity.isGameItem = true;
                // entity.isMovable = true;
                // entity.isInteractive = true;
                entity.AddAsset($"Item{random.Next(6)}");
                entity.AddPositon(new Vector2Int(i, j));
            }
        }
    }
}
