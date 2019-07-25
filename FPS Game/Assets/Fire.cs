using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
    public Transform spawn;
    public float range = 100f;
	// Use this for initialization
	void Start () {
        spawn = GetComponentInChildren<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(spawn.position, transform.forward, out hit, range))
        {
            print(hit.point);
        }
	}
}
