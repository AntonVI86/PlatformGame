using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HeroJumper : HeroAnimator
{
    [SerializeField] private Transform _groundPoint;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _layerGround;

    private Rigidbody2D _rigidbody;
    private bool _isGrounded;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
    }

    private void Jump()
    {
        CheckGround();

        if (Input.GetButtonDown(HeroInput.Jump) && _isGrounded)
        {
            _rigidbody.velocity = Vector2.up * _jumpForce;
            _animator.SetBool(JumpHash, true);
        }
        else
        {
            _animator.SetBool(JumpHash, false);

            if (_isGrounded == false)
            {
                _animator.SetBool(FallHash, true);
            }
            else
            {
                _animator.SetBool(FallHash, false);
            }
        }
    }

    private void CheckGround() 
    {
        Collider2D[] ground = Physics2D.OverlapCircleAll(_groundPoint.position, 0.02f, _layerGround);
        _isGrounded = ground.Length > 0;
    }
}
