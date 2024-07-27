using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    // The audio that is supposed to be played
    public AudioClip audioClip;

    // The subtitles that are supposed to be displayed
    public string subtitles;

    // Boolean to describe if the player has collected the key or not
    public bool _hasKey;

    // The text to be displayed if the door is locked
    public GameObject text;

    // Reference to the teleport script
    private Teleport _teleport;

    // Reference to the kaspar commentary script
    private KasparCommentary _kasparCommentary;

    // Boolean to describe if the player has already heard the voice line
    private bool _hasHeard;

    // Start is called before the first frame update
    void Start()
    {
        _hasKey = false;

        text.gameObject.SetActive(false);

        _teleport = GetComponent<Teleport>();

        _kasparCommentary = Camera.main.GetComponent<KasparCommentary>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Upon trying to open the door: if hasKey = true, loadNewScene; if false play audio only once, otherwise display text
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && _hasKey)
        {
            ProgressionManager.Instance.progress++;
            StartCoroutine(_teleport.LoadNextScene(1));
        }
        else
        {
            
            if (!_hasHeard)
            {
                StartCoroutine(_kasparCommentary.PlayAudioAndSetText(audioClip, subtitles));
                _hasHeard = true;
            }
            else
            {
                text.gameObject.SetActive(true);
            }
            
        }
    }


    private void OnTriggerExit(Collider other)
    {
        text.gameObject.SetActive(false);
    }
}
