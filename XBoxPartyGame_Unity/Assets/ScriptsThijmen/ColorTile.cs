using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTile : MonoBehaviour {

    public string color;
    public string text;

    void Start() {
        StartCoroutine(UpdateRotation( 0.1f ));
    }

    private IEnumerator UpdateRotation(float time) {
        while(true) {
            transform.rotation = Quaternion.identity;
            yield return new WaitForSeconds( time );
        }
    }
}
