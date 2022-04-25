using UnityEngine;
using Entitas;
 
public class InputSystem :IInitializeSystem,IExecuteSystem
{
    private InputContext context;
    private InputEntity leftMouseEntity;
    private InputEntity rightMouseEntity;
 
    public InputSystem(Contexts contexts)
    {
        context = contexts.input;
    }
 
    public void Initialize()
    {
        context.isLeftMouse = true;
        context.isRightMouse = true;
        
        leftMouseEntity = context.leftMouseEntity;
        rightMouseEntity = context.rightMouseEntity;
    }
 
    public void Execute()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
            leftMouseEntity.ReplaceMousePosition(mousePosition);

        if (Input.GetMouseButtonDown(1))
            rightMouseEntity.ReplaceMousePosition(mousePosition);
    }
}