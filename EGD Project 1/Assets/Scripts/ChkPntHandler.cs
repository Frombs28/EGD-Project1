using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChkPntHandler : MonoBehaviour
{
    public Canvas mainCanvas;
    public PointsOnCanvas c;
    TurnManager manager;
    public GameObject player1;
    public GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        mainCanvas = FindObjectOfType<Canvas>();
        manager = FindObjectOfType<TurnManager>();
        c = mainCanvas.GetComponent<PointsOnCanvas>();
        player1 = GameObject.FindGameObjectWithTag("playerOne");
        player2 = GameObject.FindGameObjectWithTag("playerTwo");

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
            CheckPlayerOne(collision.gameObject);
            mainCanvas.GetComponent<PointsOnCanvas>().UpdatePlayerOne(1);
        }
        if (gameObject.tag == c.playerOneCheck[1])
        {
            if((collision.gameObject.tag == "playerOne" && c.playerOneVisit[0] == true) || collision.gameObject.tag == "playerTwo")
            {
                c.playerOneVisit[1] = true;
                CheckPlayerOne(collision.gameObject);
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
                CheckPlayerOne(collision.gameObject);
                mainCanvas.GetComponent<PointsOnCanvas>().UpdatePlayerOne(3);
            }
        }
        if (gameObject.tag == c.playerTwoCheck[0] && (collision.gameObject.tag == "playerOne" || collision.gameObject.tag == "playerTwo"))
        {
            c.playerTwoVisit[0] = true;
            CheckPlayerTwo(collision.gameObject);
            mainCanvas.GetComponent<PointsOnCanvas>().UpdatePlayerTwo(1);
        }
        if (gameObject.tag == c.playerTwoCheck[1])
        {
            if ((collision.gameObject.tag == "playerTwo" && c.playerTwoVisit[0] == true) || collision.gameObject.tag == "playerOne")
            {
                c.playerTwoVisit[1] = true;
                mainCanvas.GetComponent<PointsOnCanvas>().UpdatePlayerTwo(2);
                CheckPlayerTwo(collision.gameObject);
            }
        }
        if (gameObject.tag == c.playerTwoCheck[2])
        {
            if ((collision.gameObject.tag == "playerTwo" && c.playerTwoVisit[0] == true && c.playerTwoVisit[1]) || collision.gameObject.tag == "playerOne")
            {
                c.playerTwoVisit[2] = true;
                mainCanvas.GetComponent<PointsOnCanvas>().UpdatePlayerTwo(3);
                CheckPlayerTwo(collision.gameObject);
            }
        }

    }

    void CheckPlayerOne(GameObject other)
    {
        if (c.playerOneVisit[0] && c.playerOneVisit[1] && c.playerOneVisit[2])
        {
            if(other.tag == "playerOne")
            {
                manager.LastTurn();
            }
            else
            {
                c.GameOver(player2);
            }
        }
    }

    void CheckPlayerTwo(GameObject other)
    {
        if (c.playerTwoVisit[0] && c.playerTwoVisit[1] && c.playerTwoVisit[2])
        {
            if (c.playerOneVisit[0] && c.playerOneVisit[1] && c.playerOneVisit[2])
            {
                c.GameOver(c.gameObject);
            }
            else
            {
                c.GameOver(player2);
            }
        }
    }
}
