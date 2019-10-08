using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTile : MonoBehaviour {

    public string color;
    public string text;

    void Start(){
        
    }

    void Update(){
        transform.rotation = Quaternion.Euler( 0 , 0 , 0 );
    }
}
