using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressionManager : MonoBehaviour
{
    // stores the current progress
    public int progress;

    // Bool to tell if the player inside the houses
    public bool wasInHouse = false;

    // Makes Progression Manager static Instance
    public static ProgressionManager Instance;

    // https://learn.unity.com/tutorial/implement-data-persistence-between-scenes#634f8281edbc2a65c86270cb
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        

    }
}
