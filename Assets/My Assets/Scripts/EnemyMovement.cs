using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Directions _direction;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() =>
        Move();

    public void SetDirection(Directions direction)
    {
        _direction = direction;
    }

    private void Move() =>
        _rigidbody2D.velocity = new Vector2(_speed * (int)_direction, _rigidbody2D.velocity.y);    
}