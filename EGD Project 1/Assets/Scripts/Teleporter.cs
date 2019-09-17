using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleporter : MonoBehaviour
{
    public GameObject target;
    public Camera main;
    public Image fade;
    float startTime;
    public float fadeTime = 0.5f;
    public float fadeDelay = 0.2f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        fade.canvasRenderer.SetAlpha(0.0f);
        startTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
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
        // Wait for fade out
        startTime = Time.time;
        while (Time.time - startTime < fadeDelay)
        {
            yield return null;
        }
        // Fade in
        fade.CrossFadeAlpha(0.0f, fadeTime, false);
    }

    private void MovePlayer()
    {
        // Move player
        player.transform.position = target.transform.position;
    }

    public void Fade()
    {
        StartCoroutine("FadeOut");
    }


}
