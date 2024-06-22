using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public GameObject pressE;

    private GameObject _key;
    
    private Teleport _teleport;

    private bool _inRange;

    
    
    // Start is called before the first frame update
    void Start()
    {
        _teleport = GameObject.Find("Teleport_Trigger").GetComponent<Teleport>();
        _key = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _inRange)
        {
            pressE.gameObject.SetActive(false);
            _teleport._hasKey = true;
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

    // On Trigger Exit: set inRange to false, disable both text objects
    private void OnTriggerExit(Collider other)
    {
        _inRange = false;
        pressE.gameObject.SetActive(false);
        // Start the coroutine to hide the image and then disable it after
    }
}
