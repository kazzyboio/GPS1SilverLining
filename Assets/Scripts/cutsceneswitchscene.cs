using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutsceneswitchscene : MonoBehaviour
{
    public float waitEnd = 5f;
    public float transTime = 1f;
    public Animator transition;

    // Start is called before the first frame update
    void Start()
    {   
        StartCoroutine(WaitforVideoEnd());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(SkipVideo());
        }

        IEnumerator SkipVideo()
        {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transTime);
        SceneManager.LoadScene(1);
        }
    }

     IEnumerator WaitforVideoEnd()
    {
        yield return new WaitForSeconds(waitEnd);
        SceneManager.LoadScene(1);
    }

    
}
