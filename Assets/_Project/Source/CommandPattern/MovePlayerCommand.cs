using UnityEngine;

public class MovePlayerCommand : ICommand
{
    private PlayerController _playerController;
    private Vector2 _movementDirection;

    public MovePlayerCommand(PlayerController playerController, Vector2 movementDirection)
    {
        _playerController = playerController;
        _movementDirection = movementDirection;
    }

    public void Execute()
    {
        _playerController.Move(_movementDirection);
    }

    public void Undo()
    {
        _playerController.Move(-_movementDirection);
    }
}
