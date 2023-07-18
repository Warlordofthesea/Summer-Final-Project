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

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    [Header("Format Settings")]
    public TimerFormats format;
    private Dictionary<TimerFormats, string> timeFormats = new Dictionary<TimerFormats, string>();

    [Header("Game Over")]
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        timeFormats.Add(TimerFormats.Whole, "0");
        timeFormats.Add(TimerFormats.TenthDecimal, "0.0");
        timeFormats.Add(TimerFormats.HundrethsDecimal, "0.00");
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        if(hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >=timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;

            // Trigger Game over scrren
            GameOver();

        }
        

        SetTimerText();
    }

    private void SetTimerText()
    { 
        timerText.text = currentTime.ToString("0.0");
    }

    private void GameOver()
    {
        // Show game over panel
        gameOverPanel.SetActive(true);

    }
}

public enum TimerFormats
{
    Whole,
    TenthDecimal,
    HundrethsDecimal
}