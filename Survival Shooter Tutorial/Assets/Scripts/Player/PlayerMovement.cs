using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 6f;


    Vector3 movement;
    Animator anim;
    Rigidbody playerrigidbody;
    int floorMask;
    float camRayLength = 100f;
    
    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerrigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        move(h, v);
        Turning();
        Animating(h,v);
    }

    void move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * Speed * Time.deltaTime;
        playerrigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);
            playerrigidbody.MoveRotation(newRotatation);
            Debug.Log(playerToMouse);
        }
    }
    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("Move", walking);
    }
}
