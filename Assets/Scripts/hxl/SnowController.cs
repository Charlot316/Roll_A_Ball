using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hxlPlayerController.Wind==1)
        {
            transform.position = new Vector3(-50, 0, 0);
            transform.rotation= Quaternion.Euler(-90, 90, 0);
        }
        else if (hxlPlayerController.Wind == 2)
        {
            transform.position = new Vector3(0, 0, 40);
            transform.rotation = Quaternion.Euler(-90, 180, 0);
        }
        else if (hxlPlayerController.Wind == 3)
        {
            transform.position = new Vector3(50, 0, 0);
            transform.rotation = Quaternion.Euler(-90, -90, 0) ;
        }
        else if (hxlPlayerController.Wind == 4)
        {
            transform.position = new Vector3(0, 0, -40);
            transform.rotation = Quaternion.Euler(-90, 0, 0);
        }
    }
}
