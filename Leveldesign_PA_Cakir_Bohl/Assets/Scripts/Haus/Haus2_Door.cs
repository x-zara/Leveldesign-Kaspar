using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Haus2_Door : MonoBehaviour
{
    // Reference to the animation clip
    public AnimationClip animationClip;
    
    // Reference to the teleport script
    private Teleport _teleport;

    // Reference to the overlay animator
    private Animator _overlayAnimator;

    // Reference to the first person controller script
    private FirstPersonController _firstPersonController;

    // Start is called before the first frame update
    void Start()
    {
        _teleport = GetComponent<Teleport>();
        _overlayAnimator = GameObject.Find("Overlay").GetComponent<Animator>();
        _overlayAnimator.enabled = false;
        _firstPersonController = GameObject.Find("Player").GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Start the coroutine when the player enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Door());
    }

    // A coroutine that freezes the players position, disables the overlay and loads the next scene
    private IEnumerator Door()
    {
        ProgressionManager.Instance.progress++;
        _firstPersonController.enabled = false;
        _overlayAnimator.enabled = true;
        yield return new WaitForSeconds(animationClip.length);
        yield return StartCoroutine(_teleport.LoadNextScene(0));
    }
}
