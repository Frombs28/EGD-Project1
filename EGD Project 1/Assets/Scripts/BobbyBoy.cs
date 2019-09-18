using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbyBoy : MonoBehaviour
{
    private float speed;
    private float amp;
    Vector3 origPos;
    // Start is called before the first frame update
    void Start()
    {
        origPos = transform.position;
        speed = Random.Range(1, 2.1f);
        amp = Random.Range(.1f, .6f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = origPos;
        newPos.y += Mathf.Sin(Time.time*speed)*amp;
        transform.position = newPos;
    }
}
