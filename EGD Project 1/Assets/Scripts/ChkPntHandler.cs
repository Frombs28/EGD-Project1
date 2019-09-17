using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChkPntHandler : MonoBehaviour
{
    //public string [] playerOneCheck;
    //public bool[] playerOneVisit;
    //public string[] playerTwoCheck;
    //public bool[] playerTwoVisit;

    public Canvas mainCanvas;
    public PointsOnCanvas c;

    // Start is called before the first frame update
    void Start()
    {
        /*for (int i = 0; i < 3; i++)
        {
            playerOneCheck[i] = "0";
            playerOneVisit[i] = false;
            playerTwoCheck[i] = "0";
            playerTwoVisit[i] = false;
        }*/
        mainCanvas = FindObjectOfType<Canvas>();
        c = mainCanvas.GetComponent<PointsOnCanvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (gameObject.tag == c.playerOneCheck[0])
        {
            c.playerOneVisit[0] = true;
            mainCanvas.GetComponent<PointsOnCanvas>().UpdatePlayerOne(1);
        }
        if (gameObject.tag == c.playerOneCheck[1])
        {
            if((collision.gameObject.tag == "playerOne" && c.playerOneVisit[0] == true) || collision.gameObject.tag == "playerTwo")
            {
                c.playerOneVisit[1] = true;
                mainCanvas.GetComponent<PointsOnCanvas>().UpdatePlayerOne(2);
            }
        }
        if (gameObject.tag == c.playerOneCheck[2])
        {
            if ((collision.gameObject.tag == "playerOne" && c.playerOneVisit[0] == true && c.playerOneVisit[1]) || collision.gameObject.tag == "playerTwo")
            {
                c.playerOneVisit[2] = true;
                mainCanvas.GetComponent<PointsOnCanvas>().UpdatePlayerOne(3);
            }
        }
        if (gameObject.tag == c.playerTwoCheck[0])
        {
            c.playerTwoVisit[0] = true;
            mainCanvas.GetComponent<PointsOnCanvas>().UpdatePlayerTwo(1);
        }
        if (gameObject.tag == c.playerTwoCheck[1])
        {
            if ((collision.gameObject.tag == "playerTwo" && c.playerTwoVisit[0] == true) || collision.gameObject.tag == "playerOne")
            {
                c.playerTwoVisit[1] = true;
                mainCanvas.GetComponent<PointsOnCanvas>().UpdatePlayerTwo(2);
            }
        }
        if (gameObject.tag == c.playerTwoCheck[2])
        {
            if ((collision.gameObject.tag == "playerTwo" && c.playerTwoVisit[0] == true && c.playerTwoVisit[1]) || collision.gameObject.tag == "playerOne")
            {
                c.playerTwoVisit[2] = true;
                mainCanvas.GetComponent<PointsOnCanvas>().UpdatePlayerTwo(3);
            }
        }

    }
}
