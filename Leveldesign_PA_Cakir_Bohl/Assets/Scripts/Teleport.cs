using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform newTransform;

    private Transform _playerTransform;

    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Player"))
        {
            print(_playerTransform.position);
            other.GetComponent<FirstPersonController>().gameObject.SetActive(false);
            Vector3 targetPosition = newTransform.position;
            Quaternion targetRotation = newTransform.rotation;
            other.transform.position = targetPosition;
            other.transform.rotation = targetRotation;
            other.GetComponent<FirstPersonController>().gameObject.SetActive(true);
            print(_playerTransform.position);
        }
    }
}
