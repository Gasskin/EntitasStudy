using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;
 
[Input, Unique]
public class LeftMouseComponent :IComponent
{
}
 
[Input, Unique]
public class RightMouseComponent :IComponent
{
}
 
[Input]
public class MousePositionComponent :IComponent
{
    public Vector2 position;
}
