using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSugar : MonoBehaviour
{
    public GameObject sugarPrefab;

    public GameObject[] sugarPrefabCount;

    bool start = true;
    public void Start()
    {
        StartCoroutine(Istantiate());
    }
    public void Update()
    {
        sugarPrefabCount = GameObject.FindGameObjectsWithTag("Sugar");
        if(sugarPrefabCount.Length >= 399)
        {
            start = false;
        }
        else if(sugarPrefabCount.Length == 0)
        {
            start = true;
        }
    }
    public void Restart()
    {
        foreach (GameObject sugar in sugarPrefabCount)
        {
            Destroy(sugar);
        }
        Start();
    }
    IEnumerator Istantiate()
    {
        yield return new WaitForSeconds(2f);
        while (start)
        {
            yield return new WaitForSeconds(0.05f);
            Instantiate(sugarPrefab, transform.position, Quaternion.identity);
        }
    }
}
