using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour {

	public int second;
	public int maxSecond;
	private float tmpSecond;

	public bool shot;
	private float timeShot;

	public int monsters;

	private GameController game;
	private CanvasGameOver canvasGameOver;

	private string leaderboard = "CgkIwpCWqKgeEAIQAQ";
	
	// Use this for initialization
	void Start () {
		monsters = 0;
		second = 90;
		maxSecond = 90;

		game = FindObjectOfType (typeof(GameController)) as GameController;
		//PlayerPrefs.DeleteAll ();
	}
	
	// Update is called once per frame
	void Update () {
		if (game.status == GameStatus.PLAY) {

			tmpSecond += Time.deltaTime;
			if (tmpSecond >= 1) {
				if (second > 0) {
					second -= 1;
				} else {
					second = 0;
					calculateRecord();
					game.gameOver();
				}
				tmpSecond = 0;
			}
		}
	}

	public void calculateRecord () {
		int positionRecord = 0;

		/*if (PlayerPrefs.HasKey("recordN5")) PlayerPrefs.SetInt("recordN5", 0);
		if (PlayerPrefs.HasKey("recordN4")) PlayerPrefs.SetInt("recordN4", 0);
		if (PlayerPrefs.HasKey("recordN3")) PlayerPrefs.SetInt("recordN3", 0);
		if (PlayerPrefs.HasKey("recordN2")) PlayerPrefs.SetInt("recordN2", 0);
		if (PlayerPrefs.HasKey("recordN1")) PlayerPrefs.SetInt("recordN1", 0);*/
		
		if (PlayerPrefs.GetInt("recordN5") < monsters) {
			positionRecord = 5;
		}
		if (PlayerPrefs.GetInt("recordN4") < monsters) {
			positionRecord = 4;
		}
		if (PlayerPrefs.GetInt("recordN3") < monsters) {
			positionRecord = 3;
		}
		if (PlayerPrefs.GetInt("recordN2") < monsters) {
			positionRecord = 2;
		}
		if (PlayerPrefs.GetInt("recordN1") < monsters) {
			positionRecord = 1;
		}

		if (positionRecord > 0) {

			int tmpRecordN1 = PlayerPrefs.GetInt("recordN1");
			int tmpRecordN2 = PlayerPrefs.GetInt("recordN2");
			int tmpRecordN3 = PlayerPrefs.GetInt("recordN3");
			int tmpRecordN4 = PlayerPrefs.GetInt("recordN4");

			if (positionRecord == 1) {
				PlayerPrefs.SetInt("recordN2", tmpRecordN1);
				PlayerPrefs.SetInt("recordN3", tmpRecordN2);
				PlayerPrefs.SetInt("recordN4", tmpRecordN3);
				PlayerPrefs.SetInt("recordN5", tmpRecordN4);
			}
			if (positionRecord == 2) {
				PlayerPrefs.SetInt("recordN3", tmpRecordN2);
				PlayerPrefs.SetInt("recordN4", tmpRecordN3);
				PlayerPrefs.SetInt("recordN5", tmpRecordN4);
			}
			if (positionRecord == 3) {
				PlayerPrefs.SetInt("recordN4", tmpRecordN3);
				PlayerPrefs.SetInt("recordN5", tmpRecordN4);
			}
			if (positionRecord == 4) {
				PlayerPrefs.SetInt("recordN5", tmpRecordN4);
			}

			PlayerPrefs.SetInt ("recordN"+positionRecord.ToString(), monsters);
		}

		if (Social.localUser.authenticated) {
			Social.ReportScore(monsters, leaderboard, (bool success) =>
			                   {
				if (success) {
					((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(leaderboard);
				}
				else {
					//Debug.Log("Login failed for some reason");
				}
			});
		}
		
		PlayerPrefs.SetInt ("positionRecord", positionRecord);
	}
}
