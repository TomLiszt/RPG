using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthBar : MonoBehaviour
{
    private Entity entity;
    private CharacterStats myStats;
    private RectTransform myTransform;
    private Slider slider;


    private void Start()
    {
        myTransform = GetComponent<RectTransform>();
        entity = GetComponentInParent<Entity>();
        slider = GetComponentInChildren<Slider>();
        myStats = GetComponentInParent<CharacterStats>();

        entity.OnFlipped += FlipUI;
        myStats.onHealthChanged += UpdateHealthUI;
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        slider.maxValue = myStats.GetMaxhealthValue();
        slider.value = myStats.currentHealth;
    }

    private void FlipUI()
    {
        myTransform.Rotate(0, 180, 0);
    }

    private void OnDisable()
    {
        entity.OnFlipped -= FlipUI;     
        myStats.onHealthChanged -= UpdateHealthUI;
    }
}
