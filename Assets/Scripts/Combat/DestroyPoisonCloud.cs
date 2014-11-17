﻿using UnityEngine;
using System.Collections;

public class DestroyPoisonCloud : MonoBehaviour {

	public GameObject player;
	public float aoe = 6f;
	public float duration=5f;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject go in enemies) {
			if (getDistance(go)<=aoe){
				go.GetComponent<Status>().health-=Time.deltaTime * 
					player.GetComponent<Status>().intelligence;
				//Debug.Log ("PCloud");
				//if (true){
				//go.GetComponent<Status>().poisonTimer=5f;//can be poisoned by DoT debuff and by poisonCloud at same time
				//go.GetComponent<Status>().isPoisoned=true;
				//}
			}
		}
		duration -= Time.deltaTime;
		if (duration <= 0) {
			Destroy (gameObject);
		}
	}
	
	public float getDistance(GameObject go){
		return (go.transform.position - gameObject.transform.position).sqrMagnitude;
	}
}
