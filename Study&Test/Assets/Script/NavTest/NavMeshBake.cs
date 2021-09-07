using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBake : MonoBehaviour
{
    public NavMeshSurface[] surfaces;

    public GameObject map;

    public Vector3 offsePosition;
    int count = 1;

    private void Start()
    {
        offsePosition = map.transform.position;

        surfaces = GetComponents<NavMeshSurface>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            map_spawn();
            rebuild_navmesh();
        }
    }

    void map_spawn()
    {
        var obj = Instantiate(map);
        obj.transform.position = new Vector3(offsePosition.x, offsePosition.y, offsePosition.z + count * 10f);
        obj.transform.SetParent(this.gameObject.transform);
        count++;
    }

    void rebuild_navmesh()
    {
        foreach(NavMeshSurface surface in surfaces)
        {
            surface.BuildNavMesh();
        }
    }
}
