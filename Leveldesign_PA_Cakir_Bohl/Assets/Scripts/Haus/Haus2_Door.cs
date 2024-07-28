using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haus2_Door : MonoBehaviour
{
    // Reference to the teleport script
    private Teleport _teleport;
    
    // Start is called before the first frame update
    void Start()
    {
        _teleport = GetComponent<Teleport>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ProgressionManager.Instance.progress++;
        StartCoroutine(_teleport.LoadNextScene(0));
    }
}
