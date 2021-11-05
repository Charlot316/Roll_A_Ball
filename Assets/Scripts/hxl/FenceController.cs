using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0.88f, -12);
    }

    // Update is called once per frame
    void Update()
    {
        if (hxlPlayerController.Wind == 4)
        {
            if (transform.position.y >= -3)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            }
        }
        else
        {
            transform.position = new Vector3(0, 0.88f, -12);
        }
    }
}
