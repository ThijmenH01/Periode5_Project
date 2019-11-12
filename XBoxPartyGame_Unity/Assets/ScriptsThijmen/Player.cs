﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

[RequireComponent( typeof( Rigidbody ) )]
public class Player : MonoBehaviour {

    public enum TargetState {
        color = 0,
        text
    }

    public TargetState targetState;

    [SerializeField] private float moveSpeed = 7.5f;
    [SerializeField] private float smoothMoveTime = 0.1f;
    [SerializeField] private float turnSpeed = 8;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private int playerScore = 0;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private TextMeshProUGUI targetText;
    [SerializeField] private TextMeshProUGUI playerScoreText;
    [SerializeField] private GameObject m_Target;

    private float angle;
    private float smoothInputMagnitude;
    private float smoothMoveVelocity;
    private bool disabled;
    private Vector2 moveInput;
    private ColorTile colorTile;
    private string targetColorText;

    private void Start() {
        TargetStateBehavior();
        //SetUIActive();
    }

    private void Update() {
        if(transform.position.y < -15) {
            ResetPosition();
        }

        if(Input.GetKeyDown( KeyCode.Joystick1Button0 )) {
            //Make Sprint
        }
    }

    #region Movement
    private void FixedUpdate() {
        rb.MoveRotation( Quaternion.Euler( Vector3.up * angle ) );
        Move();
    }

    public void OnMovement(InputAction.CallbackContext context) {
        moveInput = context.ReadValue<Vector2>();
    }

    private void Move() {
        if(!disabled) {
            Vector3 _inputDirection = new Vector3( moveInput.x , 0 , moveInput.y );

            float _inputMagnitude = _inputDirection.magnitude;
            smoothInputMagnitude = Mathf.SmoothDamp( smoothInputMagnitude , _inputMagnitude , ref smoothMoveVelocity , smoothMoveTime );

            float _targetAngle = Mathf.Atan2( _inputDirection.x , _inputDirection.z ) * Mathf.Rad2Deg;
            angle = Mathf.LerpAngle( angle , _targetAngle , Time.deltaTime * turnSpeed * _inputMagnitude );

            Vector3 velocity = transform.forward * moveSpeed * smoothInputMagnitude;
            rb.MovePosition( rb.position + velocity * Time.deltaTime );
        }
    }
    #endregion

    private void TargetStateBehavior() {
        m_Target = MiniGameManager.instance.tiles[Random.Range( 0 , MiniGameManager.instance.tiles.Length )];
        targetColorText = m_Target.GetComponent<ColorTile>().text;

        if(targetState == TargetState.color) {
            targetText.text = "Color";
            targetText.color = m_Target.GetComponent<Renderer>().material.color;
            AddScore( 1 );
        }

        if(targetState == TargetState.text) {
            targetText.text = "Text";
            if(targetColorText == "CYAN") {
                targetText.color = Color.cyan;
                AddScore( 1 );
            }

            if(targetColorText == "RED") {
                targetText.color = Color.red;
                AddScore( 1 );
            }

            if(targetColorText == "PINK") {
                targetText.color = Color.magenta;
                AddScore( 1 );
            }

            if(targetColorText == "YELLOW") {
                targetText.color = Color.yellow;
                AddScore( 1 );
            }

            if(targetColorText == "BLUE") {
                targetText.color = Color.blue;
                AddScore( 1 );
            }

            if(targetColorText == "GREEN") {
                targetText.color = Color.green;
                AddScore( 1 );
            }
            targetText.ForceMeshUpdate();
        }
    }

    private void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Tile") {
            colorTile = col.GetComponent<ColorTile>();
            if(colorTile.color == m_Target.GetComponent<ColorTile>().color || targetColorText == colorTile.text) {
                GivePlayerTarget();
                TargetStateBehavior();
            }
            print( col.name );
        }
    }

    public void GivePlayerTarget() {
        int playerTargetEnumInt = Random.Range( 0 , 2 );
        targetState = (TargetState)playerTargetEnumInt;
    }

    private void ResetPosition() {
        transform.position = spawnPoint.position;
    }

    private void AddScore(int scoreAddon) {
        playerScore += scoreAddon;
        playerScoreText.text = playerScore.ToString();
    }

    public void DisableUI() {
        if(!gameObject.activeSelf) {
            targetText.enabled = false;
            playerScoreText.enabled = false;
        }
    }
}
