using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public static RaceManager Instance { get; private set; }

    public LapCounter lapCounter;

    private int playerPosition = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayerFinishedLaps()
    {
        // Increment the player position and determine the final position
        playerPosition++;
        int finalPosition = DetermineFinalPosition(playerPosition);

        // Perform actions based on the final position
        switch (finalPosition)
        {
            case 1:
                Debug.Log("Player finished in 1st position!");
                // Add code for 1st place
                break;
            case 2:
                Debug.Log("Player finished in 2nd position!");
                // Add code for 2nd place
                break;
            case 3:
                Debug.Log("Player finished in 3rd position!");
                // Add code for 3rd place
                break;
            case 4:
                Debug.Log("Player finished in 4th position!");
                // Add code for 4th place
                break;
            default:
                Debug.Log("Player finished in a non-determinable position.");
                break;
        }
    }

    private int DetermineFinalPosition(int playerPosition)
    {
        // You can add your own logic here to determine the final position based on the number of players and their positions
        return playerPosition;
    }
}

