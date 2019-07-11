using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {
	public int CoinValue;
	private LevelManager gameLevelManager;
	// Use this for initialization
	void Start () {
		gameLevelManager = FindObjectOfType<LevelManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			gameLevelManager.AddCoin(CoinValue);
			Destroy(gameObject);
		}
	}
}
