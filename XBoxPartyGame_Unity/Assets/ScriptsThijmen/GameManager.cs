using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public int m_playerAmountChosen;
    public bool gameIsOver = false;
    public GameObject gameOverScreen;

    private void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy( gameObject );
        }
    }

    private void Update() {
        if(Input.GetKeyDown( KeyCode.Space ) && Countdown.instance.stop)
            RestartGame();

        if(Countdown.instance.timeLeft <= 0) {
            GameFinished();
        }

        if(Input.GetKeyDown( KeyCode.Escape )) {
            SceneManager.LoadScene( 0 );
        }
    }

    private void Start() {
        DontDestroyOnLoad( this );
    }

    public void SetPlayerCount(int playersFromSlider) {
        m_playerAmountChosen = playersFromSlider;
    }

    public void GameOver() {
        Time.timeScale = 0f;
    }

    public void RestartGame() {
        print( "Resrtarted" );
        Time.timeScale = 1;
        SceneManager.LoadScene( 1 );
    }

    public void GameFinished() {
        gameOverScreen.SetActive( true );
        gameIsOver = true;
        if(Input.GetKeyDown( KeyCode.Joystick1Button0 ) && gameIsOver) {
            Time.timeScale = 1;
            SceneManager.LoadScene( 1 );
        }
    }
}
