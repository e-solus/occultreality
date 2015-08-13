using UnityEngine;
using System.Collections;

public class WebCam : MonoBehaviour {

	WebCamTexture back;
	GameController game;

	void Awake() {
		DontDestroyOnLoad(gameObject);
		game = FindObjectOfType (typeof(GameController)) as GameController;
	}
	
	// Use this for initialization
	void Start () {
		// load image from camera
		back = new WebCamTexture ();
		renderer.material.mainTexture = back;
		back.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (game.status == GameStatus.GAMEOVER || game.status == GameStatus.PAUSE) {
			back.Stop();
		} else {
			back.Play ();
		}
	}
}
