using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playsoundnuke : MonoBehaviour
{
    public float sirenTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (PlaySiren());
    }

   IEnumerator PlaySiren()
   {
    yield return new WaitForSeconds(sirenTime);
    FindObjectOfType<SoundManager>().Play("Siren");
   }
}
