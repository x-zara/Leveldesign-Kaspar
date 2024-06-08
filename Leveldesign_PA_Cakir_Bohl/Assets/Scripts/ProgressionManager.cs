using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionManager : MonoBehaviour
{
    // Stores the number of collected clues
    public int collectedClues = 0;

    // A boolean that describes if enough clues have been collected to progress
    public bool hasProgressed;


    // Start is called before the first frame update
    void Start()
    {
        hasProgressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (collectedClues == 3)
        {
            print("alles gefunden");
            hasProgressed = true;
        }
    }

    private void ClueCollected()
    {
        collectedClues++;
    }
}
