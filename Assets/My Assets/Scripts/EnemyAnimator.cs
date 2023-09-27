using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class EnemyAnimator : MonoBehaviour
{
    private const string Speed = nameof(Speed);
    private const string Fall = nameof(Fall);
    private const string Ground = nameof(Ground);

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        bool isCollidingWithGround = _collider.IsTouchingLayers(LayerMask.GetMask(Ground));
        
        _animator.SetBool(Fall, !isCollidingWithGround);
        _animator.SetFloat(Speed, Mathf.Abs(_rigidbody2D.velocity.x));

        FlipModel();
    }

    private void FlipModel()
    {
        if (_rigidbody2D.velocity.x > 0)
            _spriteRenderer.flipX = false;
        else
            _spriteRenderer.flipX = true;
    }
}