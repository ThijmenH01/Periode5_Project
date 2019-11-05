using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetup : MonoBehaviour
{
    public void StartGame(float count)
    {
        GameManager.instance.SetPlayerCount((int)count);
    }
}
