using UnityEngine;
using System.Collections;

public class WaterLayerManager : MonoBehaviour {

	private ImageTargetBehaviour ITB;
	private float imageHeight; //width is always 1.

	private float imageWidth;

	private Transform waterLayer;

	// Use this for initialization
	void Start () {

		waterLayer = GameObject.Find("Water4Example (Advanced)").GetComponent<Transform>();

		ITB = this.GetComponent<ImageTargetBehaviour>();
		imageHeight = ITB.GetSize().y / 100;
		imageWidth = ITB.GetSize().x / 100;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResizeWaterLayer(){
		waterLayer.localScale = new Vector3(imageWidth,1f,imageHeight);
	}
}
