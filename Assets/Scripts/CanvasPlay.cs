using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasPlay : MonoBehaviour {

	public GameObject canvasTutorial;
	public GameObject canvasGyro;
	public GameObject canvasPause;

	public GameObject txtTime;
	public GameObject txtMonsters;
	public Slider sliderTime;

	public GameObject gameOver;

	private GameController game;
	private PlayerController player;
	
	// Use this for initialization
	void Start () {
		game = FindObjectOfType (typeof(GameController)) as GameController;
		player = FindObjectOfType (typeof(PlayerController)) as PlayerController;

		//canvasPause.gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		if (game.status == GameStatus.TUTORIAL) {
			canvasTutorial.gameObject.SetActive(true);
			gameOver.SetActive(false);

			GetComponent<Canvas>().enabled = false;
		}
		if (game.status == GameStatus.PLAY || game.status == GameStatus.PAUSE) {

			gameOver.SetActive(false);
			canvasTutorial.gameObject.SetActive(false);

			GetComponent<Canvas>().enabled = true;

			sliderTime.maxValue = player.maxSecond;
			sliderTime.value = player.second;
			txtTime.GetComponent<Text> ().text = player.second.ToString();
			txtMonsters.GetComponent<Text> ().text = player.monsters.ToString();

			// txtTime blink
			if (player.second <= 5) {
				txtTime.GetComponent<Animator>().SetBool("txt_time_blink", true);
			} else {
				txtTime.GetComponent<Animator>().SetBool("txt_time_blink", false);
			}
		} else {
			GetComponent<Canvas>().enabled = false;
		}

		if (game.status == GameStatus.PAUSE) {
			canvasPause.gameObject.SetActive(true);
		} else {
			canvasPause.gameObject.SetActive(false);
		}

		if (game.status == GameStatus.GAMEOVER) {
			gameOver.SetActive(true);
		}

		if (game.status == GameStatus.FAIL) {
			canvasGyro.SetActive(true);
		}
	}

	// methods buttons
	public void goPlayGame() {
		game.inicar ();
	}

	public void doRestartGame() {
		game.reinicar ();
	}

	public void doRecord() {
		Application.LoadLevel("record");
	}

	public void doPause() {
		game.pause ();
	}

	public void doExit() {
		Application.Quit ();
	}
}
