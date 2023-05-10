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
    public Transform modelParent; 
    public GameObject blueModelPrefab;
    public GameObject redModelPrefab;
    public GameObject yellowModelPrefab;

    // Start is called before the first frame update
    void Start()
    {
        LoadModel();
    }
    
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
        // Instantiate
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
    }

    private void shootHayBale()
    {
        // Create bale
        shootTimer = shootInterval;
        createHayBale();

        // Singleton play audio
        SoundManager.Instance.PlayShootClip();
    }

    private void UpdateShooting()
    {
        // Update timer
        shootTimer -= Time.deltaTime;

        // Shoot
        if (shootTimer < 0 && Input.GetKey(KeyCode.Space))
            shootHayBale();  
    }

    private void LoadModel()
    {
        // Destroy current model
        Destroy(modelParent.GetChild(0).gameObject); 

        // Instantiate new model into the modelParent depending on the hay machine color
        switch (GameSettings.hayMachineColor) 
        {
            case HayMachineColor.Blue:
                Instantiate(blueModelPrefab, modelParent);
                break;

            case HayMachineColor.Yellow:
                Instantiate(yellowModelPrefab, modelParent);
                break;

            case HayMachineColor.Red:
                Instantiate(redModelPrefab, modelParent);
                break;
        }
    }


}
