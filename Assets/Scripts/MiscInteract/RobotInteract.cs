using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotInteract : MonoBehaviour
{
    public bool inRobot = false;   

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRobot = true;           
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRobot = false;           
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRobot == true)
        {
            FindObjectOfType<SoundManager>().Play("RobotInteract");           
        }
    }
}
