using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cyPlayerController : MonoBehaviour
{
    public GameObject button;
    public GameObject exit;
    float speed = 10;
    public Text countText;
    public Text introduction;
    public Image StartIMG;
    float h, v, jump;
    private int count;
    private Rigidbody rb;
    float enduringscale = 0.05f;
    int endurance;
    bool draw = false;
    bool gyinfo;
    bool grounded;
    public bool iswin;
    public Image winimage;
    Gyroscope go;
    float x1, y1, z1;
    Vector3 z0, x2, y2, z2, n, n1, n2;
    float horizontal, vertical;
    public Image goalcolor;
    public Image ballcolor;

    public GameObject ground;
    void Start()
    {
        exit.SetActive(false);
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        grounded = true;
        gyinfo = SystemInfo.supportsGyroscope;
        go = Input.gyro;
        go.enabled = true;
        winimage.enabled = false;
        GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        ballcolor.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        button.SetActive(false);
        Invoke("EndOfStart", 2);
    }
    void EndOfStart()
    {
        introduction.enabled = false;
        StartIMG.enabled = false;
        button.SetActive(true);
    }
    void enableimg()
    {
        winimage.enabled = true;
    }
    void FixedUpdate()   //进行物理计算之前被调用，物理代码在这里执行
    {
        if (goalcolor.color == GetComponent<Renderer>().material.color || iswin == true)
        {
            ground.SetActive(false);
            exit.SetActive(true);
            Invoke("enableimg", 1);
            GameObject.Find("Main Camera").GetComponent<CameraController>().enabled = false;
            Invoke("nextscene", 3);
        }
        else if (transform.position.y <= -10)
        {
            transform.position = new Vector3(0, 1, 0);
        }
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
            Vector3 movement = new Vector3(h * speed, rb.velocity.y + jump, v * speed);
            rb.velocity = movement;

            draw = false;

        }

        else
        {
            draw = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            if (other.gameObject.GetComponent<Renderer>().material.color == Color.red)
            {
                Color color = GetComponent<Renderer>().material.color;
                if (color.g != 0.0f)
                {
                    color.g -= 0.2f;
                }
                if (color.b != 0.0f)
                {
                    color.b -= 0.2f;
                }
                GetComponent<Renderer>().material.color = color;
            }
            else if (other.gameObject.GetComponent<Renderer>().material.color == Color.white)
            {
                Color color = GetComponent<Renderer>().material.color;
                if (color.g != 1.0f)
                {
                    color.g += 0.2f;
                }
                if (color.r != 1.0f)
                {
                    color.r += 0.2f;
                }
                if (color.b != 1.0f)
                {
                    color.b += 0.2f;
                }
                GetComponent<Renderer>().material.color = color;
            }
            else if (other.gameObject.GetComponent<Renderer>().material.color == Color.green)
            {
                Color color = GetComponent<Renderer>().material.color;
                if (color.r != 0.0f)
                {
                    color.r -= 0.2f;
                }
                if (color.b != 0.0f)
                {
                    color.b -= 0.2f;
                }
                GetComponent<Renderer>().material.color = color;
            }
            else if (other.gameObject.GetComponent<Renderer>().material.color == Color.blue)
            {
                Color color = GetComponent<Renderer>().material.color;
                if (color.g != 0.0f)
                {
                    color.g -= 0.2f;
                }
                if (color.r != 0.0f)
                {
                    color.r -= 0.2f;
                }
                GetComponent<Renderer>().material.color = color;
            }
            else if (other.gameObject.GetComponent<Renderer>().material.color == Color.black)
            {
                Color color = GetComponent<Renderer>().material.color;
                if (color.g != 0.0f)
                {
                    color.g -= 0.2f;
                }
                if (color.r != 0.0f)
                {
                    color.r -= 0.2f;
                }
                if (color.b != 0.0f)
                {
                    color.b -= 0.2f;
                    GetComponent<Renderer>().material.color = color;
                }
            }
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    void SetCountText()
    {
        countText.text = "Count:" + count.ToString();
        ballcolor.color = GetComponent<Renderer>().material.color;

    }
    void nextscene()
    {
        SceneManager.LoadScene("Transition");
    }
    void OnGUI()
    {
        if (draw)
        {
            GUI.Label(new Rect(100, 100, 100, 30), "启动失败");
        }
    }
}

