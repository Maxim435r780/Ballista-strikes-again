using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTPSController : MonoBehaviour
{
    public float Gravity = 9.8f;
    public float JumpForce = 7;
    public float Speed = 5;

    [SerializeField] private Animator _animator;

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
        _animator.SetInteger("Dir", 0);

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            _animator.SetInteger("Dir", 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            _animator.SetInteger("Dir", 1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            _animator.SetInteger("Dir", 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            _animator.SetInteger("Dir", -1);
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
        _characterController.Move(_moveVector * Speed * Time.fixedDeltaTime);

        //Gravity + =Jump
        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
        _fallVelocity += Gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
    }
}
