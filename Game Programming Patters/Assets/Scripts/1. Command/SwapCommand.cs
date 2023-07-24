using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCommand : ICommand
{
    public void Execute()
    {
        Debug.Log("Swap!");
    }
}
