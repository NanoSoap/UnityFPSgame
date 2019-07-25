using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum FSMState
{
    Wander,     
    Seek,       
    Chase,      
    Attack, 
    Dead,		    
}
public class ZombieAI : MonoBehaviour {
    FSMState currentState=FSMState.Wander;
    [SerializeField]
    Transform target=null;
    ZombieSense sensor;
    ZombieHealth health;
    NavMeshAgent agent;
    Animator anim;
    public AudioClip zombieAttackAudio; //zombieDie;
    public float wanderScope;
   // public float wanderSpeed;
    public float seekDistance;
    public float attackRange;
    public float attackFieldOfView;
    public float attackInterval;
    public int attackDamage;
    bool firstInDead=false;

    [SerializeField]
    float stopTime;
    [SerializeField]
    float attackTimer;

    void UpdateFSM()
    {
        if (currentState != FSMState.Dead && !health.alive)
        {
            currentState = FSMState.Dead;
        }
        switch (currentState)
        {
            case FSMState.Wander:
                UpdateWanderState();
                break;
            case FSMState.Seek:
                UpdateSeekState();
                break;
            case FSMState.Chase:
                UpdateChaseState();
                break;
            case FSMState.Attack:
                UpdateAttackState();
                break;
            case FSMState.Dead:
                UpdateDeadState();
                break;
            default: break;
        }

    }

    void UpdateWanderState()
    {
        target = sensor.GetTarget();
        if (target != null)
        {
            anim.SetBool("Walk", false);
            currentState = FSMState.Chase;
            agent.ResetPath();
            return;
        }

        if (health.getDamaged)
        {
            anim.SetBool("Walk", false);
            currentState = FSMState.Seek;
            agent.ResetPath();
            return;
        }
        agent.speed = 0.5f;
        anim.SetBool("Walk", true);
        if (AgentDone())
        {  
            Vector3 randomRange = new Vector3((Random.value - 0.5f) * 2 * wanderScope,
                                            0, (Random.value - 0.5f) * 2 * wanderScope);
            Vector3 nextDestination = transform.position + randomRange;
            agent.destination = nextDestination;
        }
        CalculateStopTime();
        if (stopTime > 1.0f)
        {
            Vector3 nextDestination = transform.position
                - transform.forward * (Random.value) * wanderScope;
            agent.destination = nextDestination;
        }
    }
    public void CalculateStopTime()
    {
        if (agent.velocity == Vector3.zero)
        {
            stopTime += Time.deltaTime;
        }
        else
        {
            stopTime = 0f;
        }
    }

    public bool AgentDone()
    {
        return !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance;
    }
        //setMaxAgentSpeed(wanderSpeed);//restrict wander speed
    void UpdateSeekState()
    {
        target = sensor.GetTarget();
        if (target != null)
        {
            anim.SetBool("Seek", false);
            currentState = FSMState.Chase;
            agent.ResetPath();
            return;
        }
        if (health.getDamaged)
        {
            agent.speed = 0.8f;
            anim.SetBool("Seek", true);
            Vector3 seekDirection = health.shootPoint-transform.position;
            agent.destination = transform.position
               + seekDirection.normalized * seekDistance;
            health.getDamaged = false;
        }
        CalculateStopTime();
        if (AgentDone() || stopTime > 1.0f)
        {
            currentState = FSMState.Wander;
            agent.ResetPath();
            return;
        }
    }
    void UpdateChaseState()
    {
        target = sensor.GetTarget();
        if (target == null)
        {
            anim.SetBool("Chase", false);
            currentState = FSMState.Wander;
            agent.ResetPath();
            return;
        }
        if (Vector3.Distance(target.position, transform.position) <= attackRange)
        {
            anim.SetBool("Chase", false);
            currentState = FSMState.Attack;
            agent.ResetPath();
            return;
        }
        anim.SetBool("Chase", true);
        attackTimer = attackInterval;
        agent.speed = 3.5f;
        agent.SetDestination(target.position);
        CalculateStopTime();
        if (AgentDone() || stopTime > 1.0f)
        {
            currentState = FSMState.Wander;
            agent.ResetPath();
            return;
        }
    }

    void UpdateAttackState()
    {
        target = sensor.GetTarget();
        if (target == null)
        {
            currentState = FSMState.Wander;
            agent.ResetPath();
            return;
        }
        if (Vector3.Distance(target.position, transform.position) > attackRange)
        {
            agent.ResetPath();
            currentState = FSMState.Chase;
            //anim.SetTrigger("Attack1");
            return;
        }
        attackTimer += Time.deltaTime;
        Vector3 direction = target.position - transform.position;
        float degree = Vector3.Angle(direction, transform.forward);
        if (degree < attackFieldOfView / 2f)
        {
            if (attackTimer >= attackInterval)
            {
                attackTimer = 0;
                anim.SetTrigger("Attack"+ Random.Range(1,3));
                
                if (zombieAttackAudio != null)
                    AudioSource.PlayClipAtPoint(zombieAttackAudio, transform.position);
                target.GetComponentInChildren<PlayerHealth>().Takedamage(attackDamage);
            }
        }
        else
        {
            //如果玩家不在僵尸前方，僵尸需要转向后才能攻击
            //animator.SetBool("isAttack", false);
            transform.LookAt(Vector3.Lerp(transform.position, target.position, Time.fixedDeltaTime * 2f));
        }
    }
    void UpdateDeadState()
    {
        if (!firstInDead)
        {
            firstInDead = true;
            agent.ResetPath();
            agent.enabled = false;
            anim.SetTrigger("FallBack");
        //AudioSource.PlayClipAtPoint(zombieDie, transform.position);
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (var item in colliders)
        {
            item.gameObject.SetActive(false);
        }
        Destroy(gameObject, 5f);
        }
    }
    // Use this for initialization
    void Start () {
        sensor = GetComponent<ZombieSense>();
        health = GetComponent<ZombieHealth>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate()
    {
        UpdateFSM();

    }
}
