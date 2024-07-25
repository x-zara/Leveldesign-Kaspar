using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public bool _hasKey;

    public GameObject text;

    private Teleport _teleport;

    // Start is called before the first frame update
    void Start()
    {
        _hasKey = false;

        text.gameObject.SetActive(false);

        _teleport = GetComponent<Teleport>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && _hasKey)
        {
            StartCoroutine(_teleport.LoadNextScene(1));
        }
        else
        {
            text.gameObject.SetActive(true);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        text.gameObject.SetActive(false);
    }
}
