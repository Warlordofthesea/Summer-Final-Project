using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LapCounterUI : MonoBehaviour
{
    public LapCounter lapCounter;
    private Text lapText;

    private void Start()
    {
        lapText = GetComponent<Text>();
        UpdateLapText();
    }

    private void UpdateLapText()
    {
        lapText.text = "Lap: " + lapCounter.CurrentLap.ToString();
    }
}

