using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KerkerAudio : MonoBehaviour
{
    //Reference to the animation clip
    public AnimationClip animationClip;
    
    // The audio that is supposed to be played
    public AudioClip[] audioClips;

    // The subtitles that are supposed to be displayed
    public string[] subtitles;

    // Reference to the kaspar commentary script
    private KasparCommentary _kasparCommentary;

    // Reference to the animator
    private Animator _animator;

    // Reference to the painting animator
    private Animator _animatorPainting;

    // Reference to the first person controller script
    private FirstPersonController _firstPersonController;



    // Start is called before the first frame update
    void Start()
    {
        _kasparCommentary = Camera.main.GetComponent<KasparCommentary>();
        _firstPersonController = GameObject.Find("Player").GetComponent<FirstPersonController>();
        _animator = GameObject.Find("Blackscreen").GetComponent<Animator>();
        StartCoroutine(KerkerMonolog());
        _animatorPainting = GameObject.Find("Bild").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Coroutine that plays the audio files and animations in order
    private IEnumerator KerkerMonolog()
    {
        yield return new WaitForSeconds(5);
        yield return _kasparCommentary.PlayAudioAndSetText(audioClips[0], subtitles[0]);
        yield return new WaitForSeconds(5);
        _animator.SetTrigger("hasInteracted");
        yield return new WaitForSeconds(animationClip.length + 1);
        _animatorPainting.SetBool("hasStarted", true);
        yield return new WaitForSeconds(2f);
        yield return _kasparCommentary.PlayAudioAndSetText(audioClips[1], subtitles[1]);
        _animatorPainting.SetBool("hasStarted", false);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}
