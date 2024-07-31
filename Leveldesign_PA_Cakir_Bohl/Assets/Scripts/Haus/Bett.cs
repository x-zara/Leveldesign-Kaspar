using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bett : MonoBehaviour
{
    // Boolean to check if the cutscene is playing
    public bool _hasPlayed;

    // The press E text
    public GameObject text;

    // The index of the next scene
    public int nextSceneIndex;

    // Reference to the teleport script
    private Teleport _teleport;

    // Start is called before the first frame update
    void Start()
    {
        _hasPlayed = false;
        text.SetActive(false);
        _teleport = GetComponent<Teleport>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the cutscene is finished and the player is near the bed and presses E, load next scene
        if (_hasPlayed)
        {
            if(text.activeSelf && Input.GetKeyUp(KeyCode.E))
            {
                text.SetActive(false);
                ProgressionManager.Instance.progress++;
                ProgressionManager.Instance.wasInHouse = true;
                StartCoroutine(_teleport.LoadNextScene(nextSceneIndex));
            }
        }
        
    }

    // Show text upon entering the trigger
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && _hasPlayed)
        {
            text.SetActive(true);
            
        } 
    }

    // Hide the text upon leaving the trigger
    private void OnTriggerExit(Collider other)
    {
        text.gameObject.SetActive(false);
    }
}
