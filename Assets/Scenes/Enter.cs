using System;
using Entitas;
using Unity.VisualScripting;
using UnityEngine;

public class Enter : MonoBehaviour
{
   private Systems systems;
   private void Start()
   {
      var contexts = Contexts.sharedInstance;
      systems = new Feature("Systems")
         .Add(new BoardSystem(contexts))
         .Add(new ViewSystem(contexts))
         .Add(new PositionSystem(contexts))
         .Add(new InputSystem(contexts))
         .Add(new ProcessInputSystem(contexts));
      systems.Initialize();
   }

   private void Update()
   {
      systems.Execute();
      systems.Cleanup();
   }
}
