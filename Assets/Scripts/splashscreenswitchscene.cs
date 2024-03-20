using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class splashscreenswitchscene : MonoBehaviour
{
    public float waitEnd = 5f;

    // Start is called before the first frame update
    void Start()
    {   
        StartCoroutine(WaitforVideoEnd());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

     IEnumerator WaitforVideoEnd()
    {
        yield return new WaitForSeconds(waitEnd);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
