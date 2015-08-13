using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class Menu : MonoBehaviour {
	
	public GameObject fade;
	private float timeFadeOutAnimation;
	private bool transaction;

	private string leaderboard = "CgkIwpCWqKgeEAIQAQ";

	// Use this for initialization
	void Start () {
		PlayGamesPlatform.Activate();
		googlePlayGameLogin ();

		PlayerPrefs.SetInt("webcam", 0);
	}
	
	// Update is called once per frame
	void Update () {
		// transaction menu
		if (transaction) {
			timeFadeOutAnimation += Time.deltaTime;
			if (timeFadeOutAnimation >= 1.8f) {
				Application.LoadLevel("game");
			}
		}

		if (Input.GetKey(KeyCode.Escape)) {
			Application.Quit();
		}
	}

	// methods buttons
	public void goPlay() {
		fade.GetComponent<Animator> ().SetBool ("fade_out", true);
		transaction = true;
	}

	public void goRecord() {
		Application.LoadLevel("record");
	}

	public void goRecordGPG () {
		if (Social.localUser.authenticated) {
			Social.ShowLeaderboardUI();
		} else {
			googlePlayGameLogin ();
		}
	}

	public void googlePlayGameLogin () {
		Social.localUser.Authenticate((bool success) =>
		                              {
			if (success) {
				Debug.Log("You've successfully logged in");
			}
			else {
				Debug.Log("Login failed for some reason");
			}
		});
	}
}
