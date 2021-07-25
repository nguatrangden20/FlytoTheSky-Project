using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DebugCommandBase
{
    private string _commandID;
    private string _commandDescription;
    private string _commandFormat;

    public string commandID {get { return _commandID;}}
    public string commandDescription {get { return _commandDescription;}}
    public string commandFormat {get {return _commandFormat;}}
    
    public DebugCommandBase (string ID, string Description, string Format)
    {
        _commandID = ID;
        _commandDescription = Description;
        _commandFormat = Format;
    }
}

public class DebugCommand : DebugCommandBase
{
    private Action command;
    public DebugCommand(string id, string description, string format, Action command) : base (id, description, format)
    {
        this.command = command;
    }

    public void Invoke()
    {
        command.Invoke();
    }
}
