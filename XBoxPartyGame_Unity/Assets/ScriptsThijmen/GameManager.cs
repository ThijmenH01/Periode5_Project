using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public int playerAmountActive;
    public Player[] players;

    private void Awake() {
        instance = this;
    }


    private void Start() {
        DontDestroyOnLoad( this );
        LoopTroughPlayers();
    }

    private void LoopTroughPlayers() {
        for(int i = 0; i < players.Length; i++) {
            players[i].GivePlayerTarget();
        }
    }
}
