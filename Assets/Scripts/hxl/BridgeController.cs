using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(hxlPlayerController.Wind == 3)
        {
           transform.position = new Vector3(62, 2, 0);
           transform.rotation = Quaternion.Euler(-90, 90, -10);
        }
        else
        {
          transform.position = new Vector3(71, 3.5f, 0);
          transform.rotation = Quaternion.Euler(0, 90, -10);
        }
    }
}
