using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSense : MonoBehaviour {
    [SerializeField]
    GameObject player,target=null;
    public float senseRadius;
    public float eyeRadius;
    public float eyeDegree;
    public float senseTimer = 0f;
    public float senseInterval = 0.5f;
    
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
      
	// Update is called once per frame
	void Update () {
		 
	}
    private void FixedUpdate()
    {
        if (senseTimer>senseInterval)
        {
            senseTimer = 0;
            Sense();
        }
        senseTimer += Time.deltaTime;
    }
    public Transform GetTarget()
    {
        if (target!=null)
        {
        return target.transform;
        }
        return null;
    }
    void Sense()
    {
        if (player!=null)
        {
            float distance = (transform.position - player.transform.position).magnitude;
            if (distance<=senseRadius)
            {
                target = player;
            }
            else
            {
                target = null;
            }
            if (distance<=eyeRadius)
            {
                Vector3 direction = (transform.position - player.transform.position);
                float degree = Vector3.Angle(transform.forward, direction);
                if (degree<=eyeDegree)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, direction, out hit, 100f))
                    {
                        if (hit.transform == player.transform)
                        {
                            target = player;
                        }
                        else
                        {
                            target = null;
                        }
                    }
                }
            }
            return;
        }
        Debug.Log("Player not find");
    }

}
