using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatInteract : MonoBehaviour
{
    public bool inCat = false;
    public Animator transition;
    public float transTime = 1f;
    private Animator anim;

    private void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Cat").GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inCat = true;
            anim.SetBool("CatHighlight", true);
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inCat = false;
            anim.SetBool("CatHighlight", false);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inCat == true)
        {
            Destroy(GameObject.FindWithTag("CanvasInteract"));
            FindObjectOfType<SoundManager>().Play("CatMeow");
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
