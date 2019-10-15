using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour {

    int playerCount;
    public Player[] players;

    private void Awake() {
        
    }

    void Start(){
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

    void Update(){
        
    }

    private void LoopTroughPlayers() {
        for(int i = 0; i < playerCount; i++) {
            players[i].GivePlayerTarget();
        }
    }
}
