using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KasparCommentary : MonoBehaviour
{
    // Reference to the first audio clip
    public AudioClip audioClip1;

    // Reference to the second audio clip
    public AudioClip audioClip2;

    // Reference to the first subtitle
    public string subtitles1;

    // Reference to the second subtitle
    public string subtitles2;

    // Reference to the subtitles game object's text
    private TMP_Text _text;

    // Reference to the audio source
    private AudioSource _audioSource;


    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _text = GameObject.Find("Subtitles").GetComponent<TMP_Text>();
        if(ProgressionManager.Instance.progress == 0)
        {
            StartCoroutine(IntroMonologue());
            _text.gameObject.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // A coroutine that plays the voiceline and shows the corresponding subtitle
    public IEnumerator PlayAudioAndSetText(AudioClip audioClip, string subtitles)
    {
        _text.gameObject.SetActive(true);
        _audioSource.PlayOneShot(audioClip, 1.5f);
        _text.text = subtitles;
        yield return new WaitForSeconds(audioClip.length);
        _text.gameObject.SetActive(false);
    }

    // The monologue being triggered at the start of the game
    private IEnumerator IntroMonologue()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(PlayAudioAndSetText(audioClip1, subtitles1));
        yield return new WaitForSeconds(audioClip1.length + 2);
        StartCoroutine(PlayAudioAndSetText(audioClip2, subtitles2));
    }
}
