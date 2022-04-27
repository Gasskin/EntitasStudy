using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class InputSystem : IExecuteSystem
{
    readonly Contexts contexts;

    public InputSystem(Contexts contexts)
    {
        this.contexts = contexts;
    }

    public void Execute()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var pos = new Vector2Int((int)Math.Round(mouseWorldPos.x), (int)Math.Round(mouseWorldPos.y));
            if (pos.x >= contexts.game.board.size || pos.x > contexts.game.board.size) 
                return;
            contexts.input.ReplaceInput(pos);
        }
    }
}
