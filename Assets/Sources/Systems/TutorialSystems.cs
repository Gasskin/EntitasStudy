// TutorialSystems.cs
public class TutorialSystems : Feature
{
    // 添加所有要用到的System，base里面是调试节点的名字
    public TutorialSystems(Contexts contexts) : base("Tutorial Systems")
    {
        Add (new HelloWorldSystem(contexts));
        Add (new LogMouseClickSystem (contexts));
        Add (new DebugMessageSystem(contexts));
        Add (new CleanupDebugMessageSystem (contexts));
    }
}