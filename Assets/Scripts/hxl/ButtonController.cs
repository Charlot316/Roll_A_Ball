using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    int touched;
    // Start is called before the first frame update
    void Start()
    {
        touched = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -1.45f && touched == 0)
        {
            hxlPlayerController.Wind = hxlPlayerController.Wind % 4 + 1;
            touched = 1;
        }
        if (transform.position.y >= -0.8f) touched = 0;
        if (transform.position.y <= -0.8f && touched == 1) transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);

    }
}
