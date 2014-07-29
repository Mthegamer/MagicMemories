
//attach this script to the object you want the animations to play on when
//clicking the Left mouse button.

//Remember the name of your animations!

var animationNumber = 0;

function Update ()
{
	/*if (Input.GetButton ("Fire1") ) //check to see if the left mouse was pushed.
	{
		animation.CrossFade ("Surface"); // if pushed play the animation listed within the quotation marks.
	}
	
	//add multiple animations by copying and pasting this code (below for else if) and changing
	//the animation and button.
	
		
	else // if NOT just play the idle animation.
	{
		animation.Play ("Swim");
	}*/

	if(animationNumber==0){
		animation.Play ("Swim");
	}

	else if(animationNumber==1){
		animation.CrossFade ("Surface");
	}

	else if(animationNumber==2){
		animation.Play ("Idle");
	}
}

public function ChangeAnim(animNumber){
	animationNumber = animNumber;
}