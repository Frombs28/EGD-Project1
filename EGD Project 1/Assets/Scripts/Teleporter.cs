using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleporter : MonoBehaviour
{
    public GameObject target;
    public Image fade;
    float startTime;
    public float fadeTime = 0.5f;
    public float fadeDelay = 0.2f;
    public GameObject player;
    TurnManager turns;
    GameObject manager;
    GameObject player1;
    GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        fade = GameObject.FindGameObjectWithTag("Fade").GetComponent<Image>();
        fade.canvasRenderer.SetAlpha(0.0f);
        startTime = 0f;
        turns = FindObjectOfType<TurnManager>();
        player1 = GameObject.FindGameObjectWithTag("playerOne");
        player2 = GameObject.FindGameObjectWithTag("playerTwo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("playerOne") || (other.gameObject.CompareTag("playerTwo"))) && (turns.TakeTurn()))
        {
            // Trigger fade out
            Fade();
            player = other.gameObject;
            Invoke("MovePlayer", fadeTime);
        }
    }

    IEnumerator FadeOut()
    {
        // Do some kind of effect/sound?

        // First fade out
        fade.CrossFadeAlpha(1.0f, fadeTime, false);
        player1.SendMessage("Stop",fadeTime);
        player2.SendMessage("Stop",fadeTime);
        // Wait for fade out
        startTime = Time.time;
        while (Time.time - startTime < fadeTime + fadeDelay)
        {
            yield return null;
        }
        manager.SendMessage("Off", transform.parent.transform.GetChild(6).gameObject.tag);
        manager.SendMessage("On", target.transform.GetChild(6).gameObject.tag);
        // Fade in
        fade.CrossFadeAlpha(0.0f, fadeTime, false);
        player1.SendMessage("Begin",fadeTime/2);
        player2.SendMessage("Begin",fadeTime/2);
    }

    private void MovePlayer()
    {
        // Move player
        Vector3 newPos = new Vector3(target.transform.position.x, target.transform.position.y + 5, target.transform.position.z - 5);
        player.transform.position = newPos;
        //Vector3 newDir = Vector3.RotateTowards(transform.forward, target.transform.position - transform.position, Time.deltaTime, 0.0f);

        //player.gameObject.transform.LookAt(target.transform);
        //Camera.main.transform.Rotate(0, 0, 0, Space.World);
        //Camera.main.transform.rotation = Quaternion.LookRotation(newDir);
        //player.transform.rotation = Quaternion.Slerp(player.transform.rotation, target.transform.rotation, 0.5f);
    }

    public void Fade()
    {
        StartCoroutine("FadeOut");
    }

    void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }


}
