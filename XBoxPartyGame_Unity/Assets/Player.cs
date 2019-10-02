using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {
    
    //PlayerInput playerInput;

    public float moveSpeed = 7.5f;
    public float smoothMoveTime = 0.1f;
    public float turnSpeed = 8;

    private float angle;
    private float smoothInputMagnitude;
    private float smoothMoveVelocity;
    private bool disabled;
    private string vertical;
    private string horizontal;
    private Vector3 velocity;
    //private Vector2 move;
    private Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
        //playerInput = new PlayerInput();
        //playerInput.PlayerInputActionMap.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
        //playerInput.PlayerInputActionMap.Movement.canceled += ctx => move = Vector2.zero;
    }

    void Update() {
        //Vector2 _move = new Vector2(move.x , move.y) * Time.deltaTime;
        Movement();
    }

    private void FixedUpdate() {
        rb.MoveRotation(Quaternion.Euler(Vector3.up * angle));
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }

    private void Movement() {
        Vector3 _inputDirection = Vector3.zero;
        if(!disabled)
            _inputDirection = new Vector3(Input.GetAxisRaw("Horizontal") , 0 , Input.GetAxisRaw("Vertical")).normalized;
        float _inputMagnitude = _inputDirection.magnitude;
        smoothInputMagnitude = Mathf.SmoothDamp(smoothInputMagnitude , _inputMagnitude , ref smoothMoveVelocity , smoothMoveTime);

        float _targetAngle = Mathf.Atan2(_inputDirection.x , _inputDirection.z) * Mathf.Rad2Deg;
        angle = Mathf.LerpAngle(angle , _targetAngle , Time.deltaTime * turnSpeed * _inputMagnitude);

        velocity = transform.forward * moveSpeed * smoothInputMagnitude;
    }

    //private void OnEnable() {
    //    playerInput.PlayerInputActionMap.Enable();
    //}
    //private void OnDisable() {
    //    playerInput.PlayerInputActionMap.Disable();
    //}
}
