using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour {
	public float respwanDelay;
	public playerControl gamePlayer;
	public int Coins;
	public Text coinText;
	// Use this for initialization
	void Start () {
		gamePlayer = FindObjectOfType<playerControl>();
		coinText.text = "COIN : "+Coins;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Respwan(){
		StartCoroutine("Respawn2");
	}
	public IEnumerator Respawn2(){
		gamePlayer.gameObject.SetActive (false);
		yield return new WaitForSeconds(respwanDelay);
		gamePlayer.transform.position = gamePlayer.respwanPoint;
		gamePlayer.gameObject.SetActive (true);
	}
	public void AddCoin(int numberOfCoins){
		Coins += numberOfCoins;
		coinText.text = "COIN : "+Coins;
	}
}
