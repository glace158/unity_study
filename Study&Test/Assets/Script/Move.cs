using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        moving();
    }

    void moving()
    {
        float speed_x = Input.GetAxis("Horizontal");//'a', 'd' °ª °¡Àú¿È
        float speed_y = Input.GetAxis("Vertical");//'w', 's' °ª °¡Àú¿È

        animator.SetFloat("SpeedX", speed_x);
        animator.SetFloat("SpeedY", speed_y);
    }
}
