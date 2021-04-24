using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 5.0F;
   
    [Header("Dependencies")]
    [SerializeField] private Transform _triggerZone;
    
    private Vector2 _movement;
    
    private Rigidbody2D _rb;
    private Animator _animator;
   
    private static readonly int VerticalSpeed = Animator.StringToHash("VerticalSpeed");
    private static readonly int HorizontalSpeed = Animator.StringToHash("HorizontalSpeed");
    private static readonly int Speed = Animator.StringToHash("Speed");

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        if(_movement.sqrMagnitude > 0.01F)
            _triggerZone.right = _movement;
        
        _animator.SetFloat(HorizontalSpeed, _movement.x);
        _animator.SetFloat(VerticalSpeed, _movement.y);
        _animator.SetFloat(Speed, _movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * (MoveSpeed * Time.fixedDeltaTime));
    }
}
