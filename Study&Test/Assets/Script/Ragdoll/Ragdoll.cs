using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    [SerializeField]
    Rigidbody spine;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spine.AddForce(new Vector3(0f, 300f, -300f), ForceMode.Impulse);
        }   
    }
}
