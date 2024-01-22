using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildRotation : MonoBehaviour
{
    public Transform target_cube;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = target_cube.rotation;
        transform.parent.rotation = transform.rotation;
    }
}
