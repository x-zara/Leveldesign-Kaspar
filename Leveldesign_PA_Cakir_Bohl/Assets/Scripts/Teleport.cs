using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
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


    

    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        _player = GameObject.Find("Player");
        _firstPersonController = _player.GetComponent<FirstPersonController>();
        _animator = GameObject.Find("Blackscreen").GetComponent<Animator>();
        _fragment = GameObject.Find("Bildfragment").GetComponent<Image>();
    }

    // A coroutine to start a fade to black, show a fragment and then load the next scene
    public IEnumerator LoadNextScene(int sceneIndex)
    {
        _firstPersonController.gameObject.SetActive(false);
        _animator.SetTrigger("hasInteracted");
        // https://docs.unity3d.com/ScriptReference/WaitForSeconds.html
        yield return new WaitForSeconds(1.5f);
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
