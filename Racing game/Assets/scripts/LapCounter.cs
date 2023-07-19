using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class LapCounter : MonoBehaviour
{
    public TextMeshProUGUI lapCountText;

    public void UpdateLapCount(int lapCount)
    {
        lapCountText.text = "Lap: " + lapCount.ToString();
    }
}
