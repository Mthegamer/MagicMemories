using UnityEngine;
using System.Collections;

public class SharkAnimManager : MonoBehaviour {

	private int animationNumber = 0;

	private bool readyToPlay = true;

	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {

		if(animationNumber==0){
				animation.Play ("Swim");
				//animation.PlayQueued("Swim", QueueMode.CompleteOthers);
			}

		if(readyToPlay){

			

			if(animationNumber==1){
	     		animation.CrossFade ("Surface");
	     		animation.CrossFadeQueued("Swim", 0.3F, QueueMode.CompleteOthers);
	     		Invoke("SetToSwim", 5f);
			}

			else if(animationNumber==2){
				animation.Play ("Idle");
			}


			readyToPlay = false;

		}
	
	}

	public void ChangeAnim(int animNumber){


		animationNumber = animNumber;
		readyToPlay = true;
	}

	void SetToSwim(){
		animationNumber = 0;
	}
}
