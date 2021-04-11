using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : MonoBehaviour {

	Animator anim;
	void Start()
	{
		anim = GetComponent<Animator>();
	}

	public void PlaySlide()
	{
		anim.Play("infoButton");
	}

	public void CloseSlide()
	{
		anim.Play("ReverseinfoButton");
	}
}
