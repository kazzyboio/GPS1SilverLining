using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlobInteract : MonoBehaviour
{
    public bool inBlob = false;
    public Animator transition;
    public float transTime = 1f;
    private Animator anim;

    private void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Blob").GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inBlob = true;
            anim.SetBool("BlobHighlight", true);
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inBlob = false;
            anim.SetBool("BlobHighlight", false);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inBlob == true)
        {
            FindObjectOfType<SoundManager>().Play("BlobInteract");
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    IEnumerator LoadLevel (int levelIndex)
        {
            transition.SetTrigger("Start");

            yield return new WaitForSeconds(transTime);

            SceneManager.LoadScene(levelIndex);
        }
}
