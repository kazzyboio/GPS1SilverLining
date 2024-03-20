using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Animator canAnim;

    public void CamShake()
    {
        FindObjectOfType<SoundManager>().Play("GroundRumble");
        FindObjectOfType<SoundManager>().Play("StatueFall");
        Debug.Log("Camera Shaking");
        canAnim.SetTrigger("shake");
    }
}
