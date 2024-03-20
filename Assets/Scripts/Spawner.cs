using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    bool inTrigger = false;

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            inTrigger = true;
        }
    }
    
    public void SpawnObject()
    {
        if (inTrigger = true)
        {
        Instantiate(objectToSpawn, transform.position, transform.rotation);
        }
    }
    
}
