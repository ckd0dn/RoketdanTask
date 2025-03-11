using UnityEngine;
using UnityEngine.Serialization;

public class Zombie : MonoBehaviour
{
    [SerializeField] protected float speed = 4f;
    [SerializeField] protected float pushPower = 4f;
    [SerializeField] private float _detectionDistance = 1f;
    [SerializeField] private float _rayOffsetX = .3f;
    [SerializeField] private float _rayOffsetY = .1f;
    protected Rigidbody2D rb;
    private bool _isClimbing;
    private bool _isPush;
    private LayerMask _zombieLayer;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _zombieLayer = LayerMask.GetMask("Zombie");
    }

    private void FixedUpdate()
    {
        Detect();
        
        if (_isClimbing)
        {
            Climb();
        }
        else
        {
            if (!_isPush)
            {
                Move();
            }
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(-speed, 0f);
    }

    private void Detect()
    {
        var origin = new Vector2(transform.position.x - _rayOffsetX, transform.position.y + _rayOffsetY);
        
        // Climb 
        RaycastHit2D[] climbHits = Physics2D.RaycastAll(origin, Vector2.left, _detectionDistance, _zombieLayer);
        _isClimbing = climbHits.Length > 0 && HasOtherZombie(climbHits);
    
        // Push 
        RaycastHit2D[] pushHits = Physics2D.RaycastAll(origin, Vector2.up, _detectionDistance * 2, _zombieLayer);
        _isPush = pushHits.Length > 0 && HasOtherZombie(pushHits);

        if (_isPush) 
        {
            Push();
        }
        
        Debug.DrawRay(origin, Vector2.left * _detectionDistance, Color.red);
        Debug.DrawRay(origin, Vector2.up * _detectionDistance * 2, Color.red);
    }
    
    private void Climb()
    {
        rb.velocity = new Vector2(-speed, speed * 1.5f);
    }

    private void Push()
    {
        rb.velocity = new Vector2(speed, 0f);
    }
    
    private bool HasOtherZombie(RaycastHit2D[] hits)
    {
        foreach (var hit in hits)
        {
            if (hit.collider != null && hit.collider.gameObject != gameObject)
            {
                return true; // 다른 좀비 감지
            }
        }
        return false; // 다른 좀비 없음
    }
    
}