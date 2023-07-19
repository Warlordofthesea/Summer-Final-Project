using UnityEngine;

public class RaceManager : MonoBehaviour
{
    private int lapCount = 0;
    private int requiredLaps = 3;

    public static RaceManager Instance { get; private set; }

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

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IncreaseLapCount();
            int lapCount = GetLapCount();
            LapCounter lapCounter = FindObjectOfType<LapCounter>();
            Debug.Log("Lap Complete");

            if (lapCounter != null)
            {
                lapCounter.UpdateLapCount(lapCount);
            }
        }
    }

    public void IncreaseLapCount()
    {
        lapCount++;

        if (lapCount >= requiredLaps)
        {
            // Call the game over or win condition method here
            // You can trigger the game over panel or any other logic you desire
        }
    }

    public int GetLapCount()
    {
        return lapCount;
    }

    // Other methods and logic for lap counting
}
