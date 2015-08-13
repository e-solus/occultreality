using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemiesSpaw : MonoBehaviour {

	public GameObject monster;
	public List<GameObject> monsters;

	private GameController game;
	
	// Use this for initialization
	void Start () {
		game = FindObjectOfType (typeof(GameController)) as GameController;
		
		for (int i = 0; i <= 4; i++) {
			GameObject tmpMonster;
			tmpMonster = Instantiate(monster) as GameObject;
			tmpMonster.SetActive(false);
			monsters.Add(tmpMonster);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (game.status == GameStatus.PLAY) {
			spaw ();
		}
	}

	private void spaw() {
		GameObject tmp = null;

		for (int i = 0; i <= 4; i++) {
			if (monsters[i].activeSelf == false) {
				tmp = monsters[i];
				break;
			}
		}

		if (tmp != null) {

			Vector3 Pos;
			Quaternion rot;
			float rotX=UnityEngine.Random.Range(0f,360f);

			while((rotX>60f && rotX<120f) || (rotX>240f && rotX<300f)){
				rotX=UnityEngine.Random.Range(0f,360f);
			}
			float rotY=UnityEngine.Random.Range(0f,360f);
			float rotZ=0f;
			rot=Quaternion.Euler(new Vector3(rotX,rotY,rotZ));

			tmp.transform.rotation=rot;

			//tmp.transform.position = new Vector3(0, 0, -600);

			tmp.SetActive(true);
		}
	}
}
