using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playsoundplane : MonoBehaviour
{
    public float planeTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (PlayPlane());
    }

   IEnumerator PlayPlane()
   {
    yield return new WaitForSeconds(planeTime);
    FindObjectOfType<SoundManager>().Play("Plane");
   }
}
