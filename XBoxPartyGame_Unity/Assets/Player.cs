using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 7.5f;
    public float smoothMoveTime = 0.1f;
    public float turnSpeed = 8;
    float angle;
    float smoothInputMagnitude;
    float smoothMoveVelocity;
    bool disabled;
    Vector3 velocity;
    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        Vector3 _inputDirection = Vector3.zero;
        if(!disabled) _inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        float _inputMagnitude = _inputDirection.magnitude;
        smoothInputMagnitude = Mathf.SmoothDamp(smoothInputMagnitude, _inputMagnitude, ref smoothMoveVelocity, smoothMoveTime);

        float _targetAngle = Mathf.Atan2(_inputDirection.x, _inputDirection.z) * Mathf.Rad2Deg;
        angle = Mathf.LerpAngle(angle, _targetAngle, Time.deltaTime * turnSpeed * _inputMagnitude);

        velocity = transform.forward * moveSpeed * smoothInputMagnitude;
    }

    private void FixedUpdate() {
        rb.MoveRotation(Quaternion.Euler(Vector3.up * angle));
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }
}
