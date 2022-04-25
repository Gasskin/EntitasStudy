using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFeature : Feature
{
    public InputFeature(Contexts contexts) : base("InputFeature")
    {
        Add(new InputSystem(contexts));
        Add(new CreateMoverSystem(contexts));
        Add(new CommandMoveSystem(contexts));
    }
}
