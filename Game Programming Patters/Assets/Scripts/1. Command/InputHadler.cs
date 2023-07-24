using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public enum ActionType
{
    None,
    Fire,
    Jump,
    Lurch,
    Swap
}

public class InputHadler : MonoBehaviour
{
    ICommand buttonX;
    ICommand buttonY;
    ICommand buttonA;
    ICommand buttonB;

    ActionType selectedActionType = ActionType.None;
    private bool onBindingKey = false;


    public void Start()
    {
        buttonX = new FireCommand();
        buttonY = new JumpCommand();
        buttonA = new LurchCommand();
        buttonB = new SwapCommand();
    }

    private void Update()
    {
        if(onBindingKey) { BindAction(); }
        HandleInput();     
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            buttonX.Execute();
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            buttonY.Execute();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            buttonA.Execute();
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            buttonB.Execute();
        }
    }



    private void BindAction()
    {
        Debug.Log("On Bind Action");

        if (Input.GetKeyDown(KeyCode.X))
        {
            buttonX = BindActionByType();
            onBindingKey = false;

            Debug.Log($"Binding X Suceffully Changed to {buttonX}");


        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            buttonY = BindActionByType();
            onBindingKey = false;

            Debug.Log($"Binding Y Suceffully Changed to {buttonY}");


        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            buttonA = BindActionByType();
            onBindingKey = false;

            Debug.Log($"Binding A Suceffully Changed to {buttonA}");


        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            buttonB = BindActionByType();
            onBindingKey = false;

            Debug.Log($"Binding B Suceffully Changed to {buttonB}");

        }

    }

    private ICommand BindActionByType()
    {
        switch(selectedActionType)
        {
            case ActionType.Jump:
                return new JumpCommand();
            case ActionType.Fire: 
                return new FireCommand();
            case ActionType.Swap:
                return new SwapCommand();
            case ActionType.Lurch: 
                return new LurchCommand();
        }


        return null;
    }

    public void BindFireAction()
    {
        selectedActionType = ActionType.Fire;
        onBindingKey = true;
    }
    public void BindJumpAction()
    {
        selectedActionType = ActionType.Jump;
        onBindingKey = true;
    }
    public void BindSwapAction()
    {
        selectedActionType = ActionType.Swap;
        onBindingKey = true;
    }
    public void BindLurchAction()
    {
        selectedActionType = ActionType.Lurch;
        onBindingKey = true;
    }


}
