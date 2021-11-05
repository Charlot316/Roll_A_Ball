using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-18, 6, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(BlueButtoncontroller.lowdown==1)
        {
            if(transform.position.y>=0) transform.position = new Vector3(transform.position.x, transform.position.y -0.5f, transform.position.z);
        }
    }
}
