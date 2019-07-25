using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHealthBar : MonoBehaviour {
    public SimpleHealthBar bar;
    public WeaponControl weaponControl;
    public Text zname;
	// Use this for initialization
	void Start () {
        bar = GetComponent<SimpleHealthBar>();
	}
	
	// Update is called once per frame
	void Update () {
        ZombieHealth zombieHealth = weaponControl.targetAimed.GetComponentInParent<ZombieHealth>();
        if (zombieHealth!=null)
        {

        bar.UpdateBar(zombieHealth.HP,50);
            zname.text = zombieHealth.gameObject.name;
        }
	}
}
