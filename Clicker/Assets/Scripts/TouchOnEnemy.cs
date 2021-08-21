using UnityEngine;

public class TouchOnEnemy : MonoBehaviour
{
    private Animations _animations;
    private float _countTouches = 0;
    private float _maxCountToDeath = 0;

    public delegate void EnemyDeath();
    public static event EnemyDeath OnDiedEvent;

    private void Start()
    {
        _animations = GetComponentInChildren<Animations>();
    }

    private void OnMouseDown()
    {
        _countTouches++;
        if(_countTouches == _maxCountToDeath)
        {
            OnDiedEvent?.Invoke();
            _animations.DieAnimation();
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject, 1f);
    }

    public void IncreaseMaxCountToDeath(float newValueTap)
    {
        if(newValueTap > 0)
        {
            _maxCountToDeath += newValueTap;
        }
    }
}
