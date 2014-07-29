using UnityEngine;
using System.Collections;

public class TurtleAnimManager : MonoBehaviour {

	private int animationNumber = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(animationNumber==0){
				animation.Play ("Swim");
				//animation.PlayQueued("Swim", QueueMode.CompleteOthers);
		}

		else if(animationNumber==2){
				animation.Play ("Idle");
		}
	
	}

	public void ChangeAnim(int animNumber){


		animationNumber = animNumber;
	}
}
