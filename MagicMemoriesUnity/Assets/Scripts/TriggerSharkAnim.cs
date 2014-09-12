using UnityEngine;
using System.Collections;

public class TriggerSharkAnim : MonoBehaviour {

	private SharkAnimManager SAM;

	public Camera ARcam;

	// Use this for initialization
	void Start () {
	SAM = GameObject.Find("SharkModel").GetComponent<SharkAnimManager>();
	ARcam = GameObject.Find("ARCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*void OnMouseDown() {

		Debug.Log("TRIGGER Anim");

		SAM.ChangeAnim(1);
    }*/

    void OnMouseDown() {

		#if (UNITY_ANDROID)

		Debug.Log("TOUCH:" + Input.touches.Length);
		for(int i = 0; i < Input.touches.Length; i++)//How many touches do we have? 
	    { 
	        Touch touch = Input.touches[i];//The touch 
	        Ray ray = ARcam.ScreenPointToRay(touch.position); 
	         
	        RaycastHit hit;// = new RaycastHit(); 
	        if(Physics.Raycast(ray, out hit, 1000)) 
	        { 
	        //	Debug.DrawLine(ray.origin, hit.point);
	        		        	     	


	            if(hit.collider.gameObject == this.gameObject) 
	            { 
	                switch(touch.phase) 
	                { 
	                    case TouchPhase.Began://if the touch begins 
	                        

	                       		SAM.ChangeAnim(1);
	                       		Debug.Log("Ticked");
	                    break; 
	                     
	                    default: 
	                         
	                    break; 
	                } 
	            } 
	        }
	}

	#endif

	#if (!UNITY_ANDROID)

	                        SAM.ChangeAnim(1);


	#endif 
							

	}
}
