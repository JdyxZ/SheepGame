using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    // Vars
    public float runSpeed;
    public float hitDestroyDelay;
    private bool hitByHay; // to control the sheep is already being destroyed
    public float dropDestroyDelay;
    private Collider sheepCollider;
    private Rigidbody sheepRigidbody;
    private SheepSpawner sheepSpawner;

    // Start is called before the first frame update
    void Start()
    {
        sheepCollider = GetComponent<Collider>();
        sheepRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(runSpeed * Time.deltaTime * Vector3.forward);
    }

    // Other methods
    private void destroySheep()
    {
        // Setup
        sheepSpawner.RemoveSheepFromList(gameObject);
        hitByHay = true;
        runSpeed = 0;

        // Destroy
        Destroy(gameObject, hitDestroyDelay);
    }

    private void dropSheep()
    {
        // Setup
        sheepSpawner.RemoveSheepFromList(gameObject);
        sheepRigidbody.isKinematic = false;
        sheepCollider.isTrigger = false;

        // Destroy
        Destroy(gameObject, dropDestroyDelay);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HayBale") && !hitByHay)
        {
            // Destroy HayBale
            Destroy(other.gameObject);

            // Destroy sheep (with delay)
            destroySheep();
        }
        else if (other.CompareTag("DropSheep"))
        {
            // Drop and destroy sheep (with delay)
            dropSheep();
        }

    }

    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;
    }
}
