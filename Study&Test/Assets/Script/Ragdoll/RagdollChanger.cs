using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollChanger : MonoBehaviour
{
    public GameObject charobj;
    public GameObject ragdollobj;

    public Rigidbody spine;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeRagdoll();
        }
    }

    public void ChangeRagdoll()
    {
        copy_character_transform_to_ragdoll(charobj.transform, ragdollobj.transform);
        charobj.SetActive(false);
        ragdollobj.SetActive(true);

        spine.AddForce(new Vector3(0f, 0f, 300f), ForceMode.Impulse);
    }

    void copy_character_transform_to_ragdoll(Transform origin, Transform ragdoll)
    {
        for(int i = 0; i < origin.childCount; i++)
        {
            if(origin.childCount != 0)
            {
                copy_character_transform_to_ragdoll(origin.GetChild(i), ragdoll.GetChild(i));
            }
            ragdoll.GetChild(i).localPosition = origin.GetChild(i).localPosition;
            ragdoll.GetChild(i).localRotation = origin.GetChild(i).localRotation ;
        }
    }
}
