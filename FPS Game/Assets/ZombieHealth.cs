using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour {
    [SerializeField]
    public float HP;
    public bool alive = true;
    public Vector3 shootPoint;
    public bool getDamaged=false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Takedamage(float damage,Vector3 vector)
    {
        if (HP>0)
        {
            HP -= damage;
            getDamaged = true;
            if (HP<=0)
            {
                alive = false;
            }
        shootPoint = vector;
        }
        //if (!alive)
        //{
        //    GetComponent<Animator>().SetTrigger("FallBack");
        //    Collider[] colliders= GetComponentsInChildren<Collider>();
        //    foreach (var item in colliders)
        //    {
        //        item.gameObject.SetActive(false);
        //    }
        //    Destroy(gameObject,5f);
        //}
    }
}
