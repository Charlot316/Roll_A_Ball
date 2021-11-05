using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueButtoncontroller : MonoBehaviour
{
    public static int lowdown;
    // Start is called before the first frame update
    void Start()
    {
        lowdown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -1.4f)
        {
            lowdown = 1;
        }
    }
}
