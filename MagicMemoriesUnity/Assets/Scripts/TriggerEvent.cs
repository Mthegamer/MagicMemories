using UnityEngine;
using System.Collections;

public class TriggerEvent : MonoBehaviour {

	public enum TriggerType{Open, Close};

	public int triggerNumber;
	public TriggerType triggerType;
	private bool willOpen = false;

	private UIManager UIM;

	// Use this for initialization
	void Start () {

		Debug.Log("TRIGGER ACTIVE");

		UIM = GameObject.Find("Manager").GetComponent<UIManager>();

		if(triggerType == TriggerType.Open){
			willOpen = true;
		}

		else{
			willOpen = false;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {

		Debug.Log("TRIGGER MOUSE");

		UIM.OpenPOI(triggerNumber, willOpen);
    }
}
