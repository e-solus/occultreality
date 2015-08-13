using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class CanvasGameOver : MonoBehaviour {

	public GameObject txtPoint;
	public GameObject txtPointRecord;
	public GameObject txtBestRecord;
	public GameObject txtNRecord;

	private PlayerController player;
	private GameController game;

	private bool showGameOver;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType (typeof(PlayerController)) as PlayerController;
		game = FindObjectOfType (typeof(GameController)) as GameController;
		txtBestRecord.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (game.status == GameStatus.GAMEOVER) {
			if (PlayerPrefs.GetInt ("positionRecord") == 0) {
				txtPoint.GetComponent<Text> ().text = player.monsters.ToString();
				txtPointRecord.GetComponent<Text> ().text = PlayerPrefs.GetInt ("recordN5").ToString();
			} else {
				txtBestRecord.SetActive(true);
				//PlayerPrefs.SetInt("recordN"+PlayerPrefs.GetInt ("positionRecord").ToString(), player.monsters);

				txtNRecord.GetComponent<Text> ().text = PlayerPrefs.GetInt ("positionRecord").ToString() + "th";
				txtPoint.GetComponent<Text> ().text = player.monsters.ToString();
				txtPointRecord.GetComponent<Text> ().text = PlayerPrefs.GetInt ("recordN"+PlayerPrefs.GetInt ("positionRecord").ToString()).ToString();
			}
		}
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
