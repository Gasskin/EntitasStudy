using Entitas;
using UnityEngine;

public class Enter : MonoBehaviour
{
    public Systems systems;
    
    private void Start()
    {
        var contexts = Contexts.sharedInstance;
        systems = new Feature("Systems")
            .Add(new MoveSystem(contexts))
            .Add(new GameFeature(contexts))
            .Add(new InputFeature(contexts));
        systems.Initialize();
    }


    private void Update()
    {
        systems.Execute();
        systems.Cleanup();
    }
}
