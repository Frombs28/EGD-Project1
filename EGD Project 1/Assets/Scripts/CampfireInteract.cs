using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CampfireInteract : MonoBehaviour
{
    TurnManager turns;
    Move move;
    public Text text;
    bool up = true;

    //possibily should be moved to Move.cs, keeping it seperate for now.
    // Start is called before the first frame update
    void Start()
    {
        turns = FindObjectOfType<TurnManager>();
        move = GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// OnTriggerStay is called once per frame for every Collider other
    /// that is touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerStay(Collider other)
    {
        if(move.isPlayerControllable){
            if(other.gameObject.tag=="Fire"){
                //from Move.cs
                text.text = "Press E";
                if (Input.GetKeyDown(KeyCode.E)&&up)
                {
                    up = false;
                    text.text = "";
                    if(turns.numTaken == 0){
                        turns.SkipTurn(other.gameObject.transform.parent.name);
                    }
                    else{
                        turns.EndTurn();
                    }             
                }
                else{
                    up = true;
                }
            }
        }
    }
    
}
