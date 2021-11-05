using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
public class nwhPlayerController : MonoBehaviour
{
    public AudioSource audioSource;
    float speed = 10;
    public Text showText, showText1, destinationText, goldkeyText, silverkeyText;
    float h, v, jump;
    public int count, DisappearRoadCount;
    private Rigidbody rb;
    public GameObject PickUp;
    public GameObject[] DisappearRoad;
    public GameObject[] SilverGround;
    float enduringscale = 0.06f;
    int endurance;
    bool draw = false;
    bool gyinfo;
    bool grounded;
    bool isWin;
    Gyroscope go;
    float x1, y1, z1;
    Vector3 z0, x2, y2, z2, n, n1, n2;
    float horizontal, vertical;
    bool[] p = new bool[17];
    string pick;
    bool goldkey, silverkey, golddoor, silverdoor;
    float nowY, nowZ;
    Vector3 spawnpoint;
    public static String ThisScene;
    public GameObject CongratulationsUI;
    void Start()
    {
        currentplay.scene = 1;
        rb = GetComponent<Rigidbody>();
        //audioSource = this.GetComponent<AudioSource>();
        PickUp.SetActive(false);
        showText.text = "";
        showText1.text = "";
        destinationText.text = "";
        goldkeyText.text = "";
        silverkeyText.text = "";
        count = 0;
        grounded = false;
        gyinfo = SystemInfo.supportsGyroscope;
        go = Input.gyro;
        go.enabled = true;
        p[1] = true;
        for (int i = 1; i <= 16; i++)
        {
            p[i] = true;
        }
        golddoor = false;
        silverdoor = false;
        goldkey = false;
        silverkey = false;
        spawnpoint = new Vector3(0.0f, 1.0f, 0.0f);
        DisappearRoadCount = 0;
        ThisScene = SceneManager.GetActiveScene().name;
        isWin = false;
    }
    void FixedUpdate()   //进行物理计算之前被调用，物理代码在这里执行
    {
        if (gyinfo)
        {
            Vector3 a = go.attitude.eulerAngles;
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                // Handle finger movements based on touch phase.
                if (touch.phase != TouchPhase.Ended && grounded)
                {
                    if (endurance < 50) endurance++;
                }
                else if (touch.phase == TouchPhase.Ended && grounded)
                {
                    jump = 3 + endurance * enduringscale;
                    endurance = 0;
                    grounded = false;
                }
                else
                {
                    jump = 0;
                    endurance = 0;
                }
            }
            else //以防屏幕没有返回ended信号。这里可以确保没有屏幕信号的时候仍然能让小球跳起。
            {
                jump = 0;
                if (endurance != 0)
                {
                    jump = 3 + endurance * enduringscale;
                    endurance = 0;
                    grounded = false;
                }
            }
            x1 = a.x * Mathf.Deg2Rad;
            y1 = a.y * Mathf.Deg2Rad;
            z1 = a.z * Mathf.Deg2Rad;

            z0 = new Vector3(0, 0, 1);
            x2 = new Vector3(0, -Mathf.Cos(x1), Mathf.Sin(x1));
            y2 = new Vector3(Mathf.Cos(y1), 0, -Mathf.Sin(y1));
            z2 = new Vector3(Mathf.Sin(z1), Mathf.Cos(z1), 0);
            n = Vector3.Cross(x2, y2);
            n1 = -Vector3.Cross(z0, z2);

            horizontal = 90 - Vector3.Angle(n, n1);
            vertical = 90 - Vector3.Angle(n, z2);

            h = Mathf.Sin(horizontal * Mathf.Deg2Rad);
            v = -Mathf.Sin(vertical * Mathf.Deg2Rad);
            if (v >= 0.7f)
            {
                v = 0.7f;
            }

            Vector3 movement = new Vector3(h * speed, rb.velocity.y + jump, v * speed);
            rb.velocity = movement;
            draw = false;
        }
        else
        {
            draw = true;
        }
        nowY = rb.transform.localPosition.y;
        nowZ = rb.transform.localPosition.z;
        if (nowY <= -20 && !isWin)
        {
            if (silverkey == false)
            {
                for (int i = 0; i < 21; i++)
                {
                    SilverGround[i].SetActive(true);
                }
            }
            rb.transform.position = spawnpoint;
        }
        if (nowZ <= 30.0f)
        {
            for (int i = 0; i < 9; i++)
            {
                DisappearRoad[i].SetActive(true);
            }
            DisappearRoadCount = 0;
        }
        if ((transform.position.y < -2) && (transform.position - new Vector3((float)(0), transform.position.y, (float)71)).magnitude < 2)
        {
            GameObject.Find("Main Camera").GetComponent<CameraController>().enabled = false;
            isWin = true;
            // Time.timeScale = 0;
            CongratulationsUI.SetActive(true);
            Invoke("Change", 2);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            pick = other.gameObject.name;
            int len = pick.Length;
            pick = pick.Substring(1, len - 1);
            int pic = Convert.ToInt32(pick);
            p[pic] = false;
            if (pic != 6 && pic != 7 && pic != 10 && pic != 11)
            {
                showText1.text = "你拾取了错误的方块，正在重新开始";
                Invoke("RemindOff", 1);
            }
        }
        if (other.gameObject.CompareTag("GoldDoor"))
        {
            float step = speed * Time.deltaTime;
            golddoor = true;
            spawnpoint = new Vector3(8.75f, 0.5f, -158.5f);
            this.transform.position = new Vector3(8.75f, 0.5f, -158.5f);
            //this.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(0, 0, 0), step);
        }
        if (other.gameObject.CompareTag("GoldKey"))
        {

            goldkey = true;
            goldkeyText.text = "你获得了一把金钥匙";
            this.transform.position = new Vector3(0.0f, 0.5f, 20.0f);
            Destroy(goldkeyText, 1.0f);
            audioSource.Play();
        }
        if (other.gameObject.CompareTag("SilverDoor"))
        {
            float step = speed * Time.deltaTime;
            silverdoor = true;
            spawnpoint = new Vector3(163.0f, 0.5f, -12.5f);
            this.transform.position = new Vector3(163.0f, 0.5f, -12.5f);
            //this.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(0, 0, 0), step);
        }
        if (other.gameObject.CompareTag("SilverKey"))
        {
            audioSource.Play();
            silverkey = true;
            silverkeyText.text = "你获得了一把银钥匙";
            this.transform.position = new Vector3(0.0f, 0.5f, 20.0f);
            Destroy(silverkeyText, 1.0f);

        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
        if (other.gameObject.CompareTag("MidWall"))
        {
            if (PickUp.activeInHierarchy == false)
            {
                PickUp.SetActive(true);
            }
            if (p[1] == true && p[2] == true && p[3] == true && p[4] == true && p[5] == true && p[6] == false
            && p[7] == false && p[8] == true && p[9] == true && p[10] == false
            && p[11] == false && p[12] == true && p[13] == true && p[14] == true && p[15] == true && p[16] == true)
            {

                Destroy(other.gameObject);
            }
            else
            {
                showText.text = "使拾取物呈现为0即可开门(拾取四个方块)";
            }
        }
        if (other.gameObject.CompareTag("Destination"))
        {
            if (goldkey && silverkey)
            {
                other.gameObject.SetActive(false);
                spawnpoint = new Vector3(0.0f, 0.5f, 30.0f);
            }
            else if (goldkey && silverkey == false)
            {
                destinationText.text = "你还需要一把银钥匙";
            }
            else if (goldkey == false && silverkey)
            {
                destinationText.text = "你还需要一把金钥匙";
            }
            else
            {
                destinationText.text = "你需要一把金钥匙与一把银钥匙";
            }
        }
        if (other.gameObject.CompareTag("SilverGround"))
        {
            other.gameObject.SetActive(false);
        }
        // if(other.gameObject.CompareTag("Final")){
        //     if (nowZ > 68) {
        //         SceneManager.LoadScene("Transition");
        //     }
        // }
        // if(other.gameObject.CompareTag("DisappearRoad1")){
        //     DisappearRoad[DisappearRoadCount] = other.gameObject;
        //     DisappearRoadCount += 1;
        // }
        // if(other.gameObject.CompareTag("DisappearRoad2")){
        //     DisappearRoad[DisappearRoadCount] = other.gameObject;
        //     DisappearRoadCount += 1;
        // }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("MidWall"))
        {
            showText.text = "";
        }
        if (other.gameObject.CompareTag("Destination"))
        {
            destinationText.text = "";
        }
    }
    void OnGUI()
    {
        if (draw)
        {
            GUI.Label(new Rect(100, 100, 100, 30), "启动失败");
        }
    }
    public void RemindOff()
    {
        SceneManager.LoadScene("nwh");
    }
    public void Change()
    {
        // Time.timeScale = 1f;
        SceneManager.LoadScene("Transition");
    }
}

