using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    //public GameObject text;

    public AnimationClip animationClip;

    public AnimationClip fragmentAnimation;

    public Image fragment1;

    private Image _fragment;
    
    private Transform _playerTransform;

    private GameObject _player;

    private Animator _animator;

    private FirstPersonController _firstPersonController;

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

    // A coroutine to get the lentgth of the animation clip and after it has played disable the image
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
