using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static string currentSelectedCar = "myLamboConvert";
		
	// Update is called once per frame
	//void Update () 
	//{
	//	print(currentSelectedCar);
	//}

	public void Quit()
	{
		Application.Quit();
	}

	public void ChangeLevel(string scene)
	{
		SceneManager.LoadScene(scene);
	}
}
