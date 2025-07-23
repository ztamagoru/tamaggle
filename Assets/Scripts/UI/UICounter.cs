using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICounter : MonoBehaviour
{
    TMPro.TMP_Text counterText;

    void Start()
    {
        counterText = GetComponent<TMPro.TMP_Text>();

        BallCounter.counter.counterChange += UpdateCounterText;
        UpdateCounterText(BallCounter.counter.numBall);
    }

    void UpdateCounterText(int numBall)
    {
        counterText.text = "balls:" + numBall.ToString();
    }
}
