using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbyBoy : MonoBehaviour
{
    public float speed = 2f;
    public float amp = .5f;
    Vector3 origPos;
    // Start is called before the first frame update
    void Start()
    {
        origPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = origPos;
        newPos.y += Mathf.Sin(Time.time*speed)*amp;
        transform.position = newPos;
    }
}
