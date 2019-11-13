using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class XInputVibrateTest : MonoBehaviour
{
    //public float testA;
    //public float testB;
    public IEnumerator StartRumble(PlayerIndex playerIndex, float time, float strength)
    {
        GamePad.SetVibration(playerIndex, strength, strength);
        yield return new WaitForSeconds(time);
        GamePad.SetVibration(playerIndex, 0, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(StartRumble(PlayerIndex.One, 5f, 2f));

    }

    // Update is called once per frame
    void Update()
    {
        //GamePad.SetVibration(PlayerIndex.Two, testA, testB);
    }
}
