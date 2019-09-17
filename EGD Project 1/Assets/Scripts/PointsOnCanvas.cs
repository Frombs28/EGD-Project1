﻿using System.Collections;
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
        playerOneCheck = new string[3];
        playerOneVisit = new bool[3];
        playerTwoCheck = new string[3];
        playerTwoVisit = new bool[3];
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
}
