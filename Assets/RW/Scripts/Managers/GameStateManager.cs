using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    // Vars
    public static GameStateManager Instance; 
    [HideInInspector] public int sheepSaved = 0;
    [HideInInspector] public int sheepDropped = 0;
    public int sheepDroppedBeforeGameOver; 
    public SheepSpawner sheepSpawner;

    // Awake runs before the start method
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }

    // Other methods
    public void SaveSheep()
    {
        // Update counter
        sheepSaved++;

        // Update UI
        UIManager.Instance.UpdateSheepSaved();
    }

    public void DropSheep()
    {
        // Update counter
        sheepDropped++;

        // Update UI
        UIManager.Instance.UpdateSheepDropped();

        // Update game status
        if (sheepDropped == sheepDroppedBeforeGameOver) 
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        // Stop spawner
        sheepSpawner.canSpawn = false; 

        // Remove sheep instances
        sheepSpawner.DestroyFlock();

        // Load game over window
        UIManager.Instance.ShowGameOverWindow();
    }


}
