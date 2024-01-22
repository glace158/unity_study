using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float _speed = 1f;
    public float _trun_gain = 60f;
    public float smoothness = 5f;
    public Transform look_target;

    Vector3 movement;

    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        move(h, v);
    }

    void move(float h, float v)
    {
        if (v == 0 && h != 0)
        {
            //look_target.rotation *= Quaternion.Euler(look_target.up * _speed * _trun_gain * Time.deltaTime * h);
            //look_target.Rotate(0.0f, _speed * _trun_gain * Time.deltaTime * h, 0.0f);
            look_target.Rotate(look_target.up * _speed * _trun_gain * Time.deltaTime * h);
            transform.rotation = look_target.rotation;
            //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, look_target.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
        else if (v != 0 || h != 0)
        {
            movement.Set(h, 0f, v);
            //look_target.rotation *= Quaternion.Euler(look_target.up * _speed * _trun_gain * Time.deltaTime * h);
            //transform.rotation = look_target.rotation;
            //look_target.Rotate(0.0f, _speed * _trun_gain * Time.deltaTime * h, 0.0f);

            movement = movement.normalized * _speed * Time.deltaTime;
            transform.Translate(movement);
        }
    }
}
