using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTESystem : MonoBehaviour
{
    public float fillAmount = 0;
    public float timeThreshold = 0;
    public string eventSuccess = "n";
    private Animator anim;

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Rubble").GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            fillAmount += 0.2f;
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

        if (fillAmount > 1)
        {
            eventSuccess = "y";
            Debug.Log(eventSuccess);
            FindObjectOfType<SoundManager>().Play("RubbleBreak");
            Destroy(gameObject);                     
            Destroy(GameObject.FindWithTag("QTE"));
            Destroy(GameObject.FindWithTag("RubbleWall"));           
            anim.SetBool("RubbleBreak", true);
        }

        GetComponent<Image>().fillAmount = fillAmount;
    }
}
