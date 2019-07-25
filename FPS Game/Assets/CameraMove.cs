using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

     public   Transform character;
    Vector3 offset;
    // Use this for initialization
    void Start () {
        offset = transform.position - character.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 target = character.position + offset;
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * 2f);
	}
}
