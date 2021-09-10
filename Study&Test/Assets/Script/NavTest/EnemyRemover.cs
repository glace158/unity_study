using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRemover : MonoBehaviour
{
    public Transform objectpool;
    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            return_enemy();
        }
    }

    void return_enemy()
    {
        transform.SetParent(objectpool);
        transform.gameObject.SetActive(false);
        agent.enabled = false;
    }
}
