using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hxlPlayerController : MonoBehaviour
{
    public GameObject button;
    public static int Wind;
    float speed = 10;
    public Text countText;
    public Text tiptext;
    bool haskey;
    public Image winimage;
    float h, v, jump;
    public int count;
    private Rigidbody rb;
    float enduringscale = 0.05f;
    int endurance;
    bool draw = false;
    bool gyinfo;
    bool grounded;
    public Text introduction;
    public Camera camera;
    public Image startimg;
    Gyroscope go;
    float x1, y1, z1;
    Vector3 z0, x2, y2, z2, n, n1, n2;
    float horizontal, vertical;
    void Start()
    {
        button.SetActive(false);
        transform.position = new Vector3(0, 0.5f, 0);
        rb = GetComponent<Rigidbody>();
        count = 0;
        grounded = true;
        gyinfo = SystemInfo.supportsGyroscope;
        go = Input.gyro;
        go.enabled = true;
        Wind = 1;
        haskey = false;
        tiptext.enabled = false;
        Invoke("EndOfStart", 2);
        winimage.enabled = false;
    }
    void EndOfStart()
    {
        introduction.enabled = false;
        startimg.enabled = false;
        button.SetActive(true);
    }
    void nextscene()
    {
        SceneManager.LoadScene("Transition");
    }
    void FixedUpdate()   //进行物理计算之前被调用，物理代码在这里执行
    {
        if ((transform.position.y < -3) && (transform.position - new Vector3((float)(77), transform.position.y, (float)-9)).magnitude < 2)
        {
            winimage.enabled = true;
            camera.GetComponent<hxlCameraController>().enabled = false;
            Invoke("nextscene", 2);
        }
        else if (transform.position.y <= -10)
        {
            transform.position = new Vector3(0, 2, 5);
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
        if (other.gameObject.CompareTag("Button"))
        {
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y - 0.2f, other.gameObject.transform.position.z);
        }
        if (other.gameObject.CompareTag("Key1"))
        {
            other.gameObject.SetActive(false);
            haskey = true;
        }
        if (other.gameObject.CompareTag("door") && haskey == true && count >= 6)
        {
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("door"))
        {
            tiptext.enabled = true;
            Invoke("closetip", 2);
        }
    }
    void closetip()
    {
        tiptext.enabled = false;
    }
    void SetCountText()
    {
        countText.text = "Count:" + count.ToString() + "/6";

    }
    void OnGUI()
    {
        if (draw)
        {
            GUI.Label(new Rect(100, 100, 100, 30), "启动失败");
        }
    }
}

