using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {
            Debug.Log("crash");
            set_position();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {
            Debug.Log("crash");
            set_position();
        }
    }

    void set_position()
    {
        float x = Random.Range(-40, 40);
        float z = Random.Range(-40, 40);
        Vector3 spawnpoint = new Vector3(x, 0f, z);
        transform.position = spawnpoint;
    }
}
