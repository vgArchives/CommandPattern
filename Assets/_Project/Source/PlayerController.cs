using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask _obstacleLayer;

    private const float RaycastCheckDistance = 1f;

    private Transform _playerTransform;

    public void Move(Vector2 direction)
    {
        Debug.Log("PlayerController - Move called");

        Vector3 currentPosition = _playerTransform.position;
        Vector3 destinationPoint = currentPosition + new Vector3(direction.x, currentPosition.y, direction.y);
        _playerTransform.position = destinationPoint;
    }

    public bool IsMoveValid(Vector2 direction)
    {
        Vector3 directionToCheck = new Vector3(direction.x, 0f, direction.y);
        return !Physics.Raycast(transform.position, directionToCheck, RaycastCheckDistance, _obstacleLayer);
    }

    protected void Awake()
    {
        _playerTransform = transform;
    }
}
