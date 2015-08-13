using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public bool gyro;

	private Vector3 firstpoint; //change type on Vector3
	private Vector3 secondpoint;
	
	private float xAngle = 0.0f; //angle for axes x for rotation
	private float yAngle = 0.0f;
	private float xAngTemp = 0.0f; //temp variable for angle
	private float yAngTemp = 0.0f;

	private float horizontalSpeed = 40.0f;
	private float verticalSpeed = 40.0f;

	private GameController game;

	void Start() {
		game = FindObjectOfType (typeof(GameController)) as GameController;

		//Initialization our angles of camera
		xAngle = 0.0f;
		yAngle = 0.0f;
		this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);

		Input.gyro.enabled = true;

		if (Input.gyro.enabled) {
			gyro = true;
		} else {
			gyro = true;
			//gyro = false;
			//game.fail();
		}
	}
	
	void Update() {
		if (game.status == GameStatus.PLAY) {
			if (gyro == true) {
				this.transform.Rotate(-Input.gyro.rotationRateUnbiased);
			}

			//Check count touches
			if(Input.touchCount > 0 && gyro == false) {
				//Touch began, save position
				if(Input.GetTouch(0).phase == TouchPhase.Began) {
					firstpoint = Input.GetTouch(0).position;
					xAngTemp = xAngle;
					yAngTemp = yAngle;
				}
				//Move finger by screen
				if(Input.GetTouch(0).phase==TouchPhase.Moved) {
					secondpoint = Input.GetTouch(0).position;
					//Mainly, about rotate camera. For example, for Screen.width rotate on 180 degree
					xAngle = xAngTemp + (secondpoint.x - firstpoint.x) * 180.0f / Screen.width;
					yAngle = yAngTemp - (secondpoint.y - firstpoint.y) *90.0f / Screen.height;
					//Rotate camera
					this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
				}
			}
		}
	}
		
}
