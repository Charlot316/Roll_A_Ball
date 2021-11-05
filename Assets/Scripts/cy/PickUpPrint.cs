using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickUpPrint : MonoBehaviour
{
    public GameObject pick_up;
    private int flag;
    GameObject cloneObj;
    // Start is called before the first frame update
    void Start()
    {
        flag = 0;
        cloneObj = Instantiate(pick_up, new Vector3(UnityEngine.Random.Range(-14f,14f), 1, UnityEngine.Random.Range(-14f, 14f)), Quaternion.identity) as GameObject;
        Destroy(cloneObj, 20);
        System.Random r = new System.Random();
        int num = r.Next(37);
        if (num <= 9){
            cloneObj.GetComponent<Renderer>().material.color = Color.blue;
        } else if (num <= 15){
            cloneObj.GetComponent<Renderer>().material.color = Color.white;
        } else if (num <= 20){
            cloneObj.GetComponent<Renderer>().material.color = Color.green;
        } else if (num <= 26){
            cloneObj.GetComponent<Renderer>().material.color = Color.red;
        } else {
            cloneObj.GetComponent<Renderer>().material.color = Color.black;
        }
    }

    // Update is called once per frame
    void Update()
    {
        flag++;
        if (flag % 160 == 0){
            cloneObj = Instantiate(pick_up, new Vector3(UnityEngine.Random.Range(-14f,14f), 1, UnityEngine.Random.Range(-14f, 14f)), Quaternion.identity) as GameObject;
            Destroy(cloneObj, 20);
            System.Random r = new System.Random();
            int num = r.Next(37);
            if (num <= 9){
                cloneObj.GetComponent<Renderer>().material.color = Color.blue;
            } else if (num <= 15){
                cloneObj.GetComponent<Renderer>().material.color = Color.white;
            } else if(num <= 20){
                cloneObj.GetComponent<Renderer>().material.color = Color.green;
            } else if (num <= 26){
                cloneObj.GetComponent<Renderer>().material.color = Color.red;
            } else {
                cloneObj.GetComponent<Renderer>().material.color = Color.black;
            }
        }
    }
}
