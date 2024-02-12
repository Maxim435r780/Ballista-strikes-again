using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTPSController : MonoBehaviour
{
    public float gravity = 9.8f;
    public float JumpForce = 7;
    public float speed = 1;

    private float _fallVelocity = 0;
    private CharacterController _characterController;
    private Vector3 _moveVector;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        //Move
        _moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -JumpForce;
        }
    }
    void FixedUpdate()
    {
        //Move
        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);

        //Gravity + =Jump
        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
    }
}
