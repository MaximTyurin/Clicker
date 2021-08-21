using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void DieAnimation()
    {
        _animator.SetTrigger("Die");
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
}
