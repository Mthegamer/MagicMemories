using UnityEngine;
using System.Collections;
using AnimationOrTween;

public class UIManager : MonoBehaviour {

	public CameraManager CM;
	public SharkAnimManager SAM;
	public TurtleAnimManager TAM;
	public FactManager FM;
	public SharkMovementController SMC;

	public GameObject Screen_Main;
	public GameObject Screen_Experience;

	public GameObject SharkModel;
	public GameObject TurtleModel;

	public GameObject CharacterSelectShark;
	public GameObject CharacterSelectTurtle;


	public GameObject TrackingHint;
	public GameObject Button_Back;
	public GameObject Button_FactFinder;
	public GameObject Title_Hotspot;
	public GameObject Button_Menu;
	public GameObject Popup_Fact;

	public GameObject SharkHotspots;
	public GameObject TurtleHotspots;

	private UILabel animalName_Lbl;
	private Animation currentAnimation;

	private Animation screenTween1;
	private Animation screenTween2;
	private Animation factPanelTween;
	private Animation dropdownmenuTween;
	private Animation dropdownmenu_mainTween;

	private Animation animalSwapTween;

	private ActiveAnimation anim;

	private bool isPopupOpen = false;
	private int lastPopupOpen;

	private int currentAnimal = 0;
	private int currentScreen = 0;

	private bool currentlyTracking = false;

	private bool dropdownOpen = false;
	private bool dropdownMainOpen = false;

	void Awake(){
		CM = GameObject.Find("Manager").GetComponent<CameraManager>();
		SAM = GameObject.Find("SharkModel").GetComponent<SharkAnimManager>();
		TAM = GameObject.Find("TurtleModel").GetComponent<TurtleAnimManager>();
		FM = GameObject.Find("Manager").GetComponent<FactManager>();
		SMC = GameObject.Find("AnimalParent").GetComponent<SharkMovementController>();

		Screen_Main = GameObject.Find("Panel 1");
		Screen_Experience = GameObject.Find("Panel 2");

		SharkModel = GameObject.Find("SharkModel");
		TurtleModel = GameObject.Find("TurtleModel");

		CharacterSelectShark = GameObject.Find("CS_Shark");
		CharacterSelectTurtle = GameObject.Find("CS_Turtle");


		TrackingHint = GameObject.Find("TrackingHint");
		Button_Back = GameObject.Find("Back_Btn");
		Button_FactFinder = GameObject.Find("FactStart_Btn");
		Title_Hotspot = GameObject.Find("Title_Hotspot");
		Button_Menu = GameObject.Find("Menu_Btn");
		Popup_Fact = GameObject.Find("FactPanel");

		SharkHotspots = GameObject.Find("SharkHotSpots");
		TurtleHotspots = GameObject.Find("TurtleHotSpots");

		animalName_Lbl = GameObject.Find("AnimalName_Lbl").GetComponent<UILabel>();

		screenTween1 = Screen_Main.GetComponent<Animation>();
		screenTween2 = Screen_Experience.GetComponent<Animation>();
		dropdownmenuTween = GameObject.Find("Dropdown").GetComponent<Animation>();
		dropdownmenu_mainTween = GameObject.Find("Main_Dropdown").GetComponent<Animation>();
		factPanelTween = Popup_Fact.GetComponent<Animation>();
		animalSwapTween = GameObject.Find("CharacterSelect").GetComponent<Animation>();

		

	}

	// Use this for initialization
	/*void Start () {
		ARInstructions = GameObject.Find("ARInstructions");
		Header = GameObject.Find("Header");
		TitleInfo = GameObject.Find("Titleinfo");

		TriggerSpecsBtn = GameObject.Find("TriggerSpecs_btn");
		EmailButton = GameObject.Find("TriggerContact_btn");
		POIPanel = GameObject.Find("POI");
		SpecsPanel = GameObject.Find("Specs");
		EmailPanel = GameObject.Find("Contact");
		SkinSelectPanel = GameObject.Find("SkinSelect");

	
	}*/

	void Start(){
		//Popup_Fact.SetActive(false);
		Title_Hotspot.SetActive(false);
		Button_Back.SetActive(false);
		SharkHotspots.SetActive(false);
		TurtleHotspots.SetActive(false);
		//Dropdown.SetActive(false);

		TurtleModel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		//If exit (android back) button is pushed, quit
		if (Input.GetKeyDown(KeyCode.Escape)){
   			Application.Quit(); 
		}

		if(currentlyTracking){
			ToggleInstructions(false);
			if(currentScreen==1){
				SMC.SetCanMove(true);
			}
			else{
				SMC.SetCanMove(false);
			}
		}

		else{
			if(currentScreen==1){
				ToggleInstructions(true);
			}
		}
	
	}

	public void TriggerTransition(int transitionNumber){
		//Swap from main to experience screen
		if(transitionNumber==0){
			if(dropdownMainOpen){
				anim = ActiveAnimation.Play(dropdownmenu_mainTween, "", Direction.Reverse,EnableCondition.DoNothing,DisableCondition.DoNotDisable);
				dropdownMainOpen = false;
			}
			screenTransition(1);
		}

		//Start the hotspot view
		else if(transitionNumber==1){
			ToggleHotspots(true);
			currentScreen=2;
			SMC.SetCanMove(false);
		}

		//Exit hotspot view
		else if(transitionNumber==2){
			ToggleHotspots(false);
			currentScreen=1;
		}

		// Close the fact overlay
		else if(transitionNumber==3){
			OpenPOI(1,false);
		}

		// Open the dropdown menu
		else if(transitionNumber==4){
			//OpenPOI(1,false);
			anim = ActiveAnimation.Play(dropdownmenuTween, "", Direction.Toggle,EnableCondition.DoNothing,DisableCondition.DoNotDisable);
			dropdownOpen = !dropdownOpen;

		}

		// Open the dropdown menu on main screen
		else if(transitionNumber==5){
			anim = ActiveAnimation.Play(dropdownmenu_mainTween, "", Direction.Toggle,EnableCondition.DoNothing,DisableCondition.DoNotDisable);
			dropdownMainOpen = !dropdownMainOpen;
			//OpenPOI(1,false);
		}

		// Back to the main menu
		else if(transitionNumber==6){

			CharacterSelectShark.SetActive(true);
			CharacterSelectTurtle.SetActive(true);
			//OpenPOI(1,false);
			anim = ActiveAnimation.Play(dropdownmenuTween, "", Direction.Reverse,EnableCondition.DoNothing,DisableCondition.DoNotDisable);
			dropdownOpen = false;
			screenTransition(0);


		}

		// Go to sealife page
		else if(transitionNumber==7){
			//OpenPOI(1,false);
			OpenSealifePage();
		}

		// Close App
		else if(transitionNumber==8){
			//OpenPOI(1,false);
			Debug.Log("QUIT");
			Application.Quit();
		}
	}

	public void screenTransition(int toScreen){

		if(toScreen==1){

			currentScreen = 1;

			CM.SharkCameraToggle(false);
			CM.ARCameraToggle(false);

			anim = ActiveAnimation.Play(screenTween1, "", Direction.Forward,EnableCondition.DoNothing,DisableCondition.DoNotDisable);
			anim = ActiveAnimation.Play(screenTween2, "", Direction.Forward,EnableCondition.DoNothing,DisableCondition.DoNotDisable);
		}

		else if(toScreen==0){
			currentScreen = 0;

			CM.SharkCameraToggle(false);
			CM.ARCameraToggle(false);

			anim = ActiveAnimation.Play(screenTween1, "", Direction.Reverse,EnableCondition.DoNothing,DisableCondition.DoNotDisable);
			anim = ActiveAnimation.Play(screenTween2, "", Direction.Reverse,EnableCondition.DoNothing,DisableCondition.DoNotDisable);
		}
	}

	public void swapCharacter(int dir){
		//Right Button
		if(dir==1){

			Debug.Log("Pushed the left button");
			anim = ActiveAnimation.Play(animalSwapTween, "", Direction.Toggle,EnableCondition.DoNothing,DisableCondition.DoNotDisable);


		}

		else{
			Debug.Log("Pushed the right button");
			anim = ActiveAnimation.Play(animalSwapTween, "", Direction.Toggle,EnableCondition.DoNothing,DisableCondition.DoNotDisable);

		}

		currentAnimal++;
		if(currentAnimal>1){
			currentAnimal=0;
		}

		SelectCharacterModel(currentAnimal);

	}

	public void SelectCharacterModel(int characterNumber){
		if(currentScreen!=2){
		

		if(currentAnimal!=characterNumber){
			CharacterSelectShark.SetActive(false);
			CharacterSelectTurtle.SetActive(false);
			anim = ActiveAnimation.Play(animalSwapTween, "", Direction.Toggle,EnableCondition.DoNothing,DisableCondition.DoNotDisable);
		}
		currentAnimal = characterNumber;

		//If shark selected
		if(currentAnimal==0){
			SharkModel.SetActive(true);
			TurtleModel.SetActive(false);
			animalName_Lbl.text = "Reef Shark";
		}

		//If Turtle
		if(currentAnimal==1){
			SharkModel.SetActive(false);
			TurtleModel.SetActive(true);
			animalName_Lbl.text = "Green Sea Turtle";
		}

		CM.ChangeAnimal(currentAnimal);

		Debug.Log("currentAnimal: " + currentAnimal);
		}
	}

	public void ToggleInstructions(bool on){
		if(currentScreen==1){

		TrackingHint.SetActive(on);

		CM.ARCameraToggle(!on);
		//SharkParent.SetActive(!on);
		}
	}

	public void ToggleHotspots(bool on){

		Button_FactFinder.SetActive(!on);

		Title_Hotspot.SetActive(on);
		Button_Back.SetActive(on);
		Button_Menu.SetActive(!on);

		FactCameraTransition(on);

		//If Turning the hospots on
		if(on){
			//If the dropdown is open
			if(dropdownOpen){

				//Close the dropdown
				anim = ActiveAnimation.Play(dropdownmenuTween, "", Direction.Reverse,EnableCondition.DoNothing,DisableCondition.DoNotDisable);
				dropdownOpen = false;
			}

		}
	}

	private void FactCameraTransition(bool zoomIn){

		// If Shark
		if(currentAnimal==0){
			SharkHotspots.SetActive(zoomIn);

			if(zoomIn){
				TrackingHint.SetActive(false);
				//SAM.ChangeAnim(2);
			}

			else{
				//SAM.ChangeAnim(0);
			}
		}

		// If Turtle
		else if(currentAnimal==1){
			TurtleHotspots.SetActive(zoomIn);

			if(zoomIn){
				TrackingHint.SetActive(false);
				//TAM.ChangeAnim(2);
			}

			else{
				//TAM.ChangeAnim(0);
			}
		}


		
		CM.SharkCameraToggle(zoomIn);
		CM.ARCameraToggle(!zoomIn);

		

	}


	public void TogglePOI(bool on){ 
		Debug.Log("FACT PANEL:" + on);
		//POI1.SetActive(on);
		//currentAnimation = POI1.GetComponent<Animation>();
		//currentAnimation.Play();
		if(on){
			anim = ActiveAnimation.Play(factPanelTween, "", Direction.Forward,EnableCondition.DoNothing,DisableCondition.DoNotDisable);

			//Popup_Fact.SetActive(true);
			// CM.SharkCameraToggle(false);

			Button_Back.SetActive(false);
			Title_Hotspot.SetActive(false);
			Button_Menu.SetActive(false);
			//SharkParent.SetActive(false);
			//anim = ActiveAnimation.Play(currentAnimation, "", Direction.Forward,EnableCondition.DoNothing,DisableCondition.DoNotDisable);
			//anim = ActiveAnimation.Play(currentAnimation, "", Direction.Toggle,EnableCondition.DoNothing,DisableCondition.DoNotDisable);
		}

		else{
			anim = ActiveAnimation.Play(factPanelTween, "", Direction.Reverse,EnableCondition.DoNothing,DisableCondition.DoNotDisable);

			//Popup_Fact.SetActive(false);
			// CM.SharkCameraToggle(true);

			Button_Back.SetActive(true);
			Title_Hotspot.SetActive(true);
			//Button_Menu.SetActive(true);
			//SharkParent.SetActive(true);
			//anim = ActiveAnimation.Play(currentAnimation, "", Direction.Reverse,EnableCondition.DoNothing,DisableCondition.DoNotDisable);
		}
	}

	public void OpenPOI(int POInumber, bool willOpen){

		if((!willOpen) || (willOpen && !isPopupOpen)){

			lastPopupOpen = POInumber;

			TogglePOI(willOpen);
					if(willOpen){
						FM.SetFactText(currentAnimal,POInumber);
					}

			isPopupOpen = willOpen;

		}
	}

	public void SetCurrentlyTracking(bool tracking){
		currentlyTracking = tracking;

	}

	public void OpenSealifePage ()
	{	 
	 Application.OpenURL("http://www.visitsealife.com");
	}
	 
}
