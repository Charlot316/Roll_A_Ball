using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hxlCameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    bool hasdown = false,fencedown=false,bridgedown=false;
    int rockt = 30,fencet=30,bridget=30;
    // Start is called before the first frame update
    void Start()
    {
        transform.position= new Vector3(0, 10.5f, -10f);
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(BlueButtoncontroller.lowdown==1&&hasdown==false)
        {
            transform.position= new Vector3(-18.6f, 14.4f, -11.6f);
            rockt--;
            if (rockt <= 0) hasdown = true;
        }
        else if(hxlPlayerController.Wind == 4 &&fencedown==false)
        {
            transform.position = new Vector3(-0.2f, 10.5f, -21.58f);
            fencet--;
            if (fencet <= 0) fencedown = true;
        }
        else transform.position = player.transform.position + offset;
    }
}
