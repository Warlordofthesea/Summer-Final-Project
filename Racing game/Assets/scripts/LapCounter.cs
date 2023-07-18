using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapCounter : MonoBehaviour
{
    public int totalLaps = 3;
    private int currentLap = 0;

    public int CurrentLap { get { return currentLap; } }

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
    