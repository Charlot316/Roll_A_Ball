using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSelectingExit : MonoBehaviour
{
    public shwPlayerController Player;
    public ExitRotateAround NorthWest1, NorthWest2, NorthEast1, NorthEast2, SouthWest1, SouthWest2, SouthEast1, SouthEast2;
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        id = Random.Range(0, 4);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Player.count == 125)
        {
            if (id == 0)
            {
                NorthWest1.ExitGenerating = true;
                NorthWest2.ExitGenerating = true;
            }
            else if(id == 1)
            {
                NorthEast1.ExitGenerating = true;
                NorthEast2.ExitGenerating = true;
            }
            else if(id == 2)
            {
                SouthWest1.ExitGenerating = true;
                SouthWest2.ExitGenerating = true;
            }
            else if(id == 3)
            {
                SouthEast1.ExitGenerating = true;
                SouthEast2.ExitGenerating = true;
            }
        }
    }
}
