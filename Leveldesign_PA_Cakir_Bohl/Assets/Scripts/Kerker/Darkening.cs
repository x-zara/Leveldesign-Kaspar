using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Darkening : MonoBehaviour
{
    // Reference to the fogwall behind the player
    public GameObject fogWall;

    // Reference to the audio clip
    public AudioClip audioClip;
    
    // Reference to canvas group component of the blackscreen
    private CanvasGroup _blackscreen;

    // The rate at which the screen darkens
    private float _darkeningRate;

    // Boolean to describe if the player has entered the collider
    private bool _hasEntered = false;

    // Reference to the teleport script
    private Teleport _teleport;

    // Reference to the first person controller script
    private FirstPersonController _firstPersonController;

    // Reference to the audio source
    private AudioSource _audioSource;

    // Boolean to check if the darkening is happening
    private bool _isPlaying = false;

    // Start is called before the first frame update
    private void Start()
    {
        _blackscreen = GameObject.Find("Blackscreen_Kerker").GetComponent<CanvasGroup>();
        _teleport = GameObject.Find("Teleport_Trigger").GetComponent<Teleport>();
        _firstPersonController = GameObject.Find("Player").GetComponent<FirstPersonController>();
        _audioSource = Camera.main.GetComponent<AudioSource>();
        fogWall.SetActive(false);
    }

    private void Update()
    {
        // Upon entering, start lerping the blackscreens alpha until it's fully dark, play the auio file and then when it's fully dark load the next scene
        if(_hasEntered)
        {
            
            _blackscreen.alpha = Mathf.Lerp(0, 1, _darkeningRate);

            _darkeningRate += 0.15f * Time.deltaTime;

            if(!_isPlaying)
            {
                _audioSource.PlayOneShot(audioClip, 1f);
                _isPlaying = true;
            }

            if (_blackscreen.alpha >= 1)
            {
            StartCoroutine(_teleport.LoadNextScene(3));
            }
        }
        
    }
    // Upon entering the collider, set the boolean to true so the lerp can start
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _hasEntered = true;
            fogWall.SetActive(true);
        }
        
    }
}
