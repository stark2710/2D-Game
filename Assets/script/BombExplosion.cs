using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BombExplosion : MonoBehaviour {

	public Sprite Bomb;
	public Sprite Smoke;
	private SpriteRenderer bombSpriteRenderer;
	public GameObject GameOverText;
	private playerControl gamePlayer;
	private float respwanDelay = 10.0f;
	//public GameObject RestartButton;
	public GameObject Menu;
	public GameObject HighScorePanel;
//	public bool checkpointReached;
	

	// Use this for initialization
	void Start () {
		bombSpriteRenderer = GetComponent<SpriteRenderer>();
		gamePlayer = FindObjectOfType<playerControl>();
	//	RestartButton.SetActive(false);
		Menu.SetActive (false);
		HighScorePanel.SetActive (false);
		GameOverText.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Player"){
			
			gamePlayer.gameObject.SetActive (false);
			bombSpriteRenderer.sprite = Smoke;
			GameOverText.SetActive(true);
			StartCoroutine("Restart");
		//	checkpointReached = true;
		}
	}
	public IEnumerator Restart(){
		
		yield return new WaitForSeconds(5);
		Menu.SetActive (true);

	}
	public void loadScene(){
		SceneManager.LoadScene("playerPerson");
	}
	public void closeScene(){
		Application.Quit ();
	}
	
}
