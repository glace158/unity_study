using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public Transform enemy;
    public int max_count = 10;
    int count = 0;
    float timer = 0f;
    float spawn_time = 5f;

    private void Update()
    {
        timer += Time.deltaTime;


        if(timer >= spawn_time)
        {
            for(int i = 0; i < max_count; i++)
            {
                spawn_enemy();
            }

            enemy.GetComponent<NavMeshAgent>().enabled = true;
            timer = 0f;
        }
    }

    void spawn_enemy()
    {
        var new_enemy = Instantiate(enemy);
        set_position(new_enemy);
        count++;
    }

    void set_position(Transform enemy)
    {
        float x = Random.Range(-40, 40);
        float z = Random.Range(-40, 40);
        Vector3 spawnpoint = new Vector3(x, 0f, z);
        Debug.Log(spawnpoint);
        enemy.position = spawnpoint;
    }

    
}
