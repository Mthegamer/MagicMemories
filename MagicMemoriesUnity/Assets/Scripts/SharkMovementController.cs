using UnityEngine;
using System.Collections;

public class SharkMovementController : MonoBehaviour {

	
	/*private float turnRate = 1f;

	private Vector3 targetPosition;
	private Vector3 currentPosition;

	private float targetAngle;*/

	public Camera raycastCamera;
	public Transform Target;

    public float RotationSpeed = 0.6f;
    public float speed = 20f;
 
    //values for internal use
    private Quaternion _lookRotation;
    private Vector3 _direction;


    private Ray ray;
    private RaycastHit hit;

    private Plane playerMovementPlane;
    private bool canMove = false;


    void Awake(){
		// Set the initial cursor position to the center of the screen
		Target = GameObject.Find("SharkMoveTarget").GetComponent<Transform>();
		raycastCamera = GameObject.Find("ARCamera").GetComponent<Camera>();
		playerMovementPlane = new Plane(transform.up, transform.position + transform.up);
	}

	// Use this for initialization
	void Start () {


	
	}

	void Update () {
		
		//find the vector pointing from our position to the target
       	_direction = (Target.position - transform.position).normalized;
 
        //create the rotation we need to be in to look at the target
        _lookRotation = Quaternion.LookRotation(_direction);
 
        //rotate us over time according to speed until we are in the required rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);

        //rigidbody.velocity = _direction * 20;
        rigidbody.velocity = transform.forward * speed;

        if(canMove){
	        if (Input.GetButton ("Fire1") ) //check to see if the left mouse was pushed.
			{
				Debug.Log("Fire");
	    		Target.position = PlaneRayIntersection(playerMovementPlane);

			}
		}
	}

	public Vector3 PlaneRayIntersection(Plane p)
	{
		float dist = 0.0f;
		//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Ray ray = raycastCamera.ScreenPointToRay(Input.mousePosition);
		
	//	Ray ray = new Ray(cursorScreenPosition, Vector3.up);
	 	Debug.DrawRay(ray.origin, ray.direction * 200, Color.yellow);

		p.Raycast(ray, out dist);
		return ray.GetPoint(dist);
	}

	public void SetCanMove(bool can){
		//Debug.Log("CAN I MOVE SHARK:" + can);
		canMove = can;
	}

	public void ResetMoveTarget(){
		Debug.Log("RESET");
		Target.position = new Vector3(0f,Target.position.y,0f);
	}

}
