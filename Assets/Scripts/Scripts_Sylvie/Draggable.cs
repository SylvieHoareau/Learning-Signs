using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool IsDragging;
    public Vector3 LastPosition;

    private Collider2D _collider;
    private DragController _dragController;

    public float _movementTime = 15f;
    private System.Nullable<Vector3> _movementDestination;

    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _dragController = FindObjectOfType<DragController>();
    }

    void FixedUpdate()
    {
        if (_movementDestination.HasValue)
        {
            if (IsDragging)
            {
                _movementDestination = null;
                return;
            }

            if (transform.position == _movementDestination)
            {
                gameObject.layer = Layer.Default;
                _movementDestination = null;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, _movementDestination.Value, _movementTime * Time.fixedDeltaTime);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        Draggable colliderDraggable = other.GetComponent<Draggable>();

        if (colliderDraggable != null  && _dragController.lastDragged.gameObject == gameObject)
        {
            ColliderDistance2D colliderDistance = _collider.Distance(other);
            Vector3 diff = new Vector3(colliderDistance.pointA.x - colliderDistance.pointB.x, colliderDistance.pointA.y - colliderDistance.pointB.y, 0);
            transform.position += diff;
        }

        if (other.CompareTag("DropValid")) {
            _movementDestination = other.transform.position;
        }
        else 
        {
            _movementDestination = _dragController.lastDragged.LastPosition;
        }
    }

    private void OnMouseDown()
    {
        _dragController.InitDrag();
    }

    private void OnMouseDrag()
    {
        _dragController.Drag();
    }

    private void OnMouseUp()
    {
        _dragController.Drop();
    }

}
