using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    int i;
    public List<GameObject> rooms;
    // Start is called before the first frame update
    void Start()
    {
        for (i = 0; i < 16; i++)
        {
            GameObject room = rooms[i];
            GameObject up = room.transform.GetChild(0).gameObject;
            GameObject down = room.transform.GetChild(1).gameObject;
            GameObject right = room.transform.GetChild(2).gameObject;
            GameObject left = room.transform.GetChild(3).gameObject;

            // First do up: if i is less than 4, go to bottom
            if (i < 4)
            {
                up.SendMessage("SetTarget", rooms[i+12]);
            }
            else
            {
                up.SendMessage("SetTarget", rooms[i - 4]);
            }

            // Then do down: if i is greater than 11, go to top
            if (i > 11)
            {
                down.SendMessage("SetTarget", rooms[i - 12]);
            }
            else
            {
                down.SendMessage("SetTarget", rooms[i + 4]);
            }

            // Next right: if i mod 4 is equal to 0, go to left
            if ((int)(i+1) % 4 == 0)
            {
                right.SendMessage("SetTarget", rooms[i - 3]);
            }
            else
            {
                right.SendMessage("SetTarget", rooms[i + 1]);
            }

            // Finally do left: i it mod 4 is equal to 1, go to right
            if ((int)(i + 1) % 4 == 1)
            {
                left.SendMessage("SetTarget", rooms[i + 3]);
            }
            else
            {
                left.SendMessage("SetTarget", rooms[i - 1]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
