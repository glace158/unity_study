using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMove : MonoBehaviour
{
    NavMeshAgent agent;
    Camera main_camera;

    void Start()
    {
        main_camera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        agent.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(main_camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
