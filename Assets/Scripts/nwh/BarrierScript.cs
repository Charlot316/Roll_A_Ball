using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody barrier;
    public nwhPlayerController player;
    public float speed;
    private float nowY, nowZ;
    Vector3 nowPosition;
    void Start()
    {
        barrier = GetComponent<Rigidbody>();
        nowPosition = this.transform.position;
        //barrier.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(0.0f, 0.0f, -5.0f);
        if(player.transform.position.z >= 30.0f){
            barrier.velocity = movement;
        }     
        else{
            this.transform.position = nowPosition;
        }
        nowY = barrier.transform.position.y;
        nowZ = barrier.transform.position.z;       
        if(nowZ <= 30.0f){          
            if(player.transform.position.z<= 66.0f){
                barrier.transform.position =new Vector3(barrier.transform.position.x, 0.5f, barrier.transform.position.z + 38.0f);
            }
            else{
                Destroy(this.gameObject);
            }
        }    
              
    }
}
