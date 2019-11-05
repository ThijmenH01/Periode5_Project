using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetup : MonoBehaviour
{
    [SerializeField] private Text playerCount;
    [SerializeField] private Slider playerSelectSlider;

    private void Start() {
        playerSelectSlider = GetComponent<Slider>();
    }

    private void Update() {
        playerCount.text = playerSelectSlider.value.ToString() + " PLAYERS";
    }

    public void StartGame(float count)
    {
        GameManager.instance.SetPlayerCount((int)count);
    }
}
