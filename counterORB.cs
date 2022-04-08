using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class counterORB : MonoBehaviour
{
    public bool timeISStart;
    public float timeC = 1;
    public GameObject gameObject1;

    public void Awake() 
    {

    }

    public void Update()
    {

        if(timeISStart == true)
        {
            timeC = timeC - Time.deltaTime;
            Debug.Log(timeC);
            Destroy(gameObject1,1.2f);
        }

        if(timeC <= 0)
        {
            NextLevel();
            timeC = 1;
        }

    }
    void aa ()
    {
       Destroy(gameObject1,1.2f);
       NextLevel();
    }

    void NextLevel()
    {
        timeISStart = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}