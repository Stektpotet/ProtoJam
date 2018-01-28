using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour {


	public RectTransform mask;

	private float numberAtFull = 84f;
	private float numberAtEmpty = 15f;

	public float precentagePower = 0.0f;
	
	// Use this for initialization
	void Start () {
		
		updatePowerBar();
		// Debug.Log(tmp);
		// Debug.Log(mask.Axis);
		// Debug.Log(RectTransform.Axis.Horizontal.ToString());

		// mask.sizeDelta = new Vector2(0f, 0f);
		// mask.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, tmp);
		// Debug.Log()
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.UpArrow))
		{
			precentagePower += 0.01f;
			Debug.Log("HAPPNING?");
			updatePowerBar();
		}
	}


	private void updatePowerBar()
	{
		float tmp = ((numberAtFull - numberAtEmpty) * precentagePower) + numberAtEmpty;
		mask.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, tmp);
	}
}
