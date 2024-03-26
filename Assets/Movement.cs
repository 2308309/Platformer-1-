using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Acceleration = 10f;
    public float JumpForce = 50f;
    //ground check
    public Transform GroundCheck;
    public float GroundCheckRadius = 1f;
    public float MaxSlopeAngle = 45f;

    public Cooldown CoyoteTime;
    public Cooldown BufferJump;

    public bool _isGrounded = false;
    public bool _isJumping = false;

    public LayerMask GroundLayerMask;

    protected Vector2 _inputDirection;

    protected Rigidbody2D _rigidbody2D;
    protected Collider2D _collider2D;

    public bool IsJumping
    {
        get { return _isJumping; }
    }
    public bool IsFalling
    {
        get { return _isFalling; }
    }
    public bool IsRunning
    {
        get { return _isRunning; }
    }

    public bool _isJumping = false;
    public bool _isFalling = false;
    public bool _isRunning = false;
    protected bool _canJump = true;
    private bool _disableInput = false;

    public Vector2 InputDirection
    {
        get { return _inputDirection; }
        set { _inputDirection = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        //cache our components for later use
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void FixedUpdate()
    {
        CheckGround();

        HandleMovement();
    }

    void HandleInput()
    {
        _inputDirection = new Vector2(x: Input.GetAxis("Horizontal"), y: Input.GetAxis("Vertical"));
    }

    protected void BufferJump()
    {
        BufferJump.StartCooldown();
    }

    protected virtual void DoJump()
    {
        //cooldown check is needed

        if (!_canJump)
        {
            Debug.Log(message: "cannot jump");
            return;
        }

        if (CoyoteTime.CurrentProgress == Cooldown.Progress.Finished)
        {
            Debug.Log(message: "coyote time over");
            return;
        }

        _canJump = false;
        _isJumping = true;

        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, y: JumpForce);

        Debug.Log(message: "jumping");

        CoyoteTime.StopCooldown();
    }

    void HandleMovement()
    {
        Vector3 targetVelocity = Vector3.zero;

        if (_isGrounded && _isJumping)

        targetVelocity = new Vector2(x: _inputDirection.x * (Acceleration), y: 0f);

        _rigidbody2D.velocity = targetVelocity;
    }

    void CheckGround()
    {
        _isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, GroundLayerMask);
    }

    protected virtual void Flip()
    {
        //if (_inputDirection.x) ;
    }
}
