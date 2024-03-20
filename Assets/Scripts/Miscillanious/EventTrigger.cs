using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventTrigger : MonoBehaviour
{
    private Shake shake;
    public GameObject effect;
    public Spawner spawner;
    public SwitchScene switchScene;

    public bool levelTrigger;

    

    private void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        switchScene = GetComponent<SwitchScene>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Stage3Trigger"))
        {
            Debug.Log("Event 3 Triggered");
            shake.CamShake();
            spawner.SpawnObject();
            //SceneManager.LoadScene("Stage4");
            //ChangeScene();

        }

       
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("On Collision Enter");

        if (collision.gameObject.CompareTag("Skyscrapper"))
        {
            Debug.Log("Collided with Skyscrapper");
            SceneManager.LoadScene("Stage3.5");
            levelTrigger = true;
        }
    }

    public IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Stage3.5");
    }

}
