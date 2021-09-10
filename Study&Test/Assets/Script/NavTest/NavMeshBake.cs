using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBake : MonoBehaviour
{
    public NavMeshSurface[] surfaces;

    public GameObject map;

    public Vector3 offsePosition;

    public Transform objectpool;

    int count = 1;

    Queue<GameObject> map_queue = new Queue<GameObject>();
    BoxCollider box_collider;


    private void Start()
    {
        offsePosition = map.transform.position;
        box_collider = GetComponent<BoxCollider>();
        surfaces = GetComponents<NavMeshSurface>();

        for(int i =0; i < 3; i++)
        {
            map_spawn();
        }
        rebuild_navmesh();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            box_collider.center = new Vector3(0f, 0f, box_collider.center.z + 10f);
            map_spawn();
            rebuild_navmesh();
        }
    }

    void map_spawn()
    {
        GameObject obj = null;

        if(objectpool.childCount > 0)
        {
            obj = objectpool.GetChild(0).gameObject;
            obj.SetActive(true);
        }
        else
        {
            obj = Instantiate(map);
        }

        map_queue.Enqueue(obj);
        obj.transform.SetParent(transform);
        set_position(obj.transform);
        count++;

        if(map_queue.Count > 3)
        {
            return_map();
        }
    }

    void set_position(Transform map)
    {
        map.position = new Vector3(offsePosition.x, offsePosition.y, offsePosition.z + count * 10f);
    }

    void return_map()
    {
        var obj = map_queue.Dequeue();
        obj.SetActive(false);
        obj.transform.SetParent(objectpool);
    }

    void rebuild_navmesh()
    {
        foreach(NavMeshSurface surface in surfaces)
        {
            surface.BuildNavMesh();
        }
    }
}
