using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BenchInteract : MonoBehaviour
{
    public bool inBench = false;
    public Animator transition;
    public float transTime = 1f;
    private Animator anim;

    private void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Bench").GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inBench = true;
            anim.SetBool("BenchHighlight", true);
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inBench = false;
            anim.SetBool("BenchHighlight", false);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inBench == true)
        {           
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transTime);

        SceneManager.LoadScene(levelIndex);
    }
}
