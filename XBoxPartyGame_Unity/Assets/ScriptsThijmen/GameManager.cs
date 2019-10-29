using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public int m_playerAmountChosen;
    public GameObject[] tiles;

    private void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy( gameObject );
        }
    }


    private void Start() {
        //players = new Player[m_playerAmountChosen];
        DontDestroyOnLoad( this );
    }

    public void SetPlayerCount(int playersFromSlider) {
        m_playerAmountChosen = playersFromSlider;
        //players = new Player[m_playerAmountChosen];
    }
}
