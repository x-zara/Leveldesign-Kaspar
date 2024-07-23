using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public GameObject text;
    
    public Transform newTransform;

    public bool _hasKey;

    public AnimationClip animationClip;

    public int sceneIndex;
    
    private Transform _playerTransform;

    private GameObject _player;

    private Animator _animator;

    

    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        _player = GameObject.Find("Player");
        text.gameObject.SetActive(false);
        _animator = GameObject.Find("Blackscreen").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Player") && _hasKey)
        {
            print(_playerTransform.position);
            other.GetComponent<FirstPersonController>().gameObject.SetActive(false);
            StartCoroutine(FadeToBlack());
            /*
            Vector3 targetPosition = newTransform.position;
            Quaternion targetRotation = newTransform.rotation;
            other.transform.position = targetPosition;
            other.transform.rotation = targetRotation;
            other.GetComponent<FirstPersonController>().gameObject.SetActive(true);
            print(_playerTransform.position);
            */
        }
        else
        {
            text.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        text.gameObject.SetActive(false);
    }

    // A coroutine to get the lentgth of the animation clip and after it has played disable the image
    IEnumerator FadeToBlack()
    {
        _animator.SetTrigger("hasInteracted");
        // https://docs.unity3d.com/ScriptReference/WaitForSeconds.html
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneIndex);
        //_animator.gameObject.SetActive(false);
    }
}
