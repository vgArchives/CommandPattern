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
        Vector3 position = _playerController.transform.position;
        Vector3 direction = new Vector3(_movementDirection.x, 0f, _movementDirection.y);
        _playerController.PathMarkerGenerator.AddMarkerToPath(position + direction);

        _playerController.Move(_movementDirection);
    }

    public void Undo()
    {
        _playerController.PathMarkerGenerator.RemoveMarkerFromPath();
        _playerController.Move(-_movementDirection);
    }
}
