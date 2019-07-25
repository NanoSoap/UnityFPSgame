using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeaponControl : MonoBehaviour
{
    Animator anim;
    public float firerate, range, recoilv, recoilh, damage;
    public int mag;
    public Transform shootpoint;
    public AudioSource auds;
    public GameObject particle, hole;
    float firecount;
    int fire = Animator.StringToHash("fire");
    public int curammo, restammo;
    bool fireable;
    [SerializeField]
    RaycastHit hit;
    [SerializeField]
    public Collider targetAimed;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        auds = GetComponent<AudioSource>();
        Aim();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetButton("Fire1") && (firecount >= firerate) && curammo > 0 && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            Fire();
            firecount = 0;
        }
        if (Input.GetKeyDown(KeyCode.R) && restammo > 0 && !anim.GetCurrentAnimatorStateInfo(0).IsName("Reload"))
        {
            Reload();
        }
        firecount += Time.deltaTime;
    }
    void Update()
    {
        Aim();
    }
    void Aim()
    {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.forward);
        RaycastHit _hit;
        if (Physics.Raycast(ray, out _hit, range))
        {
            hit = _hit;
            targetAimed = _hit.collider;
        }
    }
    void Fire()
    {
        Playshootsound();
        anim.SetTrigger(fire);
        curammo -= 1;
        switch (targetAimed.tag)
        {
            case "Wall":

                GameObject _particle = Instantiate(particle, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                GameObject _hole = Instantiate(hole, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                break;

            case "Head":
                targetAimed.GetComponentInParent<ZombieHealth>().Takedamage(damage * 2f, transform.position);
                targetAimed.GetComponentInParent<Animator>().SetTrigger("HitHead");
                break;
            case "Body":
                targetAimed.GetComponentInParent<ZombieHealth>().Takedamage(damage, transform.position);
                targetAimed.GetComponentInParent<Animator>().SetTrigger("HitBody");
                break;
            default:
                break;
        }

        //camera.rotation = Quaternion.LookRotation( camera.forward + camera.up * recoilv + camera.right * recoilh);

    }
    void Reload()
    {
        anim.SetTrigger("reload");
        if (restammo > (mag - curammo))
        {
            restammo -= (mag - curammo);
            curammo = mag;
        }
        else
        {
            curammo = restammo;
            restammo = 0;
        }
    }
    void Playshootsound()
    {
        auds.Play();
    }
}
