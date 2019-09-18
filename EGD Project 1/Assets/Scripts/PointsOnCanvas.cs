using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsOnCanvas : MonoBehaviour
{
    public Image chkOneP1;
    public Image chkTwoP1;
    public Image chkThreeP1;

    public Image chkOneP2;
    public Image chkTwoP2;
    public Image chkThreeP2;

    public Sprite empty;
    public Sprite full;

    public Image endScene;
    public Text endText;

    public Text moveAmount;


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
        playerOneCheck[0] = "2";
        playerOneCheck[1] = "3";
        playerOneCheck[2] = "4";
        playerTwoCheck[0] = "15";
        playerOneCheck[1] = "3";
        playerOneCheck[2] = "6";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdatePlayerOne(int num)
    {
        if (num == 1)
        {
            chkOneP1.sprite = full;
        }
        if (num == 2)
        {
            chkTwoP1.sprite = full;
        }
        if (num == 3)
        {
            //Debug.Log("update canvas");
            chkThreeP1.sprite = full;
        }
    }
    public void UpdatePlayerTwo(int num)
    {
        if (num == 1)
        {
            chkOneP2.sprite = full;
        }
        if (num == 2)
        {
            chkTwoP2.sprite = full;
        }
        if (num == 3)
        {
            chkThreeP2.sprite = full;
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
