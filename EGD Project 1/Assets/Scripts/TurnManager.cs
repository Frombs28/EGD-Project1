using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    int currentPlayer = 1;
    public GameObject player1 = null;
    public GameObject player2 = null;
    int numTaken = 0;
    public int maxTurns = 5; 
    CameraMovement cameraMovement;
    // Start is called before the first frame update
    void Start()
    {
        cameraMovement = FindObjectOfType<CameraMovement>();
        cameraMovement.SetTarget(player1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchTurns(){
        //TO DO: fade screen
        if(currentPlayer==1){
            currentPlayer = 2;
            cameraMovement.SetTarget(player2);
        }
        else{
            currentPlayer = 1;
            cameraMovement.SetTarget(player1);
        }
        numTaken = 0;
    }
    public void TakeTurn(){
        numTaken++;
        if(numTaken==maxTurns){
            SwitchTurns();
        }
    }
    public void SkipTurn(){
        //TO DO: reveal the info here
        SwitchTurns();
    }
}
