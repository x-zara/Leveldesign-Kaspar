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

    // Reference to the first person controller script
    private FirstPersonController _firstPersonController;



    // Start is called before the first frame update
    void Start()
    {
        _kasparCommentary = Camera.main.GetComponent<KasparCommentary>();
        _firstPersonController = GameObject.Find("Player").GetComponent<FirstPersonController>();
        _animator = GameObject.Find("Blackscreen").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(KerkerMonolog());
    }

    private IEnumerator KerkerMonolog()
    {
        yield return new WaitForSeconds(5);
        yield return _kasparCommentary.PlayAudioAndSetText(audioClips[0], subtitles[0]);
        yield return _kasparCommentary.PlayAudioAndSetText(audioClips[1], subtitles[1]);
        _animator.SetTrigger("hasInteracted");
        yield return new WaitForSeconds(animationClip.length);
        SceneManager.LoadScene(4);
    }
}
