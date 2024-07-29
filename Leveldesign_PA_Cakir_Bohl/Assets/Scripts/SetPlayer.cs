using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayer : MonoBehaviour
{
    // The audio that is supposed to be played
    public AudioClip[] audioClips;

    // The subtitles that are supposed to be displayed
    public string[] subtitles;

    private GameObject _player;

    private FirstPersonController _firstPersonController;

    private Transform _teleportTransform;

    // Reference to the kaspar commentary script
    private KasparCommentary _kasparCommentary;

    private void Start()
    {
        if (ProgressionManager.Instance.progress > 2)
        {
            print("shshshs");
            _player = GameObject.Find("Player");
            _firstPersonController = _player.GetComponent<FirstPersonController>();
            _teleportTransform = GameObject.Find("Teleport_Transform").GetComponent<Transform>();
            _firstPersonController.gameObject.SetActive(false);
            _player.transform.SetPositionAndRotation(_teleportTransform.position, _teleportTransform.rotation);
            _firstPersonController.gameObject.SetActive(true);
            _kasparCommentary = Camera.main.GetComponent<KasparCommentary>();
            StartCoroutine(DorfKommentar());
        }
    }

    private IEnumerator DorfKommentar()
    {
        yield return new WaitForSeconds(3);
        yield return _kasparCommentary.PlayAudioAndSetText(audioClips[0], subtitles[0]);
        yield return new WaitForSeconds(3);
        yield return _kasparCommentary.PlayAudioAndSetText(audioClips[1], subtitles[1]);
        yield return new WaitForSeconds(1);
        yield return _kasparCommentary.PlayAudioAndSetText(audioClips[2], subtitles[2]);
    }
}
