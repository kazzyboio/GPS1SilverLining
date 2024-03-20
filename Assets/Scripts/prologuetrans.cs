using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class prologuetrans : MonoBehaviour
{
    public float transTime = 10f;
    public float switchTime = 10f;
    public Animator transition; 
    public Animator cameraZoom;  
    bool fadeStart = false;                             
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartFade());
    }

    // Update is called once per frame
    void Update()
    {
       if (fadeStart = true); 
       {
        StartCoroutine(SwitchScene());
       }
    }

    IEnumerator StartFade()
    {
        yield return new WaitForSeconds(transTime);
        transition.SetTrigger("Start");
        cameraZoom.SetTrigger("Zoom");
        fadeStart = true;
    }

    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(switchTime);
        SceneManager.LoadScene(3);
    }
}
