using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Darkening : MonoBehaviour
{
    private CanvasGroup _blackscreen;

    private float _darkeningRate;

    private void Start()
    {
        _blackscreen = GameObject.Find("Blackscreen_Kerker").GetComponent<CanvasGroup>();
    }
    // Start is called before the first frame update

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _blackscreen.alpha = Mathf.Lerp(0, 1, _darkeningRate);

            _darkeningRate += 0.15f * Time.deltaTime;


            if(_blackscreen.alpha >= 1)
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}
