using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	public void SavePlayer(){
		SaveSystem.SavePlayer (this);
	}
	public void LoadPlayer(){
		PlayerData data = SaveSystem.LoadPlayerP ();

		Vector3 position;
		position.x = data.position[0];
		position.y = data.position[1];
		position.z = data.position[2];

		transform.position = position;
	}
	public void SaveGame() {
		PlayerPrefs.SetInt ("Level", SceneManager.GetActiveScene ().buildIndex);
		PlayerPrefs.Save ();
		print ("Game saved!");
	}
	public void LoadGame() {
		SceneManager.LoadScene ( PlayerPrefs.GetInt("Level") );
		print ("Game loaded!");
	}
}
