using UnityEngine;
using System.Collections;

public class TriggerEventNGUI : MonoBehaviour {

	public enum ButtonType{Transition, Fact, CharacterSwap};
	public enum TriggerType{Open, Close};

	public int triggerNumber;
	public TriggerType triggerType;
	public ButtonType buttonType;
	private bool willOpen = false;

	private UIManager UIM;

	// Use this for initialization
	void Start () {

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

	void OnClick() {

		if(buttonType == ButtonType.Transition){

			//UIM.OpenPOI(triggerNumber, willOpen);
	        Debug.Log("Trigger Event: " +  triggerNumber + " Open:" + willOpen);
	      //  UIM.screenTransition();
	        UIM.TriggerTransition(triggerNumber);
    	}

    	//Trigger different fact popups
    	else if(buttonType == ButtonType.Fact){
    		//UIM.ChangeSkin(triggerNumber);

    	}

    	else if(buttonType == ButtonType.CharacterSwap){
    		Debug.Log("Swap character: " +  triggerNumber);
    		UIM.swapCharacter(triggerNumber);
    	}
    }
}
