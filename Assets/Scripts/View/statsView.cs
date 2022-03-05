using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;


public class statsView: MonoBehaviour
{
   [SerializeField] private TMP_Text statTxt;
   [SerializeField] private float lerpSpeed;
   private Image playerHealth,enemy1Health,enemy2Health,mana;
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
         if (statTxt != null)
         {
            statTxt.text = CurrentValue + " / " + MaxValue;
         }
         
      }
  }
  

   private void start()
   {
      enemy1Health=GameObject.FindWithTag("eHealth").GetComponent<Image>();
       // mana = GameObject.FindWithTag("mana").GetComponent<Image>();

   }

    private void Update()
    {

        if (currentFill != playerHealth.fillAmount && playerHealth != null)
        {
            playerHealth.fillAmount = Mathf.Lerp(playerHealth.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }
    }
   public void Initialize(float currentValue1, float maxValue1)
   {
     
      CurrentValue = currentValue1;
      MaxValue = maxValue1;
   }
}
