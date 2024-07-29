using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Haus1_Cutscene : MonoBehaviour
{
    // Array of all audioclips to be used in the cutscene
    public AudioClip[] audioClips;

    // Array of all subtitles to be used in the cutscene
    public string[] subtitles;

    // The 'press E' text
    public TextMeshProUGUI pressE;

    // The falling rifle animation
    public AnimationClip _fallingRifle;

    // Reference to the animator of the rifle
    private Animator _rifleAnimator;

    // Reference to the kaspar commentary script
    private KasparCommentary _kasparCommentary;

    // Reference to the bett script
    private Bett _bett;

    // Boolean to check if the cutscene has started playing
    private bool _isPlaying;

    // The audio source from the next room
    private AudioSource _nextRoom;

    // The subtitles
    private TMP_Text _text;

    private Animator _overlayAnimator;

    // Start is called before the first frame update
    void Start()
    {
        _rifleAnimator = GameObject.Find("VintageRifle").GetComponent<Animator>();
        pressE.gameObject.SetActive(false);
        _kasparCommentary = Camera.main.GetComponent<KasparCommentary>();
        _bett = GameObject.Find("Bett_Trigger").GetComponent<Bett>();
        _isPlaying = false;
        _nextRoom = GameObject.Find("Nebenan").GetComponent<AudioSource>();
        _text = GameObject.Find("Subtitles").GetComponent<TMP_Text>();
        _overlayAnimator = GameObject.Find("Overlay").GetComponent<Animator>();
        _overlayAnimator.enabled = false;
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && pressE.gameObject.activeSelf && !_isPlaying)
            {
                StartCoroutine(Cutscene());
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            pressE.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pressE.gameObject.SetActive(false);
    }
    IEnumerator Cutscene()
    {
        _isPlaying = true;
        pressE.gameObject.SetActive(false);
        _rifleAnimator.SetTrigger("hasInteracted");
        gameObject.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(_fallingRifle.length - 0.2f);
        _nextRoom.Stop();
        yield return _kasparCommentary.PlayAudioAndSetText(audioClips[0], subtitles[0]);
        yield return _kasparCommentary.PlayAudioAndSetText(audioClips[1], subtitles[1]);
        yield return OtherRoomAudio(audioClips[2], subtitles[2]);
        yield return OtherRoomAudio(audioClips[3], subtitles[3]);
        yield return new WaitForSeconds(2);
        _overlayAnimator.enabled = true;
        yield return new WaitForSeconds(3);
        yield return _kasparCommentary.PlayAudioAndSetText(audioClips[4], subtitles[4]);


        _bett._hasPlayed = true;
    }

    private IEnumerator OtherRoomAudio(AudioClip audioClip, string subtitles)
    {
        _text.gameObject.SetActive(true);
        _nextRoom.PlayOneShot(audioClip, 1.5f);
        _text.text = subtitles;
        yield return new WaitForSeconds(audioClip.length);
        _text.gameObject.SetActive(false);
    }

}
