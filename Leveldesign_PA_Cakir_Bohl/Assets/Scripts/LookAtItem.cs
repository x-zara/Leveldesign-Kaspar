using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;

public class LookAtItem : MonoBehaviour
{
    public AnimationClip animationClip;
    
    // The corresponding RawImage
    public RawImage itemImage;

    // The 'press E' text
    public TextMeshProUGUI pressE;

    // A boolean that determines if the player is close enough to the object to press E
    private bool inRange;

    // Reference to the animator of the image
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        // Disable all text objects
        _animator = itemImage.GetComponent<Animator>();
        itemImage.gameObject.SetActive(false);
        pressE.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // If the E key is pressed and the character is in range: disable the 'press E' text and enablle the corresponding item description
        if (Input.GetKeyDown(KeyCode.E) && inRange && !itemImage.gameObject.activeSelf)
        {
            pressE.gameObject.SetActive(false);
            itemImage.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.E) && inRange && itemImage.gameObject.activeSelf)
        {
            StartCoroutine(WaitForAnimation());
            itemImage.gameObject.SetActive(true);
            pressE.gameObject.SetActive(true);
        }


    }

    // On Trigger Enter: enable the 'press E' text and set inRange to true
    private void OnTriggerEnter(Collider other)
    {
        pressE.gameObject.SetActive(true);
        inRange = true;
    }

    // On Trigger Exit: set inRange to false, disable both text objects
    private void OnTriggerExit(Collider other)
    {
        inRange = false;
        pressE.gameObject.SetActive(false);
        // Start the coroutine to hide the image and then disable it after
        StartCoroutine(WaitForAnimation());
    }

    // A coroutine to get the lentgth of the animation clip and after it has played disable the image
    IEnumerator WaitForAnimation()
    {
        _animator.SetTrigger("Hide");
        // https://docs.unity3d.com/ScriptReference/WaitForSeconds.html
        yield return new WaitForSeconds(animationClip.length);
        itemImage.gameObject.SetActive(false);
    }
}
