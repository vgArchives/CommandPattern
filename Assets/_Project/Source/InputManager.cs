using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerController _playerOneController;
    [SerializeField] private PlayerController _playerTwoController;
    [SerializeField] private PlayerIdentifier _currentPlayerIdentifier;

    private PlayerController _currentController;
    private Dictionary<PlayerIdentifier, PlayerController> _playerControllerByIdentifier = new Dictionary<PlayerIdentifier, PlayerController>();

    protected void Start()
    {
        _playerControllerByIdentifier.Add(PlayerIdentifier.PlayerOne, _playerOneController);
        _playerControllerByIdentifier.Add(PlayerIdentifier.PlayerTwo, _playerTwoController);

         SetCurrentPlayer(_currentPlayerIdentifier);
    }

    private void OnMove(InputValue value)
    {
        Vector2 inputValue = value.Get<Vector2>();

        Debug.Log($"InputManager - OnMove Called {inputValue}");

        if (inputValue == Vector2.zero)
        {
            return;
        }

        if (!_currentController.IsMoveValid(inputValue))
        {
            Debug.Log("InputManager - Invalid Direction");
            return;
        }

        ICommand moveCommand = new MovePlayerCommand(_currentController, value.Get<Vector2>());
        CommandInvoker.ExecuteCommand(moveCommand);
    }

    private void OnUndo(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("InputManager - Undo Pressed");
            CommandInvoker.UndoCommand();
        }
    }

    private void OnRedo(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("InputManager - Redo Pressed");
            CommandInvoker.RedoCommand();
        }
    }

    private void SetCurrentPlayer(PlayerIdentifier playerIdentifier)
    {
        if (_playerControllerByIdentifier.TryGetValue(playerIdentifier, out PlayerController controller))
        {
            _currentController = controller;
        }
    }
}