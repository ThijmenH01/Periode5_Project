using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    
    public int m_playerAmountChosen;

    private void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy( gameObject );
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Countdown.instance.stop) RestartGame();
    }

    private void Start() {
        DontDestroyOnLoad( this );
    }

    public void SetPlayerCount(int playersFromSlider) {
        m_playerAmountChosen = playersFromSlider;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        print("Resrtarted");
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
    }
}
