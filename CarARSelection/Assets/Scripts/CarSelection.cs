using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelection : MonoBehaviour {

    public GameObject[] carList;
    private int currentCar = 0;

    void Start()
    {
        //counts the chold gameobjects in the lost
        carList = new GameObject[transform.childCount];
        //loop threw child items and fill in correct slots
        for (int i = 0; i < transform.childCount; i++)
        {
            carList[i] = transform.GetChild(i).gameObject;
        }
        //deactive all gameobjects
        foreach (GameObject gameobj in carList)
        {
            gameobj.SetActive(false);
            //set initial gameobject to be active
            if (carList[0])
            {
                carList[0].SetActive(true);
            }
        }
    }

    public void ToggleCars(string direction)
    {//buttons for left and right viewing of the cars
        carList[currentCar].SetActive(false);
        if (direction == "Right")
        {
            currentCar++;
            if (currentCar > carList.Length - 1)
            {
                currentCar = 0;
            }
        }
        else if (direction == "Left")
        {
            currentCar--;
            if (currentCar < 0)
            {
                currentCar = carList.Length - 1;
            }
        }

        //set current car to be actiive from list
        carList[currentCar].SetActive(true);
        GameController.currentSelectedCar = carList[currentCar].name;
        //partical system stuff
        GameObject cloudSystem = (GameObject)Instantiate(Resources.Load("CloudParticale"));
        ParticleSystem cloudPuff = cloudSystem.GetComponent<ParticleSystem>();
        cloudPuff.Play();
        cloudPuff.transform.position = new Vector3(0.65f, -2, 3);
        Destroy(cloudSystem, 2f);
    }
}
