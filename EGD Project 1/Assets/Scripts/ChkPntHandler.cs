using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChkPntHandler : MonoBehaviour
{
    public Canvas mainCanvas;
    public PointsOnCanvas c;

    // Start is called before the first frame update
    void Start()
    {
        mainCanvas = FindObjectOfType<Canvas>();
        c = mainCanvas.GetComponent<PointsOnCanvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collision)
    {
        //Debug.Log(gameObject.tag);
        if (gameObject.tag == c.playerOneCheck[0] && (collision.gameObject.tag == "playerOne" || collision.gameObject.tag == "playerTwo")) 
        {
            c.playerOneVisit[0] = true;
            mainCanvas.GetComponent<PointsOnCanvas>().UpdatePlayerOne(1);
        }
        if (gameObject.tag == c.playerOneCheck[1])
        {
            if((collision.gameObject.tag == "playerOne" && c.playerOneVisit[0] == true) || collision.gameObject.tag == "playerTwo")
            {
                c.playerOneVisit[1] = true;
                Debug.Log(c.playerOneVisit[1]);
                mainCanvas.GetComponent<PointsOnCanvas>().UpdatePlayerOne(2);
            }
        }
        if (gameObject.tag == c.playerOneCheck[2])
        {
            Debug.Log(c.playerOneCheck[2]);
            //Debug.Log("3rd check");
            if ((collision.gameObject.tag == "playerOne" && c.playerOneVisit[0] == true && c.playerOneVisit[1] == true) || collision.gameObject.tag == "playerTwo")
            {
                Debug.Log("3rd check");
                c.playerOneVisit[2] = true;
                mainCanvas.GetComponent<PointsOnCanvas>().UpdatePlayerOne(3);
            }
        }
        if (gameObject.tag == c.playerTwoCheck[0] && (collision.gameObject.tag == "playerOne" || collision.gameObject.tag == "playerTwo"))
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
