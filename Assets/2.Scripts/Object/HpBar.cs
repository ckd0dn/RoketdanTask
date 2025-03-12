using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Slider mainSlider;
    [SerializeField] private Slider delaySlider;
    
    private void Start()
    {
        var worldCanvas = GameObject.Find("WorldCanvas");
        if (worldCanvas != null)
            transform.parent.SetParent(worldCanvas.transform, false);
    }

    private void OnEnable()
    {
        mainSlider.value = 1;
        delaySlider.value = 1;
    }

    public void UpdateHpBar(int MaxHp, int Hp)
    {
        if (MaxHp == 0) return;
        
        float value = (float)Hp / MaxHp;
        mainSlider.value = value;
        StartCoroutine(UpdateDelaySliderSmoothly(value));

    }
    
    private IEnumerator UpdateDelaySliderSmoothly(float targetDelayValue)
    {
        float lerpSpeed = 2f;
        
        while (Mathf.Abs(delaySlider.value - targetDelayValue) > 0.01f)
        {
            delaySlider.value = Mathf.Lerp(delaySlider.value, targetDelayValue, lerpSpeed * Time.deltaTime);
            yield return null;
        }

        delaySlider.value = targetDelayValue;
    }

    public void UpdatePosition(Transform target)
    {
        transform.position = target.position + new Vector3(-0.2f, 1.2f, 0); 
    }
}