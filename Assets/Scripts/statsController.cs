using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;


public class statsController : MonoBehaviour
{
   [SerializeField] private TMP_Text statTxt;
   [SerializeField] private float lerpSpeed;
   private Image health,mana;
   private float currentFill=1;
   public float  MaxValue { get; set; }
   private float CurrentValue;

   public float MyCurrentValue
  {
      get
      {
         return CurrentValue;
      }
      set
      {
         if (value > MaxValue)
         {
          CurrentValue = MaxValue;
         }
         else if (value < 0)
         {
            CurrentValue = 0;
         }
         else
         {
            CurrentValue = value;
         }

         currentFill = CurrentValue / MaxValue;
         statTxt.text = CurrentValue + " / " + MaxValue;
      }
  }
  

   private void Start()
   {
     
      health=GameObject.FindWithTag("health").GetComponent<Image>();
      mana = GameObject.FindWithTag("mana").GetComponent<Image>();

   }

   private void Update()
   {
      if (currentFill != health.fillAmount)
      {
         health.fillAmount = Mathf.Lerp(health.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
      }
    

      if (currentFill != mana.fillAmount)
     {
          mana.fillAmount = Mathf.Lerp(mana.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
      }


   }

   public void initialize1(float currentValue1, float maxValue1)
   {
      CurrentValue = currentValue1;
      MaxValue = maxValue1;
   }
}
