using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmoDisplay : MonoBehaviour {
    public WeaponControl gun;
    Text amo;
	// Use this for initialization
	void Start () {
        amo = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        amo.text = gun.curammo + "/" + gun.restammo;
	}
}
