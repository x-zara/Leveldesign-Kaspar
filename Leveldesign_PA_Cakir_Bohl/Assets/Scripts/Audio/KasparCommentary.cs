using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KasparCommentary : MonoBehaviour
{
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public string subtitles1;
    public string subtitles2;
    private TMP_Text _text;
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _text = GameObject.Find("Subtitles").GetComponent<TMP_Text>();
        _audioSource = GetComponent<AudioSource>();
        if(ProgressionManager.Instance.progress == 0)
        {
            StartCoroutine(IntroMonologue());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PlayAudioAndSetText(AudioClip audioClip, string subtitles)
    {
        _text.gameObject.SetActive(true);
        _audioSource.PlayOneShot(audioClip, 1.5f);
        _text.text = subtitles;
        yield return new WaitForSeconds(audioClip.length);
        _text.gameObject.SetActive(false);
    }

    private IEnumerator IntroMonologue()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(PlayAudioAndSetText(audioClip1, subtitles1));
        yield return new WaitForSeconds(audioClip1.length + 1);
        StartCoroutine(PlayAudioAndSetText(audioClip2, subtitles2));
    }
}
