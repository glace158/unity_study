using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove2 : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bullet;

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        move_xz(h, v);
        move_y();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            fire();
        }
    }
    
    void move_xz(float h, float v)
    {
        transform.position = new Vector3(transform.position.x + h * speed, transform.position.y, transform.position.z + v *speed);
    }

    void move_y()
    {
        if (Input.GetKey("e"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1 * speed, transform.position.z);
        }
        else if(Input.GetKey("q"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1 * speed, transform.position.z);
        }
    }
    
    void fire()
    {
        var obj = Instantiate(bullet, transform);
        obj.GetComponent<Rigidbody>().AddForce(obj.transform.forward * 25f, ForceMode.Impulse);
    }
}
