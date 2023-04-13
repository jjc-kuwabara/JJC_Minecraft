using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollisionManager : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "BlockModel")
        {
            GameObject block = other.transform.parent.gameObject;
            Destroy(block);
        }
    }
}
