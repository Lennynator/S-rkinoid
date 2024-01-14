using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlinkingText : MonoBehaviour
{
    private Coroutine blinkCoroutine;

    public TextMeshProUGUI haukivaroitin; 

    void Start()
    {
        if (haukivaroitin == null)
        {
            Debug.LogError("TextMeshProUGUI component not assigned in the inspector!");
            return;
        }
        haukivaroitin.enabled = false;

    }

    IEnumerator Blink()
    {
        while (true)
        {
            haukivaroitin.text = "TAPPAJAHAUKI";
            yield return new WaitForSeconds(1f);
            haukivaroitin.text = "";
            yield return new WaitForSeconds(1f);
        }
    }

    public void StartBlinking()
    {
        haukivaroitin.enabled = true;
        StartCoroutine("Blink");
        if (blinkCoroutine == null)
        {
            blinkCoroutine = StartCoroutine(Blink());
        }
    }

    public void StopBlinking()
    {
        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
            blinkCoroutine = null; 
        }
        haukivaroitin.enabled = false;
    }

   
}


