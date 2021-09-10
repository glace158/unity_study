using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Move : MonoBehaviour
{
    NavMeshAgent agent;

    Animator anim;

    Transform player;

    bool running = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        agent.updateRotation = false;
    }


    void FixedUpdate()
    {
        agent.SetDestination(player.position);

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            enemy_rotation();
            enemy_run();
        }
        else
        {
            enemy_rotation();
            enemy_stop();
        }
    }

    void enemy_rotation()
    {
        Vector3 direction = agent.desiredVelocity;
        
        if(direction == Vector3.zero)
        {
            direction = player.position - transform.position;
            direction.Normalize();
        }

        Quaternion targetangle = Quaternion.LookRotation(direction);
        transform.rotation = targetangle;
    }
    
    void enemy_run()
    {
        float speed = Mathf.Max(Mathf.Abs(agent.desiredVelocity.x), Mathf.Abs(agent.desiredVelocity.y), Mathf.Abs(agent.desiredVelocity.z));

        anim.SetFloat("SpeedY", speed);
    }

    void enemy_stop()
    {
        anim.SetFloat("SpeedY", 0f);
    }
}
