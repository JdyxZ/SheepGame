using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Vars
    public Vector3 movementSpeed;
    public Space space;

    // Update is called once per frame
    void Update()
    {
        transform.Translate (movementSpeed * Time.deltaTime, space);
    }
}
