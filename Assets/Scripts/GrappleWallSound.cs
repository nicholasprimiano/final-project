﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GrappleWallSound : MonoBehaviour
{
	private AudioSource audio;

	void Start ()
	{
		audio = GetComponent<AudioSource> ();
	}

	public void playLandSound ()
	{
		audio.Play ();
	}
}