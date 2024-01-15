using System.Collections.Generic;
using UnityEngine;

public static class CommandInvoker
{
    public static Stack<ICommand> UndoCommandsStack = new Stack<ICommand>();
    public static Stack<ICommand> RedoCommandsStack = new Stack<ICommand>();

    public static void ExecuteCommand(ICommand command)
    {
        Debug.Log($"CommandInvoker - Executing command {command.GetType()}");

        command.Execute();

        UndoCommandsStack.Push(command);
        RedoCommandsStack.Clear();
    }

    public static void UndoCommand()
    {
        Debug.Log($"CommandInvoker - Executing UndoCommand");

        if (UndoCommandsStack.Count <= 0)
        {
            return;
        }

        ICommand currentCommand = UndoCommandsStack.Pop();
        currentCommand.Undo();

        RedoCommandsStack.Push(currentCommand);
    }

    public static void RedoCommand()
    {
        Debug.Log($"CommandInvoker - Executing RedoCommand");

        if (RedoCommandsStack.Count <= 0)
        {
            return;
        }

        ICommand currentCommand = RedoCommandsStack.Pop();
        currentCommand.Execute();

        UndoCommandsStack.Push(currentCommand);
    }
}
