using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WallSpawner : MonoBehaviour
{
    public Transform wall;
    public int max_count = 20;
    int count = 0;
    float timer = 0f;
    float respawn_time = 3;

    private void Update()
    {
        if(count < max_count)
        {
            spawn_wall();
            GetComponent<NavMeshSurface>().BuildNavMesh();
        }
        timer += Time.deltaTime;

        if(timer >= respawn_time)
        {
            reset_wall();
            GetComponent<NavMeshSurface>().BuildNavMesh();
            timer = 0f;
        }
    }


    void spawn_wall()
    {
        var new_wall = Instantiate(wall);
        new_wall.SetParent(transform);
        set_positon(new_wall);
        count++;
    }

    void set_positon(Transform wall)
    {
        float x = Random.Range(-40, 40);
        float z = Random.Range(-40, 40);
        Vector3 spawnpoint = new Vector3(x, 0f, z);
        wall.position = spawnpoint;
    }

    void reset_wall()
    {
        for(int i = 0; i <transform.childCount; i++)
        {
            set_positon(transform.GetChild(i));
        }
    }
}
