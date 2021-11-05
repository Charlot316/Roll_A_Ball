using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitRotateAround : MonoBehaviour
{
    public Vector3 Center;
    public float RotateSpeed;
    public bool RotateDirection;
    private float RotatedAngle = 0;
    public bool ExitGenerating;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(ExitGenerating == true)
        {
            transform.RotateAround(Center, new Vector3(0, 1, 0), RotateSpeed * ((RotateDirection) ? -1 : 1));
            RotatedAngle += RotateSpeed;
            if(RotatedAngle + RotateSpeed >= 90)
            {
                RotateSpeed = 90 - RotatedAngle;
            }
            if(RotateSpeed == 0)
            {
                ExitGenerating = false;
            }
        }
        
    }
}
