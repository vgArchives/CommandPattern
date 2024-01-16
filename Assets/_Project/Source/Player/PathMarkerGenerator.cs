using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathMarkerGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _pathMarkerPrefab;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private List<Vector3> _markerList;

    private Stack<GameObject> _pathObjectStack = new Stack<GameObject>();

    public void AddMarkerToPath(Vector3 position)
    {
        GameObject pathMarkerObject = Instantiate(_pathMarkerPrefab, position, Quaternion.identity);
        _pathObjectStack?.Push(pathMarkerObject);

        pathMarkerObject.transform.parent = _lineRenderer.transform;

        _markerList = _pathObjectStack.Select(pathObject => pathObject.transform.position).ToList();
        _lineRenderer.positionCount = _markerList.Count;
    }

    public void RemoveMarkerFromPath()
    {
        GameObject lastMarkerObject = _pathObjectStack.Pop();
        Destroy(lastMarkerObject.gameObject);

        _markerList = _pathObjectStack.Select(pathObject => pathObject.transform.position).ToList();
        _lineRenderer.positionCount = _markerList.Count;
    }

    protected void Start()
    {
        AddMarkerToPath(transform.position);
    }

    protected void Update()
    {
        _lineRenderer.SetPositions(_markerList.ToArray());
    }
}
