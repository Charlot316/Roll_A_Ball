using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearRoadScript : MonoBehaviour
{
    // Start is called before the first frame update
    public nwhPlayerController player;
    
    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.z >= this.transform.position.z + 2){
            this.gameObject.SetActive(false);
        }
    }
    
}
