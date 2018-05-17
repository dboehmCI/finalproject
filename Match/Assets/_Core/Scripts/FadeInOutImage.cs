using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOutImage : MonoBehaviour
{
    [SerializeField] private Image imageToUse;
    [SerializeField] private bool useThisImage = false;
    [Tooltip("false - Fades Out, true = Fades In")]
    [SerializeField]
    private bool fadeIn = false;
    [SerializeField] private bool fadeOnStart = false;
    [SerializeField] private float timeMultiplier;
    GameObject UncheckTitle;
    private void Start()
    {
        if (useThisImage)
        {
            imageToUse = GetComponent<Image>();
        }
        if (fadeOnStart)
        {
            if (fadeIn)
            {
                StartCoroutine(FadeInText(timeMultiplier, imageToUse));
                UncheckTitle = GameObject.FindGameObjectWithTag("LevelTitle");
                DestroyObject(UncheckTitle, 8.2f);

            }
            else
            {
                StartCoroutine(FadeOutText(timeMultiplier, imageToUse));
               UncheckTitle =  GameObject.FindGameObjectWithTag("LevelTitle");
                DestroyObject(UncheckTitle, 7.2f);
            }
        }
    }
    private IEnumerator FadeInText(float timeSpeed, Image text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime * timeSpeed));
            yield return null;
        }
    }
    private IEnumerator FadeOutText(float timeSpeed, Image text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime * timeSpeed));
            yield return null;
        }
    }
    public void FadeInText(float timeSpeed = -1.0f)
    {
        if (timeSpeed <= 0.0f)
        {
            timeSpeed = timeMultiplier;
        }
        StartCoroutine(FadeInText(timeSpeed, imageToUse));
    }
    public void FadeOutText(float timeSpeed = -1.0f)
    {
        if (timeSpeed <= 0.0f)
        {
            timeSpeed = timeMultiplier;
        }
        StartCoroutine(FadeOutText(timeSpeed, imageToUse));
    }
}