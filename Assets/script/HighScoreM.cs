using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using UnityEngine.UI;


public class HighScoreM : MonoBehaviour {
	private string connectionString;
	private List<HighScore> highScores = new List<HighScore> ();
	public GameObject scorePrefab;
	public Transform scoreParent;
	private LevelManager lmanager;
	//public GameObject EnterNameText;
	//private string Name;

	// Use this for initialization
	void Start () {
		connectionString = "URI=file:" + Application.dataPath + "/High1.sqlite";
		lmanager = FindObjectOfType<LevelManager>();;
	//	Name = EnterNameText.GetComponent<Text>
	//	Insertdata ("Stark", 78);
		//GetScores ();
		//DeleteScore (0);
		//GetScores ();
		ShowScores();
	}
	
	// Update is called once per frame
	void Update () {
	//	Debug.Log(Name);
	}
	public void Insertdata(string Name, int Score){
		using (IDbConnection dbConnection = new SqliteConnection (connectionString)) {
			dbConnection.Open ();
			using (IDbCommand dbCmd = dbConnection.CreateCommand ()) {
				string sqlQuery = String.Format("insert into HighSore(Name,Score) values(\"{0}\",\"{1}\")",Name,Score);
				dbCmd.CommandText = sqlQuery;
				dbCmd.ExecuteScalar ();
				dbConnection.Close ();
			}
		}
	
	}
	private void GetScores(){
		highScores.Clear ();
		using (IDbConnection dbConnection = new SqliteConnection (connectionString)) {
			dbConnection.Open ();
			using (IDbCommand dbCmd = dbConnection.CreateCommand ()) {
				string sqlQuery = "select * from HighSore";
				dbCmd.CommandText = sqlQuery;
				using (IDataReader reader = dbCmd.ExecuteReader ()) {
					while (reader.Read ()) {
						highScores.Add (new HighScore (reader.GetInt32 (0), reader.GetString (1), reader.GetInt32 (2)));
						Debug.Log (reader.GetString (1) + "-" + reader.GetInt32 (2));
					}
					dbConnection.Close ();
					reader.Close ();
				}
			}
		}
		highScores.Sort ();
	}
	private void DeleteScore(int id){
		using (IDbConnection dbConnection = new SqliteConnection (connectionString)) {
			dbConnection.Open ();
			using (IDbCommand dbCmd = dbConnection.CreateCommand ()) {
				string sqlQuery = String.Format("delete from HighSore where PlayerID = \"{0}\"",id);
				dbCmd.CommandText = sqlQuery;
				dbCmd.ExecuteScalar ();
				dbConnection.Close ();
			}
		}
	
	}
	private void ShowScores(){
		
		GetScores ();
	
		for (int i = 0; i < highScores.Count; i++) {
			GameObject tmpObjec = Instantiate (scorePrefab);
			HighScore tmpScore = highScores [i];
			tmpObjec.GetComponent<HighScoreScript> ().SetScore (tmpScore.Name, tmpScore.Score.ToString (), "#" + (i + 1).ToString ());
			tmpObjec.transform.SetParent (scoreParent);
			tmpObjec.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);

		}
	
	}
	public void NameInput(String Name){
		Debug.Log (Name + "-" + lmanager.Coins);
		Insertdata (Name, lmanager.Coins);
		lmanager.Coins = 0;
		ShowScores ();

	}
}
