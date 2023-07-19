using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LapCounter : MonoBehaviour
{
    [Header("Componet")]
    public TextMeshProUGUI lapText;

    [Header("Lap Settings")]
    public float currentLap;

    [Header("Lap Limit Settings")]
    public bool hasLimit;
    public float lapLimit;
}
