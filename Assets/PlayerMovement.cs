using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float JumpHeldForce = 5f;
    public float JumpHeldMaxDuration = 0.5f;

    private float _JumpHeldCurrentDuration = 0f;
    //private float _inputJumped = false;

    // Start is called before the first frame update
    protected override void HandleInput()
    {
        _inputDirection = new Vector2(Input.GetAxis("Horizontal"), 0f);

        if (Input.GetButtonDown("Jump"))
            DoJump();
    }

    protected virtual void CheckGround()
    {

    }

    protected virtual void HandleMovement()
    {
        Vector3 targetVelocity = Vector3.zero;

        if (_isGrounded && !_isJumping)
        {
            targetVelocity = new Vector2(x: _inputDirection.x * (Acceleration), y: 0f);
        }
    }
}
