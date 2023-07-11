using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [Header("Componet")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        if(hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >=timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.Color = Color.red;
            enabled = false;
        }
        

        SetTimerText();
    }

    private void SetTimerText()
    { 
        timerText.Text = currentTime.ToString();
    }
}