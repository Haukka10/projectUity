using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MOVEMENT : MonoBehaviour
{
    private int select;
    public float speed = 5f;
    public float sprint;
    public float gravity = -9.81f;
    public float time = 5;
    private float range;
    public Text text;
    public Vector3 vector;
    public LayerMask layerMask;
    public GameObject pref;
    public GameObject shadows;
    public Material myMaterial;
    public GameObject copy;
    public Vector3 vector3;
    public RectTransform RectTransform;
    public Camera cam;
    private RaycastHit hit;
    public CharacterController CharacterController;
    
    
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        CharacterController.Move(move * speed * Time.deltaTime);

        vector.y += gravity * Time.deltaTime;

        CharacterController.Move(vector * Time.deltaTime);

        // switch(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.LeftControl))
        // {
        //     default:
        //      sprint = speed * 2;

        //     CharacterController.Move(move * speed * Time.deltaTime);
        //     break;
        // }

        switch(select)
        {
            default:
            text.text = "Not selected yet";
            break;

            case 1:
            text.text = "select UP";
            break;
            
            case 2:
            text.text = "select Down";
            break;

            case 3:
            text.text = "select LEFT";
            break;

            case 4:
            text.text = "select Right";
            break;
        }

        if(Input.GetKey(KeyCode.Alpha1))
        {
            select = 1;
            range = 200;
        }
        if(Input.GetKey(KeyCode.Alpha2))
        {
            select = 2;
            range = 500;
        }
        if(Input.GetKey(KeyCode.Alpha3))
        {
            select = 3;
            range = 200;
        }
        if(Input.GetKey(KeyCode.Alpha4))
        {
            select = 4;
            range = 200;
        }
        if(Physics.Raycast(cam.transform.position,cam.transform.forward, out hit,range,layerMask))
        vector3 = hit.transform.position;

        if(Input.GetMouseButtonDown(0))
        {
            
            
            switch(select)
        {
            case 1:
            createUp(vector3,true);
            break;
            
            case 2:
            createDown(vector3,true);
            break;

            case 3:
            createLEFT(vector3,true);
            break;

            case 4:
            createRight(vector3,true);
            break;
        }
        }
    }
    public void createLEFT(Vector3 positionC,bool DestroyObject) // creates boll to move in left(L) , right(R) , up(U) , down(D) 
    {   
        pref = new GameObject("boll");
        pref.AddComponent<BoxCollider>().isTrigger = true;

        pref.tag = "left";
        pref.transform.position = positionC;
        
        if(DestroyObject == true)
        Destroy(pref,time);
        
    }
    public void createRight(Vector3 positionC,bool DestroyObject) // creates boll to move in left(L) , right(R) , up(U) , down(D) 
    {   
        pref = new GameObject("boll");
        pref.AddComponent<BoxCollider>().isTrigger = true;

        pref.tag = "right";
        pref.transform.position = positionC;
        
        if(DestroyObject == true)
        Destroy(pref,time);
        
    }
    public void createUp(Vector3 positionC,bool DestroyObject) // creates boll to move in left(L) , right(R) , up(U) , down(D) 
    {   
        pref = new GameObject("boll");
        pref.AddComponent<BoxCollider>().isTrigger = true;

        pref.tag = "up";
        pref.transform.position = positionC;

        if(DestroyObject == true)
        Destroy(pref,time);
        
    }
    public void createDown(Vector3 positionC,bool DestroyObject) // creates boll to move in left(L) , right(R) , up(U) , down(D)  
    {   
        pref = new GameObject("boll");
        pref.AddComponent<BoxCollider>().isTrigger = true;

        pref.tag = "down";
        pref.transform.position = positionC;
        
        if(DestroyObject == true)
        Destroy(pref,time);
        
    }
}
