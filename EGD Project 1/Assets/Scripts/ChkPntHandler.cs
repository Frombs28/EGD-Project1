using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChkPntHandler : MonoBehaviour
{
    public string [] playerOneCheck;
    public bool[] playerOneVisit;
    public string[] playerTwoCheck;
    public bool[] playerTwoVisit;

    public Canvas mainCanvas;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            playerOneCheck[i] = "0";
            playerOneVisit[i] = false;
            playerTwoCheck[i] = "0";
            playerTwoVisit[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == playerOneCheck[0])
        {
            playerOneVisit[0] = true;
            mainCanvas.GetComponent<PointsOnCanvas>().UpdatePlayerOne(1);
        }
        if (gameObject.tag == playerOneCheck[1])
        {
            if((collision.gameObject.tag == "playerOne" && playerOneVisit[0] == true) || collision.gameObject.tag == "playerTwo")
            {
                playerOneVisit[1] = true;
                mainCanvas.GetComponent<PointsOnCanvas>().UpdatePlayerOne(2);
            }
        }
        if (gameObject.tag == playerOneCheck[2])
        {
            if ((collision.gameObject.tag == "playerOne" && playerOneVisit[0] == true && playerOneVisit[1]) || collision.gameObject.tag == "playerTwo")
            {
                playerOneVisit[2] = true;
                mainCanvas.GetComponent<PointsOnCanvas>().UpdatePlayerOne(3);
            }
        }
        if (gameObject.tag == playerTwoCheck[0])
        {
            playerTwoVisit[0] = true;
            mainCanvas.GetComponent<PointsOnCanvas>().UpdatePlayerTwo(1);
        }
        if (gameObject.tag == playerTwoCheck[1])
        {
            if ((collision.gameObject.tag == "playerTwo" && playerTwoVisit[0] == true) || collision.gameObject.tag == "playerOne")
            {
                playerTwoVisit[1] = true;
                mainCanvas.GetComponent<PointsOnCanvas>().UpdatePlayerTwo(2);
            }
        }
        if (gameObject.tag == playerTwoCheck[2])
        {
            if ((collision.gameObject.tag == "playerTwo" && playerTwoVisit[0] == true && playerTwoVisit[1]) || collision.gameObject.tag == "playerOne")
            {
                playerTwoVisit[2] = true;
                mainCanvas.GetComponent<PointsOnCanvas>().UpdatePlayerTwo(3);
            }
        }

    }
}
