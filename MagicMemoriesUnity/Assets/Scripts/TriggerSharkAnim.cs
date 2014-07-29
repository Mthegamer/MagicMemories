using UnityEngine;
using System.Collections;

public class TriggerSharkAnim : MonoBehaviour {

	private SharkAnimManager SAM;

	// Use this for initialization
	void Start () {
	SAM = GameObject.Find("SharkModel").GetComponent<SharkAnimManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {

		Debug.Log("TRIGGER Anim");

		SAM.ChangeAnim(1);
    }
}
