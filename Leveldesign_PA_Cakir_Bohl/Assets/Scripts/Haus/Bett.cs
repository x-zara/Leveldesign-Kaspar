using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bett : MonoBehaviour
{
    public bool _hasPlayed;

    public GameObject text;

    public int nextSceneIndex;

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

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && _hasPlayed)
        {
            text.SetActive(true);
            
        } 
    }


    private void OnTriggerExit(Collider other)
    {
        text.gameObject.SetActive(false);
    }
}
