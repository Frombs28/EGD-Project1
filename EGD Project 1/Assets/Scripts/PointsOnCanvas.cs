using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsOnCanvas : MonoBehaviour
{
    public GameObject chkOneP1;
    public GameObject chkTwoP1;
    public GameObject chkThreeP1;

    public GameObject chkOneP2;
    public GameObject chkTwoP2;
    public GameObject chkThreeP2;

    public Sprite empty;
    public Sprite full;

    public Image endScene;
    public Text endText;

    public Text moveAmount;

    //public Material Keymat;


    public string[] playerOneCheck;
    public bool[] playerOneVisit;
    public string[] playerTwoCheck;
    public bool[] playerTwoVisit;

    //public int p1;
    //public int p2;

    // Start is called before the first frame update
    void Start()
    {
        endScene.canvasRenderer.SetAlpha(0.0f);
        playerOneCheck = new string[3];
        playerOneVisit = new bool[3];
        playerTwoCheck = new string[3];
        playerTwoVisit = new bool[3];
        for (int i = 0; i < 3; i++)
        {
            playerOneVisit[i] = false;
            playerTwoVisit[i] = false;
            
        }
        playerOneCheck[0] = "11";
        playerOneCheck[1] = "4";
        playerOneCheck[2] = "9";
        playerTwoCheck[0] = "6";
        playerTwoCheck[1] = "15";
        playerTwoCheck[2] = "5";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdatePlayerOne(int num)
    {
        if (num == 1)
        {
            Debug.Log("Update");
            chkOneP1.SetActive(true);
        }
        if (num == 2)
        {
            chkTwoP1.SetActive(true);
        }
        if (num == 3)
        {
            //Debug.Log("update canvas");
            chkThreeP1.SetActive(true);
        }
    }
    public void UpdatePlayerTwo(int num)
    {
        if (num == 1)
        {
            chkOneP2.SetActive(true);
        }
        if (num == 2)
        {
            chkTwoP2.SetActive(true);
        }
        if (num == 3)
        {
            chkThreeP2.SetActive(true);
        }
    }

    public void MoveCount(int num)
    {
        moveAmount.text = "" + num;
    }

    public void GameOver(GameObject winner)
    {
        endScene.canvasRenderer.SetAlpha(1.0f);
        if (winner == gameObject)
        {
            endText.text = "It's a tie: you both win!";
        }
        else
        {
            string winName = winner.name;
            endText.text = "Congratulations " + winName + "!";
        }
    }
}
