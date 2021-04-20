using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using UnityEngine.Video;

//Custom 8
public partial class Wit3D : MonoBehaviour {

	public Text myHandleTextBox;
	private bool actionFound = false;

	public bool[,] itemOptions = new bool[,]
	{
		//options order = open door close door, start engine stop engine, colors windows show engine, video bonnet hood, trunk
		{true, true, true, true, true, true, true, true, true, true, true },//convertlambo
		{true, true, true, true, true, true, true, true, true, true,true },//ornage lambo
		{false, false, true, true, true, false, true, true, true, true, false },//police car
		{true, true, true, true, true, true, true, true, true, true, true }//tocus
	};

	public bool errorCheck(int col)
    {
		return itemOptions[carController.selectedIndex, col];
    }

	public void ShowMessage()
    {
		myHandleTextBox.text = "Sorry this action is unavalible for this car";
    }

	void Handle (string jsonString) {
		
		if (jsonString != null) {

			RootObject theAction = new RootObject ();
			Newtonsoft.Json.JsonConvert.PopulateObject (jsonString, theAction);

			if (theAction.entities.open != null) {
				foreach (Open aPart in theAction.entities.open) {
					Debug.Log (aPart.value);
					//myHandleTextBox.text = aPart.value;//commented out after i made switch statement as it was being over ridding by show messeage method, this shows the name of the part in the gui eg hood door
					actionFound = true;

                    if (theAction._text.Contains("open"))
                    {
                        switch (aPart.value)
                        {
							case "drivers door"://these are case sensitive so make it the same as wit ai bot values
                                if (errorCheck(0))
                                {
									if (theAction._text.Contains("drivers door"))
                                    {
										carController.instance.triggerAnimation("DoorOpen");
										carController.instance.triggerAnimation("openOrangeDriversDoor");
									}
										
								}
                                else
                                {
									ShowMessage();
                                }
								break;
							case "windows":
								if (errorCheck(5))
								{
									if (theAction._text.Contains("windows"))
									{
										carController.instance.triggerAnimation("windows");
									}
								}
								else
								{
									ShowMessage();
								}
								break;
							case "hood":
								if (errorCheck(9))
								{
									if (theAction._text.Contains("hood"))
									{
										carController.instance.triggerAnimation("hoodOpen");
									}
								}
								else
								{
									ShowMessage();
								}
								break;
							case "trunk":
								if (errorCheck(10))
								{
									if (theAction._text.Contains("trunk"))//adding these in so it double checks so only one animation plays at a time
									{
										carController.instance.triggerAnimation("convertTrunkOpen");
									}
								}
								else
								{
									ShowMessage();
								}
								break;
							//case "bonnet"://ai bot doesnt know much about bonnet
							//	if (errorCheck(8))
							//	{
							//		if (theAction._text.Contains("bonnet"))
							//		{
							//			carController.instance.triggerAnimation("hoodOpen");
							//		}
							//	}
							//	else
							//	{
							//		ShowMessage();
							//	}
							//	break;
							case "engine":
								if (errorCheck(6))
								{
									if (theAction._text.Contains("engine"))
									{
										carController.instance.triggerAnimation("hoodOpen");
									}
								}
								else
								{
									ShowMessage();
								}
								break;
							default:
								ShowMessage();
								break;
                        }
                        //    carController.instance.triggerAnimation("DoorOpen");
                        //}

                        //if (theAction._text.Contains("open"))
                        //{
                        //    carController.instance.triggerAnimation("openWindows");
                        //}

                        //else if (theAction._text.Contains("open"))
                        //{
                        //    carController.instance.triggerAnimation("hoodOpen");
                    }
                }
			}
			if (theAction.entities.close != null) {
				foreach (Close aPart in theAction.entities.close) {
					Debug.Log (aPart.value);

                    if (theAction._text.Contains("close"))
                    {
						switch (aPart.value)
						{
							case "drivers door"://these are case sensitive so make it the same as wit ai bot values
								if (errorCheck(1))
								{
									if (theAction._text.Contains("drivers door"))
									{
										carController.instance.triggerAnimation("DoorClose");
									}
								}
								else
								{
									ShowMessage();
								}
								break;
							case "windows":
								if (errorCheck(5))
								{
									if (theAction._text.Contains("windows"))
									{
										carController.instance.triggerAnimation("Closewindows");
									}
								}
								else
								{
									ShowMessage();
								}
								break;
							case "hood":
								if (errorCheck(9))
								{
									if (theAction._text.Contains("hood"))
									{
										carController.instance.triggerAnimation("hoodClose");
									}

								}
								else
								{
									ShowMessage();
								}
								break;
							case "trunk":
								if (errorCheck(10))
								{
									if (theAction._text.Contains("trunk"))
									{
										carController.instance.triggerAnimation("convertTrunkClose");
									}
								}
								else
								{
									ShowMessage();
								}
								break;
							//case "bonnet":
							//	if (errorCheck(8))
							//	{
							//		if (theAction._text.Contains("bonnet"))
							//		{
							//			carController.instance.triggerAnimation("hoodClose");
							//		}
							//	}
							//	else
							//	{
							//		ShowMessage();
							//	}
							//	break;
							case "engine":
								if (errorCheck(6))
								{
									if (theAction._text.Contains("engine"))
									{
										carController.instance.triggerAnimation("hoodClose");
									}
								}
								else
								{
									ShowMessage();
								}
								break;
							default:
								ShowMessage();
								break;
						}
						//	carController.instance.triggerAnimation("DoorClose");
						//}

						//if (theAction._text.Contains("close"))
						//{
						//	carController.instance.triggerAnimation("closeWindows");
					}
					//myHandleTextBox.text = aPart.value;
					actionFound = true;
				}
			}

			if (theAction.entities.start != null)
			{
				foreach (Start aPart in theAction.entities.start)
				{
					Debug.Log(aPart.value);

                    if (theAction._text.Contains("start"))
                    {
                        switch (aPart.value)
                        {
							case "engine":
                                if (errorCheck(2))
                                {
									if (theAction._text.Contains("engine"))
									{
										carController.instance.PlaySound();
									}
								}
                                else
                                {
									ShowMessage();
                                }
								break;
							case "video":
								if (errorCheck(7))
								{
									if (theAction._text.Contains("video"))
									{
										GameObject.Find(ColourSwitcher.instance.getCurrentTracked().name + "/ActiveItems/" + GameController.currentSelectedCar + "/video").GetComponent<VideoPlayer>().Play();
									}
								}
								else
								{
									ShowMessage();
								}
								break;
							default:
								ShowMessage();
								break;
                        }
                        //carController.instance.PlaySound();
                    }

					//myHandleTextBox.text = aPart.value;
					actionFound = true;
				}
			}

			if (theAction.entities.stop != null)//does it have any prefilled valued? if so do foreach
			{
				foreach (Stop aPart in theAction.entities.stop)
				{
					Debug.Log(aPart.value);

                    if (theAction._text.Contains("stop"))
                    {
						switch (aPart.value)
						{
							case "engine":
								if (errorCheck(2))
								{
									if (theAction._text.Contains("engine"))
									{
										carController.instance.StopSound();
									}
								}
								else
								{
									ShowMessage();
								}
								break;
							case "video":
								if (errorCheck(7))
								{
									if (theAction._text.Contains("video"))
									{
										GameObject.Find(ColourSwitcher.instance.getCurrentTracked().name + "/ActiveItems/" + GameController.currentSelectedCar + "/video").GetComponent<VideoPlayer>().Stop();
									}
								}
								else
								{
									ShowMessage();
								}
								break;
							default:
								ShowMessage();
								break;
						}
						//carController.instance.StopSound();
					}

					//myHandleTextBox.text = aPart.value;
					actionFound = true;
				}
			}

			if (theAction.entities.colour != null)
			{
				foreach (Colour aPart in theAction.entities.colour)
				{
					Debug.Log(aPart.value);
                    if (theAction._text.Contains("change"))
                    {
						ColourSwitcher.instance.colours(aPart.value);
					}	
					myHandleTextBox.text = aPart.value;
					actionFound = true;
				}
			}

			if (!actionFound) {
				myHandleTextBox.text = "Request unknown, please ask a different way.";
			} else {
				actionFound = false;
			}

 		}//END OF IF

 	}//END OF HANDLE VOID

}//END OF CLASS
	

//Custom 9
public class Open {
	public bool suggested { get; set; }
	public double confidence { get; set; }
	public string value { get; set; }
	public string type { get; set; }
}

public class Close {
	public bool suggested { get; set; }
	public double confidence { get; set; }
	public string value { get; set; }
	public string type { get; set; }
}

public class Start
{
	public bool suggested { get; set; }
	public double confidence { get; set; }
	public string value { get; set; }
	public string type { get; set; }
}

public class Stop
{
	public bool suggested { get; set; }
	public double confidence { get; set; }
	public string value { get; set; }
	public string type { get; set; }
}

public class Colour
{
	public bool suggested { get; set; }
	public double confidence { get; set; }
	public string value { get; set; }
	public string type { get; set; }
}

public class Entities {
	public List<Open> open { get; set; }
	public List<Close> close { get; set; }
	public List<Start> start { get; set; }
	public List<Stop> stop { get; set; }
	public List<Colour> colour { get; set; }
}

public class RootObject {
	public string _text { get; set; }
	public Entities entities { get; set; }
	public string msg_id { get; set; }
}