using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnEnter : MonoBehaviour
{
    public AudioClip audioClip;

    public string subtitles;

    private KasparCommentary _kasparCommentary;

    // Start is called before the first frame update
    void Start()
    {
        _kasparCommentary = Camera.main.GetComponent<KasparCommentary>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(_kasparCommentary.PlayAudioAndSetText(audioClip, subtitles));
        }
        
    }
}
