using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Collider2D playerCollider;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    private bool isJumping;
    private Rigidbody2D _rb;
    private Animator _animator; 

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded();
        Jump();
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            _rb.AddForce(new Vector2(_rb.velocity.x, _jumpForce));
            
        }

    }

    private void IsGrounded()
    {
        RaycastHit2D rayLeft = Physics2D.Raycast(playerCollider.bounds.min, Vector2.down, 0.1f);
        RaycastHit2D rayRight = Physics2D.Raycast(new Vector2(playerCollider.bounds.max.x, playerCollider.bounds.min.y), Vector2.down, 0.1f);

        if ((rayLeft.collider != null && rayLeft.collider.gameObject.CompareTag("Ground"))
            || (rayRight.collider != null && rayRight.collider.gameObject.CompareTag("Ground")))
        {
            isJumping = false;
            _animator.SetBool("IsJumping", false);
        }
        else
        {
            isJumping = true;
            _animator.SetBool("IsJumping", true);
        }
        }
}
