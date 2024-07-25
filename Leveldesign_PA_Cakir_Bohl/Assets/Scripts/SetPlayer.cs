using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class SetPlayer : MonoBehaviour
{

    private GameObject _player;

    private FirstPersonController _firstPersonController;

    private Transform _teleportTransform;

    private void Start()
    {
        if (ProgressionManager.Instance.progress > 1)
        {
            print("shshshs");
            _player = GameObject.Find("Player");
            _firstPersonController = _player.GetComponent<FirstPersonController>();
            _teleportTransform = GameObject.Find("Teleport_Transform").GetComponent<Transform>();
            _firstPersonController.gameObject.SetActive(false);
            _player.transform.SetPositionAndRotation(_teleportTransform.position, _teleportTransform.rotation);
            _firstPersonController.gameObject.SetActive(true);

        }
    }
}
