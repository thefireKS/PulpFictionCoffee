using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private Rigidbody2D _playerRb;
    private Animator _animator;
    private Collider2D _collider2D;

    private int _playerLayer, _groundLayer;
    
    private Vector2 _move;
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");

    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _collider2D = GetComponent<Collider2D>();

        _playerLayer = LayerMask.NameToLayer("Player");
        _groundLayer = LayerMask.NameToLayer("Ground");
    }
    void Update()
    {
        _move = new Vector2(Input.GetAxis("Horizontal"), 0);
        PlayerMovement();
        RightFacing();
        Jump();
        PlatformLayerIgnore();
    }

    private void Jump()
    {
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetAxisRaw("Vertical") > 0) && GroundCheck())
            _playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void PlayerMovement()
    {
        Vector2 moveVector = transform.TransformDirection(_move) * speed; //make freeze rotation
        var velocity = _playerRb.velocity;
        velocity = new Vector2(moveVector.x, velocity.y);
        _playerRb.velocity = velocity;
        _animator.SetBool(IsRunning, velocity.x != 0);
    }
    private void RightFacing()
    { 
        if (Input.GetAxisRaw("Horizontal") > 0) 
            transform.localScale = new Vector3(1, 1, 1);
        else if (Input.GetAxisRaw("Horizontal") < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void PlatformLayerIgnore()
    {
        var velocityY = _playerRb.velocity.y;
        Physics2D.IgnoreLayerCollision(_playerLayer, _groundLayer, velocityY > 0);
    }
    
    private bool GroundCheck()
    {
        var bounds = _collider2D.bounds;
        var downCenter = bounds.min + new Vector3(bounds.center.x, 0, 0);
        RaycastHit2D raycastHit2D = Physics2D.Raycast(downCenter, Vector2.down, 0.03f, LayerMask.GetMask("Ground"));
        var rayColor = raycastHit2D.collider ? Color.green : Color.red;
        Debug.DrawRay(downCenter, Vector3.down * 0.03f,rayColor);
        return raycastHit2D.collider;
    }
}