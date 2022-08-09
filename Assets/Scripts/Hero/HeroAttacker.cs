using System.Collections;
using UnityEngine;

public class HeroAttacker : HeroAnimator
{
    [SerializeField] private float _timeToNextAttack;

    private bool _isAttacked;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0) && _isAttacked == false)
        {
            _isAttacked = true;
            _animator.SetBool(AttackHash, true);
            StartCoroutine(DelayAttack());
        }
        else
        {
            _animator.SetBool(AttackHash, false);
        }
    }

    private IEnumerator DelayAttack() 
    {
        var delay = new WaitForSeconds(_timeToNextAttack);

        yield return delay;

        _isAttacked = false;
    }
}
