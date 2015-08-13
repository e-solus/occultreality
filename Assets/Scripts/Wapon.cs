using UnityEngine;
using System.Collections;

public class Wapon : MonoBehaviour {

	public GameObject bullet;

	private bool shot;
	private float timeShot;

	private GameController game;

	// Use this for initialization
	void Start () {
		game = FindObjectOfType (typeof(GameController)) as GameController;
	}
	
	// Update is called once per frame
	void Update () {
		if (game.status == GameStatus.PLAY) {
			if (Input.GetMouseButtonDown (0)) {
				if (shot == false) {
					shot = true;
					Instantiate(bullet,this.transform.position,this.transform.rotation);
					SoundManager.instance.PlaySound("shot");
				}
			}

			if (shot) {
				timeShot += Time.deltaTime;
				if (timeShot >= 0.4) {
					timeShot = 0;
					shot = false;
				}
			}
		}
	}
}
