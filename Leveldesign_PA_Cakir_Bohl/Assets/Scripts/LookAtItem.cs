using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LookAtItem : MonoBehaviour
{
    // The description of the item that's being looked at
    public TextMeshProUGUI itemDescription;

    // The 'press E' text
    public TextMeshProUGUI pressE;

    // A boolean that determines if the player is close enough to the object to press E
    private bool inRange;
    
    // Start is called before the first frame update
    void Start()
    {
        // Disable all text objects
        itemDescription.gameObject.SetActive(false);
        pressE.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // If the E key is pressed and the character is in range: disable the 'press E' text and enablle the corresponding item description
        if(Input.GetKeyDown(KeyCode.E) && inRange)
        {
            pressE.gameObject.SetActive(false);
            itemDescription.gameObject.SetActive(true);
        }
    }

    // On Trigger Enter: enable the 'press E' text and set inRange to true
    private void OnTriggerEnter(Collider other)
    {
        pressE.gameObject.SetActive(true);
        inRange = true;
    }

    // On Trigger Exit: set inRange to false, disable both text objects
    private void OnTriggerExit(Collider other)
    {
        inRange = false;
        itemDescription.gameObject.SetActive(false);
        pressE.gameObject.SetActive(false);
    }
}