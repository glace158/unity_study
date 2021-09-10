using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollMode : MonoBehaviour
{
    Collider main_collider;
    Rigidbody main_rigidbody;
    Animator animator;

    bool ragboll_state = false;

    Collider[] ragdoll_colliders;
    Rigidbody[] limbs_rigidbodies;

    private void Awake()
    {
        main_collider = GetComponent<Collider>();
        main_rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        get_ragdoll_bits();
    }


    public bool get_ragboll_state()
    {
        return ragboll_state;
    }

    void get_ragdoll_bits()
    {
        ragdoll_colliders = gameObject.GetComponentsInChildren<Collider>();
        limbs_rigidbodies = gameObject.GetComponentsInChildren<Rigidbody>();
    }

    void set_ragdoll_mode(bool state)
    {
        foreach(Collider col in ragdoll_colliders)
        {
            col.enabled = state;
        }

        foreach (Rigidbody rigid in limbs_rigidbodies)
        {
            rigid.isKinematic = !state;
        }

        animator.enabled = !state;
        main_collider.enabled = !state;
        main_rigidbody.isKinematic = state;

        ragboll_state = state;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            set_ragdoll_mode(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            set_ragdoll_mode(true);
            StartCoroutine(delay(false));
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            turnoff(true);
            set_ragdoll_mode(false);

        }
    }

    void turnoff(bool state)
    {
        gameObject.SetActive(state);
    }
    
    IEnumerator delay(bool state)
    {
        yield return new WaitForSeconds(3f);
        turnoff(state);
    }

    private void OnEnable()
    {
        set_ragdoll_mode(false);
    }
}
