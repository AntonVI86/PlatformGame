using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Slime : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _health;

    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out DirectionChangePoint direction)) 
        {
            _speed *= -1;
            _renderer.flipX = !_renderer.flipX;
        }
    }
}
