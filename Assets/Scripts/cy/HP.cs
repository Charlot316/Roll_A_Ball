using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public Image goal;
    public GameObject ball;
    private float waitTime = 2.0f;
    private float timer = 0.0f;
    private float visualTime = 0.0f;
    private float scrollBar = 1.0f;
    public Image ballcolor;
    // Start is called before the first frame update
    void Start()
    {
        goal = GetComponent<Image>();
        System.Random r = new System.Random();
        int num = r.Next(6);
        float R = num * 0.2f;
        r = new System.Random();
        num = r.Next(6);
        float g = num * 0.2f;
        num = r.Next(6);
        float b = num * 0.2f;
        goal.color = new Color(R, g, b, 1.0f);
        goal.fillAmount = 1f;
        ball.GetComponent<Renderer>().material.color = Color.white;
        ballcolor.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > waitTime){
            visualTime = timer;
            timer = timer - waitTime;
            Time.timeScale = scrollBar;
            goal.fillAmount = goal.fillAmount - 0.01f;
            if (goal.fillAmount <= 0f){
                Start();
            }
        }
    }
}
