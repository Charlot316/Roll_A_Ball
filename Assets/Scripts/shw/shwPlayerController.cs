using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shwPlayerController : MonoBehaviour
{
    private Rigidbody rb;
    float speed = 10;
    public Text countText;
    public Text LoseText;
    public Text WinText;
    public int count;

    public Image CongratulationImage;
    float jump = 0;
    float h, v;
    float enduringscale = 0.04f;
    int endurance;

    bool grounded;

    bool gyinfo;
    Gyroscope go;

    float x1, y1, z1;
    Vector3 z0, x2, y2, z2, n, n1, n2;
    float horizontal, vertical;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        countText.text = "剩余钻石数量:" + (125 - count);
        gyinfo = SystemInfo.supportsGyroscope;
        go = Input.gyro;
        go.enabled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gyinfo)
        {
            Vector3 a = go.attitude.eulerAngles;
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

            if (Input.touchCount > 0)
            {
                Touch Mytouch = Input.GetTouch(0);
                if (Mytouch.phase != TouchPhase.Ended && grounded)
                {
                    if (endurance < 25) endurance++;
                }
                else if (Mytouch.phase == TouchPhase.Ended && grounded)
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
            else
            {
                jump = 0;
                if (endurance != 0)
                {
                    jump = 3 + endurance * enduringscale;
                    endurance = 0;
                    grounded = false;
                }
            }

            Vector3 movement = new Vector3(h * speed, rb.velocity.y + jump, v * speed);
            rb.velocity = movement;
        }

        if (transform.position.y < -2)
        {
            if ((transform.position - new Vector3((float)33.25, transform.position.y, (float)31.75)).magnitude < 2
            || (transform.position - new Vector3((float)33.25, transform.position.y, (float)-31.75)).magnitude < 2
            || (transform.position - new Vector3((float)-33.25, transform.position.y, (float)31.75)).magnitude < 2
            || (transform.position - new Vector3((float)-33.25, transform.position.y, (float)-31.75)).magnitude < 2)
            {
                if (!LoseText.enabled)
                {
                    CongratulationImage.enabled = true;
                    WinText.enabled = true;
                    GameObject.Find("Main Camera").GetComponent<CameraController>().enabled = false;
                    GameObject.Find("Directional Light").GetComponent<CameraController>().enabled = false;
                    Invoke("transition", 2);
                }
            }
            else if (!WinText.enabled)
            {
                LoseText.enabled = true;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            other.gameObject.SetActive(false);
            count++;
            countText.text = "剩余钻石数量:" + (125 - count);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            LoseText.enabled = true;
            Invoke("Restart", 1);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene("shw");
    }
    void transition()
    {
        SceneManager.LoadScene("Transition");
    }
}
