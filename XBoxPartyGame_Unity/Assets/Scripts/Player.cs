using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {
    
    [SerializeField] private float moveSpeed = 7.5f;
    [SerializeField] private float smoothMoveTime = 0.1f;
    [SerializeField] private float turnSpeed = 8;
    [SerializeField] private Rigidbody rb;

    private float angle;
    private float smoothInputMagnitude;
    private float smoothMoveVelocity;
    private bool disabled;
    private string vertical;
    private string horizontal;
    private Vector2 moveInput;


    private void FixedUpdate() 
    {
        rb.MoveRotation(Quaternion.Euler(Vector3.up * angle));
        Move();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void Move() 
    {
        if (!disabled)
        {
            Vector3 _inputDirection = new Vector3(moveInput.x, 0, moveInput.y);

            float _inputMagnitude = _inputDirection.magnitude;
            smoothInputMagnitude = Mathf.SmoothDamp(smoothInputMagnitude, _inputMagnitude, ref smoothMoveVelocity, smoothMoveTime);

            float _targetAngle = Mathf.Atan2(_inputDirection.x, _inputDirection.z) * Mathf.Rad2Deg;
            angle = Mathf.LerpAngle(angle, _targetAngle, Time.deltaTime * turnSpeed * _inputMagnitude);

            Vector3 velocity = transform.forward * moveSpeed * smoothInputMagnitude;
            rb.MovePosition(rb.position + velocity * Time.deltaTime);

        }
    }

    
}
