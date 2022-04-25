using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFeature : Feature
{
    public GameFeature(Contexts contexts) : base("GameFeature")
    {
        Add(new AddViewSystem(contexts));
        Add(new RenderSpriteSystem(contexts));
        Add(new RenderPositionSystem(contexts));
        Add(new RenderDirectionSystem(contexts));
        Add(new ChangeSpriteSystem(contexts));
    }
}
