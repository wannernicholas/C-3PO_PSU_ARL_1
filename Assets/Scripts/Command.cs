using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command : ScriptableObject
{
    public string name;

    public void init(string name)
    {
        this.name = name;
    }

    public abstract void doCommand(string command);
}
