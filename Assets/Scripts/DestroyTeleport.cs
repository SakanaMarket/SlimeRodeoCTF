using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTeleport : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
}
