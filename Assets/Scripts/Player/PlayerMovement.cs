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
    private float _spacePressedTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCollider != null)
        {
            IsGrounded();
            if (Input.GetKeyDown(KeyCode.Space) && !IsGrounded() || isJumping)
            {
                // Use has pressed the Space key. We don't know if they'll release or hold it, so keep track of when they started holding it.
                Jump();
                isJumping = true;
                _spacePressedTime += Time.deltaTime;
                if (Input.GetKeyUp(KeyCode.Space) || _spacePressedTime >= 0.3f)
                    isJumping = false;
            }
            else
            {
                _spacePressedTime = 0;
            }
            /*else if (Input.GetKeyUp(KeyCode.Space) && !IsGrounded())
            {
              Jump(Time.timeSinceLevelLoad - _spacePressedTime);
            }/*
            //IsGrounded();
            /*if (Input.GetAxis("Jump") > 0 && !IsGrounded())
            {
                Jump();
            }*/
        }
    }
    void Jump()
    {
            Debug.Log("Jumping");
            _rb.velocity = new Vector2(0, _jumpForce);
            _animator.SetBool("IsJumping", true); 
    }

    private bool IsGrounded()
    {
        RaycastHit2D rayLeft = Physics2D.Raycast(new Vector2(playerCollider.bounds.min.x, playerCollider.bounds.min.y - 0.1f), Vector2.down, 0.3f);
        RaycastHit2D rayRight = Physics2D.Raycast(new Vector2(playerCollider.bounds.max.x, playerCollider.bounds.min.y - 0.1f), Vector2.down, 0.3f);


        if ((rayLeft.collider != null && rayLeft.collider.gameObject.CompareTag("Ground"))
            || (rayRight.collider != null && rayRight.collider.gameObject.CompareTag("Ground")))
        {
            Debug.Log("Ground Detected");
            _animator.SetBool("IsJumping", false);
            return false;
        }

        _animator.SetBool("IsJumping", true);
        return true;
    }
}