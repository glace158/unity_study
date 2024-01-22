using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    private RaycastHit hit;
    private int layerMask;

    // Start is called before the first frame update
    void Start()
    {
        layerMask = 1 << 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log("Hit ground : ");
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            Debug.DrawRay(transform.position, transform.forward * 10000f, Color.gray);
            Debug.DrawRay(hit.point, hit.normal, Color.blue);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 10000f, Color.gray);
        }
    }
}
