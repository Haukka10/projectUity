using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ORB : MonoBehaviour
{
    private Vector3 startVECTOR;

    public double slow;
    public GameObject perf;
    public float slowF;
    public float speed;
    public bool SpeedUP;
    public bool slowBool;
    public int etep;
    public bool x;
    public bool y;
    public bool z;
    public bool stopX;
    public bool stopY; 
    public bool stopZ;
    public bool SaX;
    public bool SaZ;
    public bool SaY;
    public float time = 10;
    public float timeP = 10;
    public float time_out = 2;
    public int Warning;
    public int direction;
    private bool Trigger;
    public counterORB counterORB;
    private void Awake() {

       try
       {
        SaX = stopX;
        SaY = stopY;
        SaZ = stopZ;
        startVECTOR = transform.position;
        Debug.Log("save position set");
       }

       catch (System.Exception)
       {
           Debug.LogError("save position not set");
           throw;
       }

    }


    void start() {

        perf.SetActive(false);
    }

    void Update()
    {  

        if(slowBool)
        {

        if (stopX == false)
                {
                    switch (x)
                    {
                        case true:
                            gameObject.transform.position = transform.position + new Vector3(slowF * Time.deltaTime, 0, 0);
                            break;
                        case false:
                            gameObject.transform.position = transform.position + new Vector3(-(slowF * Time.deltaTime), 0, 0);
                            break;
                    }
                }
                if (stopY == false)
                {
                   switch (y)
                    {
                        case true:
                            gameObject.transform.position = transform.position + new Vector3(0, slowF * Time.deltaTime, 0);
                            break;
                        case false:
                            gameObject.transform.position = transform.position + new Vector3(0, -(slowF * Time.deltaTime), 0);
                            break;
                    }
                }
                if (stopZ == false)
                {
                    switch (z)
                    {
                        case true:
                            gameObject.transform.position = transform.position + new Vector3(0, 0, slowF * Time.deltaTime);
                            break;
                        case false:
                            gameObject.transform.position = transform.position + new Vector3(0, 0, -(slowF * Time.deltaTime));
                            break;
                    }
                }
                time = time - Time.deltaTime;
                timeP = timeP - Time.deltaTime;
    }else{
        if (stopX == false)
                {
                    switch (x)
                    {
                        case true:
                            gameObject.transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
                            break;
                        case false:
                            gameObject.transform.position = transform.position + new Vector3(-(speed * Time.deltaTime), 0, 0);
                            break;
                    }
                }
                if (stopY == false)
                {
                    switch (y)
                    {
                        case true:
                            gameObject.transform.position = transform.position + new Vector3(0, speed * Time.deltaTime, 0);
                            break;
                        case false:
                            gameObject.transform.position = transform.position + new Vector3(0, -(speed * Time.deltaTime), 0);
                            break;
                    }
                }
                if (stopZ == false)
                {
                    switch (z)
                    {
                        case true:
                            gameObject.transform.position = transform.position + new Vector3(0, 0, speed * Time.deltaTime);
                            break;
                        case false:
                            gameObject.transform.position = transform.position + new Vector3(0, 0, -(speed * Time.deltaTime));
                            break;
                    }
                }
    }
     if(time <= 0 )
     {
         slowBool = false;
         time = 10;
     }
        switch(slowBool)
        {
        case true:
                if (!(slowBool = true))
                {
                    Debug.LogWarning("slow bool is :"+ slowBool+" fix pls");
                }
                
                break;
        case false:
        stopY = SaY;
        stopZ = SaZ;
        stopX = SaX;
        break;
        }
if(Trigger == true){
    time_out = time_out - Time.deltaTime;
    if(time_out <= 0)
    Trigger = false;

     switch(direction)
     {
        case 1:
        gameObject.transform.position = transform.position + new Vector3(slowF * Time.deltaTime, 0, 0);
        break;
        case 2:
        gameObject.transform.position = transform.position + new Vector3(0, -(slowF * Time.deltaTime), 0);
        break;
        case 3:
        gameObject.transform.position = transform.position + new Vector3(0, slowF * Time.deltaTime, 0);
        break;
        case 4:
        gameObject.transform.position = transform.position + new Vector3(-(slowF * Time.deltaTime), 0, 0);
        break;
     }
}else
{
    
    Trigger = false;
    time_out = 2;
}

}    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "boll")
        {

            slow = 0.25 * speed;
            slowF = (float)slow;
            slowBool = true;
        }

            if(other.tag == "right")
                {
                    Trigger = true;
                    direction = 1;

                }

                if(other.tag == "down")
                {
                   Trigger = true;
                   direction = 2;
                }
                if(other.tag == "up")
                {
                    
                    Trigger = true;
                    direction = 3;
                }

                if(other.tag == "left")
                {
                    Trigger = true;
                    direction = 4;
                }
                
            if(other.tag == "CheckEnd")
            {
               counterORB.GetComponent<counterORB>().timeISStart = true;
            }

        if(other.tag == "Check")
            MOVE();

        if(speed <= 50)
            if(SpeedUP == true)
            {
                speed += 1;
                etep += 1;
            }

        //Debug.Log(speed + " and etap: " + etep);

        if (other.tag == "CheckRV")
            REMOVE();
            
       if(other.tag == "wall"){
           if(Warning >= 0)
            {   
                gameObject.transform.position = startVECTOR;
                Warning += 1;
                            
                switch (Warning)
                {
                    case 1:
                    speed += 2;
                    break;
                    case 2:
                    gameObject.transform.position = startVECTOR;
                    
                    break;

                }
            }
       }

    }
    public void MOVE()
    {
         if (z == true)
            z = false;
        if (y == true)
            y = false;
        if (x == true)
            x = false;
    }
    public void REMOVE()
    {
        if (z == false)
                z = true;
            if (y == false)
                y = true;
            if (x == false)
                x = true;
    }
}