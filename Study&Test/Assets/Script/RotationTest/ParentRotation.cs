using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentRotation : MonoBehaviour
{
    public Transform target_cube;

    public ArticulationBody body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<ArticulationBody>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = target_cube.rotation;
    }
}
