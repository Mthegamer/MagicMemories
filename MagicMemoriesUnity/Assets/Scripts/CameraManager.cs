using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public GameObject Camera_AR;
	public GameObject Camera_Shark;

	public Transform SharkCamPoint;
	public Transform SharkCamPoint2;

	public Camera C_AR;
	public Camera C_Shark;

	public LayerMask sharkLayer;
	public LayerMask everythingLayer;
	public LayerMask nothingLayer;

	public Vector3 TurtleAdjustment;
	public Quaternion TurtleRotation;

	private int currentAnimal = 0;

	void Awake(){
		Camera_AR = GameObject.Find("ARCamera");
		Camera_Shark = GameObject.Find("SharkCamera");

		C_AR = Camera_AR.GetComponent<Camera>();
		C_Shark = Camera_Shark.GetComponent<Camera>();

		SharkCamPoint = GameObject.Find("CameraFollowPoint").GetComponent<Transform>();
		SharkCamPoint2 = GameObject.Find("CameraFollowPoint2").GetComponent<Transform>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(currentAnimal==0){
			Camera_Shark.transform.position = SharkCamPoint.position;
			Camera_Shark.transform.rotation = SharkCamPoint.rotation;
		}

		else if(currentAnimal==1){
			Camera_Shark.transform.position = SharkCamPoint2.position;
			Camera_Shark.transform.rotation = SharkCamPoint2.rotation;
		}
	
	}

	public void ARCameraToggle(bool on){
		if(on){
			//C_AR.cullingMask = playerMask;
			//C_AR.cullingMask |= (1 << 9);
			C_AR.cullingMask = 1 << 9 | 1 << 10;

			//C_AR.cullingMask |= (1 << 10);

		}

		else{
			//C_AR.cullingMask = playerMask;
		//	C_AR.cullingMask = ~(1 << 9);
			C_AR.cullingMask = 0;

			//C_AR.cullingMask = ~(1 << 10);
		}
		
	}

	public void SharkCameraToggle(bool on){
		if(on){
			//C_AR.cullingMask = playerMask;
		//	C_Shark.cullingMask |= (1 << 9);
			C_Shark.cullingMask = (1 << 9);

		}

		else{
			//C_AR.cullingMask = playerMask;
			C_Shark.cullingMask = 0;


		}
		
	}

	public void ChangeAnimal(int animal){
		currentAnimal = animal;
	}
}
