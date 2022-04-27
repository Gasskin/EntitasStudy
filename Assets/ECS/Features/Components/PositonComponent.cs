using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game]
public class PositonComponent : IComponent
{
    [PrimaryEntityIndex]
    public Vector2Int pos;
}
