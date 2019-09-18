using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    int currentPlayer = 1;
    public GameObject player1 = null;
    public GameObject player2 = null;
    List<Move> playerMove = new List<Move>();
    Teleporter tele = null;
    public Text hintText;
    public Text turnText;
    public int numTaken = 0;
    public int maxTurns = 5; 
    CameraMovement cameraMovement;
    // Start is called before the first frame update
    void Start()
    {
        tele = FindObjectOfType<Teleporter>();
        cameraMovement = FindObjectOfType<CameraMovement>();
        cameraMovement.SetTarget(player1);
        if(hintText!=null) hintText.text = "";
        playerMove.Add(player1.GetComponent<Move>());
        playerMove.Add(player2.GetComponent<Move>());
        playerMove[1].SetPlayerControllable(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchTurns(){
        //TO DO: fade screen, control switching
        tele.Fade();
        Debug.Log("switching!!!");
        playerMove[currentPlayer-1].SetPlayerControllable(false);
        if(currentPlayer==1){
            currentPlayer = 2;
            StartCoroutine(camSwitch(player2, tele.fadeTime));
        }
        else{
            currentPlayer = 1;
            StartCoroutine(camSwitch(player1, tele.fadeTime));
        }
        numTaken = 0;
        turnText.text = numTaken.ToString();
    }

    ///<summary>
    ///returns false if a turn cannot be taken, true otherwise and increments the number of turns taken
    ///</summary>
    public bool TakeTurn(){
        if(numTaken==maxTurns){
            return false;
        }
        //Debug.Log(numTaken);
        numTaken++;
        turnText.text = numTaken.ToString();
        return true;
    }

    public void SkipTurn(string roomName){
        //TO DO: reveal the info here
        //Double interact 2 end turn??
        //EndTurn();

        //prevents player from moving
        if(hintText!=null) hintText.text = "You are in " + roomName;
        numTaken = maxTurns;
        turnText.text = numTaken.ToString();
        Debug.Log(roomName);
    }

    public void EndTurn(){
        SwitchTurns();
    }

    private IEnumerator camSwitch(GameObject player, float waitTime){
        yield return new WaitForSeconds(waitTime);
        if(hintText!=null) hintText.text = "";
        cameraMovement.SetTarget(player);
        playerMove[currentPlayer-1].SetPlayerControllable(true);
    }
}
