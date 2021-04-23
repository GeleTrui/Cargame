using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public AudioSource levelComplete;
    public AudioSource carSound;
    public GameObject GlobalTimer;
    public GameObject timeLeft;
   
    
    void OnTriggerEnter()
    {
        
        GlobalTimer.SetActive(false);
        levelComplete.Play();
        carSound.Play();
        StartCoroutine(calculateScore());
        StartCoroutine(NextLevel());
    }

    IEnumerator calculateScore()
    {
        timeLeft.SetActive(true);
        yield return new WaitForSeconds(1);
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(3);
    }
}
