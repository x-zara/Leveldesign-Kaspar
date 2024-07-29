using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Marktplatz : MonoBehaviour
{
    // Array of all audiosources
    public AudioSource[] audioSourcesMale;

    // Array of all audiosources
    public AudioSource[] audioSourcesFemale;

    // Array of all audioclips to be used in the cutscene
    public AudioClip[] audioClipsMale;

    // Array of all audioclips to be used in the cutscene
    public AudioClip[] audioClipsFemale;

    // Array of all subtitles to be used in the cutscene
    public string[] subtitlesMale;

    // Array of all subtitles to be used in the cutscene
    public string[] subtitlesFemale;

    // The subtitles
    public TMP_Text _text;

    // Boolean to check is the couroutine is already running
    private bool _isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!_isPlaying)
        {
            StartCoroutine(MarktPlatzMurmeln());
            _isPlaying = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(MarktPlatzMurmeln());
        _text.gameObject.SetActive(false);
    }

    private IEnumerator MarktPlatzMurmeln()
    {
        yield return OutsideAudio(audioSourcesMale[0], audioClipsMale[0], subtitlesMale[0]);
        yield return OutsideAudio(audioSourcesFemale[0], audioClipsFemale[0], subtitlesFemale[0]);
        yield return OutsideAudio(audioSourcesMale[1], audioClipsMale[1], subtitlesMale[1]);
        yield return OutsideAudio(audioSourcesFemale[1], audioClipsFemale[1], subtitlesFemale[1]);
        yield return OutsideAudio(audioSourcesMale[0], audioClipsMale[2], subtitlesMale[2]);
        yield return OutsideAudio(audioSourcesFemale[0], audioClipsFemale[2], subtitlesFemale[2]);
        yield return OutsideAudio(audioSourcesMale[1], audioClipsMale[3], subtitlesMale[3]);
        yield return OutsideAudio(audioSourcesFemale[1], audioClipsFemale[3], subtitlesFemale[3]);
        yield return OutsideAudio(audioSourcesMale[0], audioClipsMale[4], subtitlesMale[4]);
    }

    private IEnumerator OutsideAudio(AudioSource audioSource, AudioClip audioClip, string subtitles)
    {
        _text.gameObject.SetActive(true);
        audioSource.PlayOneShot(audioClip, 1f);
        _text.text = subtitles;
        yield return new WaitForSeconds(audioClip.length + 1);
        _text.gameObject.SetActive(false);
    }
}
