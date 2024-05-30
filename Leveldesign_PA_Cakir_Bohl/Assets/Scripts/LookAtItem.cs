using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LookAtItem : MonoBehaviour
{
    public TextMeshProUGUI itemDescription;

    public TextMeshProUGUI pressE;

    private bool inRange;
    
    // Start is called before the first frame update
    void Start()
    {
        itemDescription.gameObject.SetActive(false);
        pressE.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && inRange)
        {
            pressE.gameObject.SetActive(false);
            itemDescription.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        pressE.gameObject.SetActive(true);
        inRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inRange = false;
        itemDescription.gameObject.SetActive(false);
    }
}
