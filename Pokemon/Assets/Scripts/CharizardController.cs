using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharizardController : MonoBehaviour {

	private Rigidbody rb;
	private Animation anim;
	//UI Buttons 
	public Button fire;
	public Button fly;
	//Button Pressed booleans
	public bool attack = false;
	public bool flight = false;

	public GameObject fireBall;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		anim = GetComponent<Animation> ();

		fire.onClick.AddListener (fireButtonDown);
		fly.onClick.AddListener (flyButtonDown);
		fireBall.transform.gameObject.SetActive (false);
	}

	IEnumerator Wait(){
		fireBall.transform.gameObject.SetActive (true);
		yield return new WaitForSeconds (1);
		fireBall.transform.gameObject.SetActive (false);
		attack = false;
	}

	void fireButtonDown(){
		attack = true;
		fire.GetComponent<Button> ().interactable = false;
		fly.GetComponent<Button> ().interactable = false;
		StartCoroutine (Wait ());
	}

	IEnumerator WaitHalf(){
		yield return new WaitForSeconds (3);
		flight = false;
	}

	void flyButtonDown(){
		flight = true;
		fly.GetComponent<Button> ().interactable = false;
		fire.GetComponent<Button> ().interactable = false;
		StartCoroutine (WaitHalf());
	}

	// Update is called once per frame
	void Update () {

		if (attack == true) {
			anim.Play ("Attack");
		} else if (flight == true) {
			anim.Play ("Fly");
		} else {
			anim.Play ("Idle");
			fire.GetComponent<Button> ().interactable = true;
			fly.GetComponent<Button> ().interactable = true;
			attack = false;
			flight = false;
		}

	}
}
