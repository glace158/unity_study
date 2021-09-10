using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;

    public GameObject objectpool;

    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //init();
    }

    void init()
    {
        for(int i = 0; i < 6; i++)
        {
            var new_enemy = Instantiate(enemy, transform);
            new_enemy.GetComponent<EnemyRemover>().objectpool = objectpool.transform;
            new_enemy.transform.position = new Vector3(30f, 0f, player.position.z + 10f);
            new_enemy.transform.GetComponent<NavMeshAgent>().enabled = true;
            new_enemy.SetActive(false);
            new_enemy.transform.GetComponent<NavMeshAgent>().enabled = false;
            new_enemy.transform.SetParent(objectpool.transform);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            get_enemy();
        }
    }

    void get_enemy()
    {
        if(objectpool.transform.childCount > 0)
        {
            var new_enemy = objectpool.transform.GetChild(0);
            new_enemy.gameObject.SetActive(true);
            new_enemy.GetComponent<EnemyRemover>().objectpool = objectpool.transform;
            new_enemy.transform.position = new Vector3(30f, 0f, 0f);
            new_enemy.transform.SetParent(gameObject.transform);
            new_enemy.transform.GetComponent<NavMeshAgent>().enabled =true;
            new_enemy.transform.GetComponent<NavMeshAgent>().enabled = false;
            new_enemy.transform.position = new Vector3(30f, 0f, player.position.z + 10f);
            new_enemy.transform.GetComponent<NavMeshAgent>().enabled = true;

        }
        else
        {
            var new_enemy = Instantiate(enemy, transform);
            new_enemy.GetComponent<EnemyRemover>().objectpool = objectpool.transform;
            new_enemy.transform.position = new Vector3(30f, 0f, 0f);
            new_enemy.transform.SetParent(gameObject.transform);
            
            new_enemy.transform.GetComponent<NavMeshAgent>().enabled = true;
            
            new_enemy.transform.GetComponent<NavMeshAgent>().enabled = false;
            new_enemy.transform.position = new Vector3(30f, 0f, player.position.z + 10f);
            new_enemy.transform.GetComponent<NavMeshAgent>().enabled = true;
        }
    }
}
