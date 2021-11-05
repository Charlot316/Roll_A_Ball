using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    public shwPlayerController Player;
    public Text introduction;
    public Image StartImg;
    public GameObject button;
    public Image CongratulationImage;
    public Text LoseText;
    public int ReloadingTime;
    private int t;
    // Start is called before the first frame update
    void Start()
    {
        CongratulationImage.enabled = false;
        Player.enabled = false;
        StartImg.enabled = true;
        introduction.enabled = true;
        LoseText.enabled = false;
        button.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch Mytouch = Input.GetTouch(0);
            if (Mytouch.phase == TouchPhase.Ended)
            {
                button.SetActive(true);
                Invoke("Begin", 0.04f);
            }
        }
    }

    private void Begin()
    {
        introduction.enabled = false;
        StartImg.enabled = false;
        Player.enabled = true;
    }
}
