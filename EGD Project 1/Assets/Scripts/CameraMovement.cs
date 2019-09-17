using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Range(0,1)]
    [SerializeField] float speed = 0.1f;
    Vector3 offset;
    //target should be set to the first player to get correctOffset
    public GameObject target = null;
    void Start()
    {
        if(target!=null){
            offset = transform.position - target.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        TrackTarget();
    }
    public void SetTarget(GameObject newTarget){
        transform.position = newTarget.transform.position + offset;
        target = newTarget;
    }
    public void TrackTarget(){
        //camera code to track target here
        //change this to better code later..........
        if(target==null){
            return;
        }
        transform.position = Vector3.Slerp(transform.position,target.transform.position + offset,speed);
    }
}
