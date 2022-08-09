using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HeroMover : HeroAnimator
{
    [SerializeField] private float _moveSpeed;

    private SpriteRenderer _renderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetAxis(HeroInput.Horizontal) != 0)
        {
            MoveHorizontal();
            _animator.SetBool(RunHash, true);
        }
        else
        {
            _animator.SetBool(RunHash, false);
        }
    }

    private void MoveHorizontal()
    {
        transform.Translate(new Vector2(Input.GetAxis(HeroInput.Horizontal) * _moveSpeed * Time.deltaTime, 0));

        if (Input.GetAxis(HeroInput.Horizontal) > 0)
        {
            _renderer.flipX = false;
        }
        else
        {
            _renderer.flipX = true;
        }
    }
}
