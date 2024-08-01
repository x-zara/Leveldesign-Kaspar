using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LookAtItem : MonoBehaviour
{
    // The audio that is supposed to be played
    public AudioClip audioClip;

    // The subtitles that are supposed to be displayed
    public string subtitles;

    // Reference to the animation clip
    public AnimationClip animationClip;
    
    // The corresponding RawImage
    public RawImage itemImage;

    // The 'press E' text
    public TextMeshProUGUI pressE;

    // A boolean that determines if the player is close enough to the object to press E
    private bool inRange;

    // Reference to the animator of the image
    private Animator _animator;

    // Reference to the kaspar commentary script
    private KasparCommentary _kasparCommentary;

    // Start is called before the first frame update
    void Start()
    {
        // Disable all text objects
        _animator = itemImage.GetComponent<Animator>();
        itemImage.gameObject.SetActive(false);
        pressE.gameObject.SetActive(false);
        _kasparCommentary = Camera.main.GetComponent<KasparCommentary>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the E key is pressed and the character is in range: disable the 'press E' text and enablle the corresponding item description
        if (Input.GetKeyDown(KeyCode.E) && inRange && !itemImage.gameObject.activeSelf)
        {
            pressE.gameObject.SetActive(false);
            itemImage.gameObject.SetActive(true);
            StartCoroutine(_kasparCommentary.PlayAudioAndSetText(audioClip, subtitles));
        }
        // If E key is pressed again: make the image disappear
        else if (Input.GetKeyDown(KeyCode.E) && inRange && itemImage.gameObject.activeSelf)
        {
            StartCoroutine(WaitForAnimation());
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
