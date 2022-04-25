using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Systems systems;
    
    void Start()
    {
        var context = Contexts.sharedInstance;
        systems = new Feature("Systems").Add(new LogFeature(context));
        systems.Initialize();
    }

    void Update()
    {
        systems.Execute();
        systems.Cleanup();
    }
}
