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
    public float fadeTime;

    // Start is called before the first frame update
    void Start()
    {
        fade.canvasRenderer.SetAlpha(0.0f);
        startTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        startTime += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Trigger fade out
            StartCoroutine("FadeOut",other.gameObject);
        }
    }

    IEnumerator FadeOut(GameObject player)
    {
        // Do some kind of effect/sound?

        // First fade out
        fade.CrossFadeAlpha(1.0f, fadeTime, false);

        // Wait for fade out
        startTime = Time.time;
        while (Time.time - startTime < fadeTime)
        {
            yield return null;
        }

        // Move player
        player.transform.position = target.transform.position;

        // Fade in
        fade.CrossFadeAlpha(0.0f, fadeTime, false);
    }


}
