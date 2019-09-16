using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Move : MonoBehaviour {

    public float speed;
    private Rigidbody rgd;
    private Vector3 mousePos;
    public Camera cam;
    private Vector3 camDir;
    private Vector3 camSid;
    public AudioSource footStep;
    bool playing = false;
    public Text txt;

    bool isPlayerControllable = true;

    [Space]
    [SerializeField]
    private float deadRotationSpeed = .5f;


    // Use this for initialization
    void Start () {
        rgd = GetComponent<Rigidbody>();
    }

    public void SetPlayerControllable(bool state)
    {
        isPlayerControllable = state;
    }

	// Update is called once per frame
	void Update () {
        if (isPlayerControllable)
        {
            camDir = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z).normalized;
            camSid = new Vector3(cam.transform.right.x, 0, cam.transform.right.z).normalized;
            if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
            {
                transform.position = transform.position + Input.GetAxis("Horizontal") * camSid * Time.deltaTime * speed;
            }
            if (Mathf.Abs(Input.GetAxis("Vertical")) > 0)
            {
                transform.position = transform.position + Input.GetAxis("Vertical") * camDir * Time.deltaTime * speed;
            }
            if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0 && !playing || Mathf.Abs(Input.GetAxis("Vertical")) > 0 && !playing)
            {
                footStep.Play();
                playing = true;
            }
            if (Mathf.Abs(Input.GetAxis("Horizontal")) == 0 && Mathf.Abs(Input.GetAxis("Vertical")) == 0)
            {
                footStep.Stop();
                playing = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(isPlayerControllable)
        {
            if(other.tag == "Teleporter")
            {
                txt.text = "Press E";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //put teleport code here
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Teleporter")
        {
            txt.text = "";
        }
    }
}
