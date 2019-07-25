using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSound : MonoBehaviour {
    public AudioClip sound;
	// Use this for initialization
	void Start () {
        AudioSource.PlayClipAtPoint(sound, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
