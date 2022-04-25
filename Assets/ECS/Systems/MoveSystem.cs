using Entitas;
using UnityEngine;
 
public class MoveSystem : IExecuteSystem, ICleanupSystem
{
    readonly IGroup<GameEntity> moves;
    readonly IGroup<GameEntity> moveCompletes;
    const float speed = 4f;
 
    // 获取有移动目标Move组和完成移动MoveComplete组
    public MoveSystem(Contexts contexts)
    {
        moves = contexts.game.GetGroup(GameMatcher.Move);
        moveCompletes = contexts.game.GetGroup(GameMatcher.MoveComplete);
    }
 
    // 拥有目标的Mover每帧执行
    public void Execute()
    {
        foreach (GameEntity e in moves.GetEntities())
        {
            // 计算下一个GameObject的位置，并替换
            Vector2 dir = e.move.target - e.position.value;
            Vector2 newPosition = e.position.value + dir.normalized * speed * Time.deltaTime;
            e.ReplacePosition(newPosition);
 
            // 计算下一个方向
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            e.ReplaceDirection(angle);
 
            // 如果距离在0.5f之内，则判断为移动完成，移除Move命令，并添加移动完成标志
            float dist = dir.magnitude;
            if (dist <= 0.5f)
            {
                e.RemoveMove();
                e.isMoveComplete = true;
            }
        }
    }
 
    // 清除所有MoveComplete，MoveComplete暂时没有作用
    public void Cleanup()
    {
        foreach (GameEntity e in moveCompletes.GetEntities())
        {
            e.isMoveComplete = false;
        }
    }
}