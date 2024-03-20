using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatueQTE : MonoBehaviour
{
    public float fillAmount = 0;
    public float timeThreshold = 0;
    public string eventSuccess = "n";

    private GameObject trigger;
    private Animator anim;
    public bool isFalling;
    public bool inProxim = false;

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Statue").GetComponent<Animator>();   
        trigger = GameObject.FindGameObjectWithTag("QTETrigger").GetComponent<GameObject>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {           
            inProxim = true;
            anim.SetBool("StatueHighlight", true);
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inProxim = false;
            anim.SetBool("StatueHighlight", false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("e") && inProxim == true)
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

        if (fillAmount > 1)
        {
            eventSuccess = "y";
            Debug.Log(eventSuccess);
            isFalling = !isFalling;
            Destroy(gameObject);
            Destroy(GameObject.FindWithTag("StatueWall"));
            anim.SetBool("StatueFall", true);
            FindObjectOfType<SoundManager>().Play("StatueFall");
        }

        if (GetComponent<Image>() != null)
        {
            GetComponent<Image>().fillAmount = fillAmount;
        }
    }
}
