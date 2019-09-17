using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

    private float rotateX;
    private float rotateY;
    public float rotateSpeedX;
    public float rotateSpeedY;
    public bool fading = false;

    // Use this for initialization
    void Start () {
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!fading)
        {
            rotateX += rotateSpeedX * Input.GetAxis("Mouse X");
            rotateY -= rotateSpeedY * Input.GetAxis("Mouse Y");
            rotateY = Mathf.Clamp(rotateY, -90, 90);
            transform.eulerAngles = new Vector3(rotateY, rotateX, 0);
        }
    }
}
