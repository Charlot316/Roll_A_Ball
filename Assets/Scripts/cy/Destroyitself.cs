using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyitself : MonoBehaviour
{
    public GameObject pointtext;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(pointtext, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
