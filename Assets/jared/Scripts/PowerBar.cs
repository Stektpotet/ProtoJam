using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{


   public RectTransform mask;

   private float numberAtFull = 84f;
   private float numberAtEmpty = 15f;

   public float precentagePower = 0.0f;


   void Start()
   {
      updatePowerBar();
   }


   private void updatePowerBar()
   {
      float tmpFloat = ((numberAtFull - numberAtEmpty) * precentagePower) + numberAtEmpty;
      mask.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, tmpFloat);
   }


   void Update()
   {
      //FOR DEBUG TEST WITH KEY
      if (Input.GetKey(KeyCode.Space))
      {
         setPresentagePower(getPresentagePower() + 0.01f);
      }

      if (Input.GetKeyUp(KeyCode.Space))
      {
         setPresentagePower(0.0f);
      }
   }


   public float getPresentagePower()
   {
      return precentagePower;
   }

   public void setPresentagePower(float value)
   {

      precentagePower = value;
      updatePowerBar();
   }
}
