using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private bool isEnter;
    private string loadScene;
    public Animator transition;
    public float transTime = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }

        IEnumerator LoadLevel (int levelIndex)
        {
            transition.SetTrigger("Start");

            yield return new WaitForSeconds(transTime);

            SceneManager.LoadScene(levelIndex);
        }
    }
}
