using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class InitializeSystem : IInitializeSystem
{
    public GameContext context;
    
    public InitializeSystem(Contexts contexts)
    {
        context = contexts.game;
    }
    
    public void Initialize()
    {
        context.CreateEntity().AddLog("hello world");
    }
}
