using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMap : MonoBehaviour {
    [SerializeField] private float rotateSpeed;

    void Start() {

    }

    void Update() {
        Rotate();
    }

    private void Rotate() {
        transform.Rotate( 0 , rotateSpeed * Time.deltaTime , 0 );
    }
}
