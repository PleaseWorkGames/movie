using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {

	public float lossRate = 0;

	public float maxHealth = 100;

	public float initialHealth = 100;

	private float currentHealth;
	private float currentScale;

	private Transform transformer;
	// Use this for initialization
	void Start () {
		currentScale = this.transform.localScale.y;
		currentHealth = initialHealth;

		transformer = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if(currentHealth > 0)
		{
			currentHealth = currentHealth - lossRate*Time.deltaTime;
			currentScale = currentHealth/maxHealth;
		}
		else
		{
			currentHealth = currentScale = 0;
		}

		transformer.localScale = new Vector2(1,this.currentScale);
	}

}
