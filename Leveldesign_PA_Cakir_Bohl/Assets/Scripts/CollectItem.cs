using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    // The pressE command text
    public GameObject pressE;

    // The key gameobject that needs to be found
    private GameObject _key;
    
    // Reference to the lockedDoor script
    private LockedDoor _lockedDoor;

    // Boolean to tell if the player is in range of the item to collect it
    private bool _inRange;

    
    
    // Start is called before the first frame update
    void Start()
    {
        _lockedDoor = GameObject.Find("Teleport_Trigger").GetComponent<LockedDoor>();
        _key = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // Collects the item if the E key is pressed while the player is close enough
        if (Input.GetKeyDown(KeyCode.E) && _inRange)
        {
            pressE.gameObject.SetActive(false);
            _lockedDoor._hasKey = true;
            gameObject.SetActive(false);
            _key.SetActive(false);
        }
    }

    // On Trigger Enter: enable the 'press E' text and set inRange to true
    private void OnTriggerEnter(Collider other)
    {
        pressE.gameObject.SetActive(true);
        _inRange = true;
    }

    // On Trigger Exit: set inRange to false, disable text object
    private void OnTriggerExit(Collider other)
    {
        _inRange = false;
        pressE.gameObject.SetActive(false);
        
    }
}
