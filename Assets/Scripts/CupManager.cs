using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CupManager : MonoBehaviour
{
    public BoxCollider2D boxCol;
    public Text cupText;
    public int prefabIn;

    public int whichLevel;

    public Animator transition;
    private void Update()
    {
        if (!(prefabIn >= 101))
        {
            cupText.text = prefabIn.ToString();
        }
        else
        {
            StartCoroutine(LoadScene(whichLevel));
        }
    }
    public IEnumerator LoadScene(int whichLevel)
    {
        transition.SetTrigger("End");
        yield return new WaitForSeconds(0.66f);
        SceneManager.LoadScene(whichLevel);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Sugar")
             prefabIn++;
    }
}
