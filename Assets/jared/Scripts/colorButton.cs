// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorButton : MonoBehaviour {

	public Image[] buttonColorsArr = new Image [3];
	// public Image red;
	// public Image green;
	public Image dark;
	public Image activeOutline;

	public bool is_active;
	public buttonColor what_color;


	

	public enum buttonColor{ red, blue, green}

	

	public void changeActiveState(bool state)
	{
			activeOutline.enabled = state;
			dark.enabled = !state;
	}


	public void changeColor(buttonColor newColor)
	{
		foreach (var item in buttonColorsArr)
		{
			item.enabled = false;
			
			if(item.name == newColor.ToString())
			{
				item.enabled = true;
			}
		}
	}


	// Use this for initialization
	void Start () {
		changeColor(what_color);
		changeActiveState(is_active);

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.RightArrow))
		{
			changeActiveState(!activeOutline.enabled);
		}
	}



}
