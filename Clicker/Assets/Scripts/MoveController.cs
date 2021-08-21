using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public class MoveController : MonoBehaviour
{
    [SerializeField] private WayPoint[] _target;
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _maskEnemy;
    [SerializeField] private float _raycastLength = 2.5f;
    private int _currentTargetIndex;
    private Rigidbody _rigidbody; 

    private void Start() 
    {
        _rigidbody = GetComponent<Rigidbody>();
        _currentTargetIndex = Random.Range(0, _target.Length - 1);
        _target = FindObjectsOfType(typeof(WayPoint)) as WayPoint[];
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.forward * _raycastLength, Color.red);
        MovementEnemys();
    }

    private void MovementEnemys()
    {
        if (Physics.Raycast(transform.position, transform.forward, _raycastLength, _maskEnemy))
        {
            ChangeCurrentTargetIndex();
        }

        if (Vector3.Distance(transform.position, _target[_currentTargetIndex].transform.position) < 0.2f)
            ChangeCurrentTargetIndex();
        if (Vector3.Distance(transform.position, _target[_currentTargetIndex].transform.position) >= 0.2f)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, _target[_currentTargetIndex].transform.position, _speed * Time.fixedDeltaTime);
            _rigidbody.MovePosition(pos);
            transform.LookAt(_target[_currentTargetIndex].transform.position);
        }
    }

    private void ChangeCurrentTargetIndex()
    {
        _currentTargetIndex = Random.Range(0, _target.Length);
    }

    public void IncreaseSpeed(float newValueSpeed)
    {
        if (newValueSpeed > 0)
        {
            _speed += newValueSpeed;
        }
    }
}
