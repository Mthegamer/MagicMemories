using UnityEngine;

public class ParticleFirer : MonoBehaviour {
	
	public ParticleSystem pSys;
	
	public void Start() {
		//pSys = this.gameObject.GetComponent<ParticleSystem>();
	}
	
	public void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			FireParticle();
		}
	}
	
	public void FireParticle(){
		if (pSys) {
			pSys.Play();
		} else {
			Debug.LogError("ParticleSystem reference not set.");
		}
	}
	
}

