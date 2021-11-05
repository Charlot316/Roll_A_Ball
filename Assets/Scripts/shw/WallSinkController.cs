using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSinkController : MonoBehaviour
{
    public shwPlayerController Player;
    public NavTest Enemy;

    public float SinkTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Enemy.WallSinkBottom == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, -0.75f, transform.position.z), 2 / SinkTime * Time.deltaTime );
        }
        if (transform.position.y +0.75 < 0.55)
        {
            Enemy.agent.enabled = true;
        }
        if(transform.position.y == -0.75)
        {
            gameObject.SetActive(false);
        }
    }
}
