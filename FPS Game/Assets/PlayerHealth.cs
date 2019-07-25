using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    float HP;
    bool alive = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            alive = false;
        }
    }
    public void Takedamage(float damage)
    {
        if (HP > 0)
        {
            HP -= damage;
        }
    }
}
