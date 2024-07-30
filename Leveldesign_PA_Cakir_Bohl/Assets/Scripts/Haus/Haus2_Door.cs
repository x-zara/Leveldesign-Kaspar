using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Haus2_Door : MonoBehaviour
{
    public AnimationClip animationClip;
    
    // Reference to the teleport script
    private Teleport _teleport;

    private Animator _overlayAnimator;

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

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Door());
    }

    private IEnumerator Door()
    {
        ProgressionManager.Instance.progress++;
        _firstPersonController.enabled = false;
        _overlayAnimator.enabled = true;
        yield return new WaitForSeconds(animationClip.length);
        yield return StartCoroutine(_teleport.LoadNextScene(0));
    }
}
