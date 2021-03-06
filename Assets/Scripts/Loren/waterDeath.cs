﻿using UnityEngine;
using System.Collections;

public class waterDeath : MonoBehaviour
{

	private bool takingDamage;
	private float currentTime;
	private float startTime;
	public float coolDown = .25f;
	public int waterDamage = 3;



	void Update ()
	{
		currentTime = Time.time;

	}

	void OnTriggerStay2D (Collider2D activator)
	{
		Debug.Log ("Something");
		if (activator.GetComponent<PlayerGrapple> () != null && activator.gameObject.GetComponent<PlayerGrapple> ().isLerping == false) {
			takeDamage (activator);
		}
	}

	void OnTriggerEnter2D (Collider2D activator)
	{
		startTime = currentTime;
	}

	void takeDamage (Collider2D activator)
	{
		if (currentTime - startTime > coolDown) {
			if (activator.GetComponent<PlayerTakeDamage> ().currentShield > waterDamage) {
				activator.GetComponent<PlayerTakeDamage> ().currentShield -= waterDamage * Mathf.CeilToInt (Time.deltaTime)/*Mathf.CeilToInt (Time.deltaTime / 100)*/;
				startTime = currentTime;

				if (!activator.GetComponent<AudioSource> ().isPlaying) {
					activator.GetComponent<AudioSource> ().Play ();
				}


			} else {
				activator.GetComponent<PlayerTakeDamage> ().currentHealth -= waterDamage * Mathf.CeilToInt (Time.deltaTime) /*Mathf.CeilToInt (Time.deltaTime / 100)*/;

				if (!activator.GetComponent<AudioSource> ().isPlaying) {
					activator.GetComponent<AudioSource> ().Play ();
				}


				startTime = currentTime;
			}
		}
	}
}
