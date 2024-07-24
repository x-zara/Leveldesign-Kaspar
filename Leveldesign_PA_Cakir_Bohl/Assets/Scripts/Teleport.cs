using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    //public GameObject text;

    public AnimationClip animationClip;
    
    private Transform _playerTransform;

    private GameObject _player;

    private Animator _animator;

    private FirstPersonController _firstPersonController;

    

    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        _player = GameObject.Find("Player");
        _firstPersonController = _player.GetComponent<FirstPersonController>();
        //text.gameObject.SetActive(false);
        _animator = GameObject.Find("Blackscreen").GetComponent<Animator>();
    }

    // A coroutine to get the lentgth of the animation clip and after it has played disable the image
    public IEnumerator LoadNextScene(int sceneIndex)
    {
        _firstPersonController.gameObject.SetActive(false);
        _animator.SetTrigger("hasInteracted");
        // https://docs.unity3d.com/ScriptReference/WaitForSeconds.html
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneIndex);
        //_animator.gameObject.SetActive(false)
    }
}
