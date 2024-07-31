using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnEnter : MonoBehaviour
{
    // The audio that is supposed to be played
    public AudioClip audioClip;

    // The subtitles that are supposed to be displayed
    public string subtitles;

    // Reference to the kaspar commentary script
    private KasparCommentary _kasparCommentary;

    // Boolean too control if the audiosource has already played once
    private bool _hasPlayed;

    // Start is called before the first frame update
    void Start()
    {
        _kasparCommentary = Camera.main.GetComponent<KasparCommentary>();
        _hasPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Plays the audio file once, when the player enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !_hasPlayed)
        {
            _hasPlayed = true;
            StartCoroutine(_kasparCommentary.PlayAudioAndSetText(audioClip, subtitles));
        }
    }
}
