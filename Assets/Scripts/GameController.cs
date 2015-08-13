using UnityEngine;
using System.Collections;

public enum GameStatus {
	PLAY,
	PAUSE,
	RESTART,
	GAMEOVER,
	TUTORIAL,
	MENU,
	FAIL
}

public class GameController : MonoBehaviour {
	
	public GameStatus status;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		// RESTART
		if (status == GameStatus.RESTART) {
			status = GameStatus.PLAY;
		}

		if (Input.GetKey(KeyCode.Escape)) {
			//status = GameStatus.PAUSE;
		}
	}
	
	public void inicar() {
		status = GameStatus.PLAY;
	}
	// inicia uma nova partida
	public void iniciarPlay() {
		status = GameStatus.PLAY;
	}
	public void pause() {
		/*if (status == GameStatus.PAUSE) {
			status = GameStatus.PLAY;
		} else {
			status = GameStatus.PAUSE;
		}*/
	}
	public void gameOver() {
		status = GameStatus.GAMEOVER;
	}
	public void fail() {
		status = GameStatus.FAIL;
	}
	public void reinicar() {
		Application.LoadLevel ("game");
	}
}
