using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckShuffle : MonoBehaviour {
	public GameObject[] identityDeck;
	private GameObject tempGO;

	//The X position of the first card placed (the one in the upper-left corner). Had to mark it static or it couldn't initialize firstCardTransform.
	static public float firstXPosition = -335;

	//The Y position of the first card placed (the one in the upper-left corner). Had to mark it static or it couldn't initialize firstCardTransform.
	static public float firstYPosition = 230;


	//How much each column will be placed to the right from the previous column.
	private float offsetX = 170; 

	//How much each row will be placed lower than the previous row.
	private float offsetY = -35;

	private Vector3 firstCardTransform = new Vector3(firstXPosition, firstYPosition, 0); // The transform of the first card placed.

	public TextAsset identityCardsCSV;


	// Use this for initialization
	void Start () {
		Shuffle ();
		PlaceCards ();
		ImportCards ();
	}
	
	public void Shuffle() {
		for (int i = 0; i < identityDeck.Length; i++) {
			int rnd = Random.Range (0, identityDeck.Length);

			//save a copy of a random identity card in a temporary Game Object
			tempGO = identityDeck [rnd];

			//Swap the nth card and the random card
			identityDeck [rnd] = identityDeck [i];
			identityDeck [i] = tempGO;
		}
	}

	public void PlaceCards () {
		
		for (int i = 0; i < identityDeck.Length; i++) {
			//set the first card's transform to firstCardTransform as defined above.
			identityDeck [i].transform.localPosition = firstCardTransform; //Important that this was localPosition and not position.

			//For the next card, we'll use the same transform except add the offset to the x value.
			firstCardTransform.x = firstCardTransform.x + offsetX;

			//After every card that's a multiple of four, the Y will change so that a new row begins and the X will go back to its original value so the next row lines up under the previous.
			if ((i % 4 == 0) && (i != 0)) {
				firstCardTransform.y = firstCardTransform.y + offsetY;
				firstCardTransform.x = firstXPosition;
			}

		}
	}

	public void ImportCards(){
		string csvString = identityCardsCSV.text; //this is the content as a string
		string[] identities = csvString.Split (','); //Splits the string into many strings (array elements) at each comma and puts them into a string array
		foreach (string identity in identities) {  //Loops over each string in the string array
			Debug.Log (identity);
		}
	}
}
