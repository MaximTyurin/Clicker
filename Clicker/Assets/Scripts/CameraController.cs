using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector2 _startPos;
    private Camera _camera;
    private float _targetPos;
    private float _rightBorder = 10;
    private float _leftBorder = 1f;
    
    private void Start()
    {
        _camera = GetComponent<Camera>();
        _targetPos = transform.position.x;
    }

    // Update is called once per frame
    private void Update()
    {
        SwipeCamera();
    }

    private void SwipeCamera()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _startPos = _camera.ScreenToViewportPoint(Input.mousePosition);
        }
        else if(Input.GetMouseButton(0))
        {
            float position = _camera.ScreenToViewportPoint(Input.mousePosition).x - _startPos.x;
            _targetPos = Mathf.Clamp(transform.position.x - position, _leftBorder, _rightBorder);
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, _targetPos, _speed * Time.deltaTime),
            transform.position.y, transform.position.z);
        }
    }
}
