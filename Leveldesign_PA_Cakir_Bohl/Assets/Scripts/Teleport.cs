using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    // A possible door sound, if the new scene is entered through a door
    public AudioClip audioClip;
    
    // Reference to the animation clip
    public AnimationClip animationClip;

    // Reference to the fragment animation clip
    public AnimationClip fragmentAnimation;

    // Reference to the first fragment
    public Image fragment1;

    // Reference to the first fragment
    private Image _fragment;
    
    // Player's transform
    private Transform _playerTransform;

    // Reference to the player object
    private GameObject _player;

    // Reference to the animator of the blackscreen
    private Animator _animator;

    // Reference to the first person controller
    private FirstPersonController _firstPersonController;

    // Reference to the animator of the painting fragments
    private Animator _fragmentAnimator;

    // The main camera's audio source
    private AudioSource _audioSource;


    

    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        _player = GameObject.Find("Player");
        _firstPersonController = _player.GetComponent<FirstPersonController>();
        _animator = GameObject.Find("Blackscreen").GetComponent<Animator>();
        _fragment = GameObject.Find("Bildfragment").GetComponent<Image>();
        _audioSource = Camera.main.GetComponent<AudioSource>();
    }

    // A coroutine to start a fade to black, show a fragment and then load the next scene
    public IEnumerator LoadNextScene(int sceneIndex)
    {
        _firstPersonController.gameObject.SetActive(false);
        _animator.SetTrigger("hasInteracted");
        // https://docs.unity3d.com/ScriptReference/WaitForSeconds.html
        yield return new WaitForSeconds(1.5f);
        if(audioClip != null)
        {
            _audioSource.PlayOneShot(audioClip, 0.3f);
        }
        if(ProgressionManager.Instance.progress == 0)
        {
            _fragmentAnimator = fragment1.GetComponent<Animator>();
            _fragmentAnimator.SetBool("showFragment", true);
        }
        else if(ProgressionManager.Instance.progress > 0)
        {
            _fragmentAnimator = _fragment.GetComponent<Animator>();
            _fragmentAnimator.SetBool("showFragment", true);
        }
        yield return new WaitForSeconds(fragmentAnimation.length + 1f);
        ProgressionManager.Instance.progress++;
        SceneManager.LoadScene(sceneIndex);
    }
}
