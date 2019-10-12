using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextTile : MonoBehaviour {

    [SerializeField] private MeshRenderer tileMeshRenderer;
    [SerializeField] private TextMeshPro tileText;
    [SerializeField] private ColorTile colorTileParent;

    void Start() {

        float r = tileMeshRenderer.material.color.r;
        float g = tileMeshRenderer.material.color.g;
        float b = tileMeshRenderer.material.color.b;

        tileText.text = colorTileParent.text; // Sets the text on the tile to the text given from the script on the tile.
        tileText.color = new Color( Mathf.Abs( r - 1f ) , Mathf.Abs( g - 1f ) , Mathf.Abs( b - 1f ) );
    }

    void Update() {
    }
}
