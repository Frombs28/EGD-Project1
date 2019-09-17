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
    public Teleporter tele = null;
    public int numTaken = 0;
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
        //TO DO: fade screen, control switching
        tele.Fade();
        Debug.Log("switching!!!");
        if(currentPlayer==1){
            currentPlayer = 2;
            StartCoroutine(camSwitch(player2, tele.fadeTime));
        }
        else{
            currentPlayer = 1;
            StartCoroutine(camSwitch(player1, tele.fadeTime));
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
    private IEnumerator camSwitch(GameObject player, float waitTime){
        yield return new WaitForSeconds(waitTime);
        cameraMovement.SetTarget(player);
    }
}
