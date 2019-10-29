using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour {
    public static MiniGameManager instance;

    int playerCount;
    public Player[] players;
    public GameObject[] tiles;

    private void Awake() {
        instance = this;
    }

    void Start() {
        for(int i = 0; i < players.Length; i++) {
            if(i < GameManager.instance.m_playerAmountChosen) {
                players[i].gameObject.SetActive( true );
            } else {
                players[i].gameObject.SetActive( false );
            }
        }
        playerCount = GameManager.instance.m_playerAmountChosen;
        LoopTroughPlayers();
    }

    void Update() {

    }

    private void LoopTroughPlayers() {
        for(int i = 0; i < playerCount; i++) {
            players[i].GivePlayerTarget();
        }
    }
}
