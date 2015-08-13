using UnityEngine;
using System.Collections;

public class EnemiesController : MonoBehaviour {

	public GameObject mainObject;
	public GameObject subObject;

	private GameObject camera;
	private PlayerController player;
	private GameController game;

	private bool increase;
	private float sidespeed;

	private float timeToDie;

	private bool die;

	public int hp;

	// particle
	public GameObject particleBomb;
	public GameObject explosion;

	void OnEnable() {
		die = false;
		increase = true;
		sidespeed = Random.Range (1f, 3f);
		subObject.transform.localPosition=new Vector3(0f,0f,-Random.Range(600f,800f));

		//rand HP
		if(Random.Range(0, 100) <= 70) {
			hp = 1;
		} else {
			hp = 2;
		}
	}

	// Use this for initialization
	void Start () {
		camera = GameObject.FindWithTag ("camera");
		player = FindObjectOfType (typeof(PlayerController)) as PlayerController;
		game = FindObjectOfType (typeof(GameController)) as GameController;
	}
	
	// Update is called once per frame
	void Update () {
		if (game.status == GameStatus.PLAY) {
			if (hp > 0) {
				if (this.transform.localPosition.x > 120.0f)
					increase = false;
				else if (this.transform.localPosition.x < -120.0f)
					increase = true;
				if (increase)
					this.transform.localPosition += new Vector3(sidespeed,0.0f,0.0f);
				else
					this.transform.localPosition -= new Vector3(sidespeed,0.0f,0.0f);
			}

			/*if (hp < 1) {
				timeToDie += Time.deltaTime;
				if (timeToDie >= 1.8f) {
					timeToDie = 0;
					mainObject.SetActive(false);
				}
			}*/

			transform.LookAt(transform.position + camera.transform.rotation * Vector3.back, camera.transform.rotation * Vector3.up);
		}
	}

	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.tag == "bullet") {
			hp -= 1;
			if (hp <= 0) {
				// die
				if (die == false) {
					player.monsters += 1;
					die = true;
				}
				GetComponent<Animation> ().Play ("Growl");
				Destroy(coll.gameObject);
				Instantiate(explosion, this.transform.position, Quaternion.identity);
				SoundManager.instance.PlaySound("explosion");
				//Instantiate(explosion, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
				mainObject.SetActive(false);
				// instante
				//particleBomb.GetComponent<ParticleSystem>().Emit(1);
			} else {
				SoundManager.instance.PlaySound("monsterRoar");
				GetComponent<Animation> ().Play ("Block");
			}
		}
	}
}
