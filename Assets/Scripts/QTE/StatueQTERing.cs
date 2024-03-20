using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatueQTERing : MonoBehaviour
{
    public float fillAmount = 0;
    public float timeThreshold = 0;
    public string eventSuccess = "n";
    
    //This is to show the QTE Ring during the statue but the script "StatueQTE" determines the event success
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            fillAmount += 0.1f;
        }
        timeThreshold += Time.deltaTime;

        if (timeThreshold > 0.05)
        {
            timeThreshold = 0;
            fillAmount -= 0.02f;
        }
        if (fillAmount < 0)
        {
            fillAmount = 0;
        }
              
        GetComponent<Image>().fillAmount = fillAmount;        
    }
}
