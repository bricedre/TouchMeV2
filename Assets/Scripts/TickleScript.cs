using UnityEngine;
using System.Collections;
using GestureWorksCoreNET;
using GestureWorksCoreNET.Unity;

public class TickleScript: TouchObject {
	
	public float threshold;
	public float value;
	public float touchyTrigger;
	public float pointsInfluence;
	public bool regenerative;
	public string parameter;
	private Animator animBody;
	private Animator animHead;
	public bool isHead;
	public string warning;
	public string sentence;

	private bool warningDone;
	private bool sentenceSaid;

	private AudioManager audioManager;
	private GameManager gameManager;
	
	void Start () {

		value = threshold;
		warningDone = false;
		sentenceSaid = false;

		animBody = GameObject.Find ("ToyBody").GetComponent<Animator>();
		animHead = GameObject.Find ("ToyHead").GetComponent<Animator>();
		audioManager = GameObject.Find ("AudioManager").GetComponent<AudioManager>();
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
	}

	void NDrag(GestureEvent gEvent){

		if(gEvent.Phase == GesturePhase.GESTURE_BEGIN)
			ChangeAnimation(true);

		//decreases value
		value -= 0.1f;

		if(gEvent.Phase == GesturePhase.GESTURE_RELEASE || gEvent.Phase == GesturePhase.GESTURE_END)
		   ChangeAnimation(false);

	}
	
	void Update () {

		if(value < 0.0f){

			//in both cases, sentence is played
			if(sentence != "" && !gameManager.speaking && !sentenceSaid){
				audioManager.playEvent(sentence);
				audioManager.wait (5);
				sentenceSaid = true;

				//it adds points to the points' pool
				gameManager.pointsPool += pointsInfluence;

				//If it's regenerative, a new one is done
				if(regenerative)
					RegenerateTickle();
			}

		}

		else if(value < touchyTrigger && value > touchyTrigger - 2.0f && warningDone == false){
			if(warning != "")
				if(!gameManager.speaking)
					audioManager.playEvent(warning);
			warningDone = true;
			audioManager.wait (3);
		}
	}


	public void ChangeAnimation(bool state){

		//Changing animation parameters
		if(isHead){
			animHead.SetBool(parameter, state);
		}

		else{
			animBody.SetBool(parameter, state);
		}
	}

	public void RegenerateTickle(){

		value = threshold;
		warningDone = false;
		sentenceSaid = false;
		ChangeAnimation(false);

	}
}