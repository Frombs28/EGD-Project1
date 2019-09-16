using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    int currentPlayer = 1;
    public GameObject player1 = null;
    public GameObject player2 = null;
    public Button endButton = null;
    public Button hintButton = null;
    int numTaken = 0;
    public int maxTurns = 5; 
    CameraMovement cameraMovement;
    // Start is called before the first frame update
    void Start()
    {
        cameraMovement = FindObjectOfType<CameraMovement>();
        cameraMovement.SetTarget(player1);
        endButton.onClick.AddListener(EndTurn);
        hintButton.onClick.AddListener(SkipTurn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchTurns(){
        //TO DO: fade screen
        Debug.Log("switching!!!");
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
            //remove this if player should confirm that their turn is over or w/e
            SwitchTurns();
        }
    }
    public void SkipTurn(){
        //TO DO: reveal the info here
        EndTurn();
    }
    public void EndTurn(){
        SwitchTurns();
    }
}
