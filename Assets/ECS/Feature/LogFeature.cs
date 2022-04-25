using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogFeature : Feature
{
    public LogFeature(Contexts contexts): base("LogFeature")
    {
        Add(new InitializeSystem(contexts));
        Add(new LogSystem(contexts));
    }
}
