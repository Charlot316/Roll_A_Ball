using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSelectingSink : MonoBehaviour
{
    public shwPlayerController Player;
    public NavTest North, South, West, East;
    private List<NavTest> Enemys = new List<NavTest>();
    private int id;
    private NavTest[] Final = new NavTest[4];

    public Text Remind;
    // Start is called before the first frame update
    void Start()
    {
        Remind.enabled = false;
        Enemys.Add(North);
        Enemys.Add(South);
        Enemys.Add(West);
        Enemys.Add(East);
        for (int i = 0; i < 4; i++)
        {
            id = Random.Range(0, Enemys.Count);
            Final[i] = Enemys[id];
            Enemys.Remove(Enemys[id]);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Player.count == 25)
        {
            Final[0].WallSinkBottom = true;
            Remind.text = "干得不错！1号小球开始追捕";
            RemindOn();
        }
        else if (Player.count == 50)
        {
            Final[1].WallSinkBottom = true;
            Remind.text = "熟能生巧！2号小球开始追捕";
            RemindOn();
        }
        else if (Player.count == 75)
        {
            Final[2].WallSinkBottom = true;
            Remind.text = "乘胜追击！3号小球开始追捕";
            RemindOn();
        }
        else if (Player.count == 100)
        {
            Final[3].WallSinkBottom = true;
            Remind.text = "决胜时刻！4号小球开始追捕";
            RemindOn();
        }
        else if (Player.count == 125)
        {
            Remind.text = "出口已经开启！但千万别松懈了";
            RemindOn();
        }
    }

    private void RemindOn()
    {
        Remind.enabled = true;
        Invoke("RemindOff", 2);
    }

    private void RemindOff()
    {
        Remind.enabled = false;
    }
}
