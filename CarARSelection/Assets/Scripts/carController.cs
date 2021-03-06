using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour {

	Animator anim;
	AudioSource audio;
	public static carController instance;

	public static int selectedIndex = 0;
	//selectedindex = i;

	//Create a cloned object so we can access the functions
	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

	// Use this for initialization
	void Start()
	{

		//Loop through the child items activating the correct item by name
		for (int i = 0; i < transform.childCount; ++i)
		{

			//Check the current selected item and activate
			if (transform.GetChild(i).gameObject.name == GameController.currentSelectedCar)
			{
				selectedIndex = i;
				transform.GetChild(i).gameObject.SetActive(true);
				//Get the animator componant from the active item
				anim = transform.GetChild(i).gameObject.GetComponent<Animator>();
			}
			else
			{
				//Deactivate all other cars
				transform.GetChild(i).gameObject.SetActive(false);
			}
		}


	}

	//Called from _Handle
	public void triggerAnimation(string action)
	{
		anim = GameObject.Find("/UserDefinedTarget-1/ActiveItems/" + GameController.currentSelectedCar).GetComponent<Animator>();
		anim.SetTrigger(action);
	}

	//Called from _Handle
	public void showMessage()
	{
		//TODO
	}

	public void PlaySound()
	{
		audio = GameObject.Find("/UserDefinedTarget-1/ActiveItems/" + GameController.currentSelectedCar).GetComponent<AudioSource>();
		audio.Play();
	}

	public void StopSound()
	{
		audio = GameObject.Find("/UserDefinedTarget-1/ActiveItems/" + GameController.currentSelectedCar).GetComponent<AudioSource>();
		audio.Stop();
	}

	public void KillSound()//dynamicall change the volume on things
    {
		GameObject.Find(ColourSwitcher.instance.getCurrentTracked().name + "/ActiveItems/" + GameController.currentSelectedCar + "/video").GetComponent<AudioSource>().volume = 0f;//this goes on the video
		GameObject.Find(ColourSwitcher.instance.getCurrentTracked().name + "/ActiveItems/" + GameController.currentSelectedCar).GetComponent<AudioSource>().volume = 0f;//this goes on the car itself 
	}

	public void ResetSound()
    {
		GameObject.Find(ColourSwitcher.instance.getCurrentTracked().name + "/ActiveItems/" + GameController.currentSelectedCar + "/video").GetComponent<AudioSource>().volume = 100f;
		GameObject.Find(ColourSwitcher.instance.getCurrentTracked().name + "/ActiveItems/" + GameController.currentSelectedCar).GetComponent<AudioSource>().volume = 100f;
	}
}
