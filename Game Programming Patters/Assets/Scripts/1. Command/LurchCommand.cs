using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LurchCommand : ICommand
{
    public void Execute()
    {
        Debug.Log("Lurch!");
    }
}
