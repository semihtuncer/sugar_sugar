using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCupManager : MonoBehaviour
{
    public BoxCollider2D boxCol;
    public int prefabIn;

    public Animator transition;

    public bool playButton;
    public bool levelsButton;
    public bool exitButton;
    public GameObject[] lines;
    private void Update()
    {
        lines = GameObject.FindGameObjectsWithTag("Line");
        if (playButton)
        {
            if (prefabIn >= 100)
            {
                StartCoroutine(LoadScene(1));
            }
        }
        if (levelsButton)
        {
            if (prefabIn >= 100)
            {
                StartCoroutine(LoadScene(4));
            }
        }
        if (exitButton)
        {
            if (prefabIn >= 100)
            {
                Application.Quit();
            }
        }
    }
    public void Clear()
    {
        foreach (GameObject line in lines)
        {
            Destroy(line);
        }
    }
    public IEnumerator LoadScene(int sceneNum)
    {
        transition.SetTrigger("End");
        yield return new WaitForSeconds(0.66f);
        SceneManager.LoadScene(sceneNum);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sugar")
            prefabIn++;
    }
}
