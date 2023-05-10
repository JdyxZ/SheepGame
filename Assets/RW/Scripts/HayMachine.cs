using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    // Vars
    public float movementSpeed = 10;
    public Vector2 horizontalBoundary = new Vector2(22,22);
    public GameObject hayBalePrefab; 
    public Transform haySpawnpoint;
    public float shootInterval = 0.8f;
    private float shootTimer;

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateShooting();
    }

    // Other methods
    private void UpdateMovement()
    {
        // Get horizontal direction
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // Translate
        if(horizontalInput < 0 && transform.position.x > -horizontalBoundary.x) 
        {
            transform.Translate(-movementSpeed * Time.deltaTime * transform.right);
        }
        else if(horizontalInput > 0 && transform.position.x < horizontalBoundary.y)
        {
            transform.Translate(movementSpeed * Time.deltaTime * transform.right);
        }
    }

    private void createHayBale()
    {
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
    }

    private void shootHayBale()
    {
        shootTimer = shootInterval;
        createHayBale();
    }

    private void UpdateShooting()
    {
        // Update timer
        shootTimer -= Time.deltaTime;

        // Shoot
        if (shootTimer < 0 && Input.GetKey(KeyCode.Space))
            shootHayBale();  
    }

}
