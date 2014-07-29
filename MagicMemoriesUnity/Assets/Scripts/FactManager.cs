using UnityEngine;
using System.Collections;

public class FactManager : MonoBehaviour {

	public string[] SharkFactTitles;
	public string[] SharkFactText;

	public string[] TurtleFactTitles;
	public string[] TurtleFactText;

	public UILabel FactTitle;
	public UILabel FactText;

	void Awake(){
		FactTitle = GameObject.Find("FactTitle_Lbl").GetComponent<UILabel>();
		FactText = GameObject.Find("FactText_Lbl").GetComponent<UILabel>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetFactText(int animalNumber, int factNumber){

		//If showing shark
		if(animalNumber==0){
			FactTitle.text = SharkFactTitles[factNumber];
			FactText.text = SharkFactText[factNumber];
		}

		//If showing Turtle
		else if(animalNumber==1){
			FactTitle.text = TurtleFactTitles[factNumber];
			FactText.text = TurtleFactText[factNumber];
		}
		
	}
}
