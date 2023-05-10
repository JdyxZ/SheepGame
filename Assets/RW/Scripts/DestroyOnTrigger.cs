using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    // Vars
    public string tagFilter;

    // Trigger event
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagFilter))
        {
            Destroy(gameObject);
        }
    }
}
