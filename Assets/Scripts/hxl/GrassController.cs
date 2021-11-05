using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hxlPlayerController.Wind == 1)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (hxlPlayerController.Wind == 2)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (hxlPlayerController.Wind == 3)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if (hxlPlayerController.Wind == 4)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
