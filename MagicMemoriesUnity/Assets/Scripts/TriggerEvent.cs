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

	/*void OnMouseDown() {

		Debug.Log("TRIGGER MOUSE");

		UIM.OpenPOI(triggerNumber, willOpen);
    }*/
    
    void OnMouseDown() {

		#if UNITY_ANDROID

		Debug.Log("TOUCH:" + Input.touches.Length);
		for(int i = 0; i < Input.touches.Length; i++)//How many touches do we have? 
	    { 
	        Touch touch = Input.touches[i];//The touch 
	        Ray ray = Camera.main.ScreenPointToRay(touch.position); 
	         
	        RaycastHit hit;// = new RaycastHit(); 
	        if(Physics.Raycast(ray, out hit, 1000)) 
	        { 
	            if(hit.collider.gameObject == this.gameObject) 
	            { 
	                switch(touch.phase) 
	                { 
	                    case TouchPhase.Began://if the touch begins 
	                       // Debug.Log("Ticked");

	                       		UIM.OpenPOI(triggerNumber, willOpen);
	                    break; 
	                     
	                    case TouchPhase.Ended://If the touch ends 
	                         
	                    break; 
	                     
	                    case TouchPhase.Moved://If the finger moved 
	                         
	                    break; 
	                     
	                    case TouchPhase.Stationary://While touching the screen and didn move the finger. 
	                         
	                    break; 
	                     
	                    default: 
	                         
	                    break; 
	                } 
	            } 
	        }
	}

	#endif

	#if UNITY_EDITOR

	                        UIM.OpenPOI(triggerNumber, willOpen);


	#endif 
							

	}
	
}
