using UnityEngine;
using System.Collections;

public class HotspotTriggerNGUI : MonoBehaviour {

	public int hotspotNumber;
	private UIManager UIM;


	// Use this for initialization
	void Start () {
		UIM = GameObject.Find("Manager").GetComponent<UIManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick() {
		UIM.OpenPOI(hotspotNumber, true);
	}
}
