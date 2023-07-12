using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTimer : MonoBehaviour
{
   float currentTime = 0f;
   float startingTime = 10f;

   public Text StartTimerText;

   void start()
    {
        currentTime = startingTime;
    }

    void update()
    {
        currentTime -= 1 * Time.deltaTime;
        print (currentTime);  
    }
}
