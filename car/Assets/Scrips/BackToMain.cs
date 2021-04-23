using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(BackBye());
    }
    IEnumerator BackBye()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(0);
    }
}
