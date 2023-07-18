using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LapCounter : MonoBehaviour
{
    public int totalLaps = 3;
    private int currentLap = 0;

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

    public int CurrentLap { get { return currentLap; } }

    [Header("Component")]
    public TextMeshProUGUI lapCounter;

    [Header("Lap Counter Settings")]
    public float currentLap;
    
    [Header("Lap Limit Settings")]
    public bool hasLimit;
    public float lapLimit;

    public void IncrementLap()
    {
        currentLap++;
        

        if (currentLap >= totalLaps)
        {
            // Inform the RaceManager that the player has finished all laps
            RaceManager.Instance.PlayerFinishedLaps();
        }
    }
}
    