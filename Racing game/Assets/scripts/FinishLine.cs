using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RaceManager.Instance.IncreaseLapCount();
            int lapCount = RaceManager.Instance.GetLapCount();
            LapCounter lapCounter = FindObjectOfType<LapCounter>();
            Debug.Log("Completed a lap");

            if (lapCounter != null)
            {
                lapCounter.UpdateLapCount(lapCount);
            }
        }
    }
}
