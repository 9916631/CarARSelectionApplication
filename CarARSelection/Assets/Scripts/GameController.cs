using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static string currentSelectedCar = "myLamboConvert";
	private bool onOff = false;

	// Update is called once per frame
	//void Update () 
	//{
	//	print(currentSelectedCar);
	//}
	public void showNewCar(string nextCar)//pass in name of car then find current car then diable the current car we looking at. we over ride the selected car up the top
	{
		GameObject.Find(ColourSwitcher.instance.getCurrentTracked().name + "/ActiveItems/" + GameController.currentSelectedCar).SetActive(false);
		currentSelectedCar = nextCar;
		GameObject.Find(ColourSwitcher.instance.getCurrentTracked().name + "/ActiveItems/" + GameController.currentSelectedCar).SetActive(true);
	}

	//public void ToggleFlash()
 //   {
	//	CameraSettings.instance.
 //   }

	public void Quit()
	{
		Application.Quit();
	}

	public void ChangeLevel(string scene)
	{
		SceneManager.LoadScene(scene);
	}
}
