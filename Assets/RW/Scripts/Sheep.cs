using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    // Vars
    public float runSpeed;
    public float hitDestroyDelay;
    public float dropDestroyDelay;
    private bool hitByHay = false; // to control the sheep is already being destroyed
    private bool dropping = false;
    private Collider sheepCollider;
    private Rigidbody sheepRigidbody;
    private SheepSpawner sheepSpawner;
    public float heartOffset; 
    public GameObject heartPrefab;

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
        // Set hit flag to true
        hitByHay = true;

        // Update the saved sheep number
        GameStateManager.Instance.SaveSheep();

        // Remove instance from list
        sheepSpawner.RemoveSheepFromList(gameObject);

        // Play sheep hit sound
        SoundManager.Instance.PlaySheepHitClip();

        // Sheep animation
        sheepAnimation();

        // Heart animation
        heartAnimation();

        // Destroy
        Destroy(gameObject, hitDestroyDelay);
    }

    private void dropSheep()
    {
        // Set dropping state to true
        dropping = true;

        // Update the dropped sheep number
        GameStateManager.Instance.DropSheep();

        // Remove instance from list
        sheepSpawner.RemoveSheepFromList(gameObject);

        // Play sheep drop sound
        SoundManager.Instance.PlaySheepDroppedClip();

        // Drop animation
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
            if(!dropping) dropSheep();
        }

    }

    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;
    }

    private void heartAnimation()
    {
        // Create instance
        Instantiate(heartPrefab, transform.position + new Vector3(0, heartOffset, 0), Quaternion.identity);
    }

    private void sheepAnimation()
    {
        // Stop the sheep
        runSpeed = 0;

        // Tween scale it 
        TweenScale tweenScale = gameObject.AddComponent<TweenScale>();
        tweenScale.targetScale = 0;
        tweenScale.timeToReachTarget = hitDestroyDelay;
    }
}
