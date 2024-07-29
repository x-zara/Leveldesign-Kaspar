using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Darkening : MonoBehaviour
{
    private CanvasGroup _blackscreen;

    private float _darkeningRate;

    // Boolean to describe if the player has entered the collider
    private bool _hasEntered = false;

    // Reference to the teleport script
    private Teleport _teleport;
    
    // Start is called before the first frame update
    private void Start()
    {
        _blackscreen = GameObject.Find("Blackscreen_Kerker").GetComponent<CanvasGroup>();
        _teleport = GameObject.Find("Teleport_Trigger").GetComponent<Teleport>();
    }

    private void Update()
    {
        
        if(_hasEntered)
        {
            _blackscreen.alpha = Mathf.Lerp(0, 1, _darkeningRate);

            _darkeningRate += 0.15f * Time.deltaTime;

            if (_blackscreen.alpha >= 1)
            {
            StartCoroutine(_teleport.LoadNextScene(3));
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _hasEntered = true;
        }
        
    }
}
