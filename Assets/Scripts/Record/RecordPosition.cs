using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RecordPosition : MonoBehaviour {

	public string indice;
	public GameObject txtRecord;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.HasKey ("recordN"+indice)) {
			txtRecord.GetComponent<Text> ().text = PlayerPrefs.GetInt ("recordN"+indice).ToString();
		} else {
			txtRecord.GetComponent<Text> ().text = "-";
		}
	}
}
