using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float bulletSpeed;
	private float timeBullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, 0, bulletSpeed * Time.deltaTime);
		timeBullet += Time.deltaTime;
		if (timeBullet >= 2) {
			Destroy(gameObject);
		}
	}
}
