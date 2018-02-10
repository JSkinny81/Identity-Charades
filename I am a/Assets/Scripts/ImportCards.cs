using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImportCards : MonoBehaviour {
	public TextAsset identityCardsCSV; //drop csv file here in Inspector

	//CURRENTLY MOVED ALL THIS INTO DECK SHUFFLE SCRIPT AND THIS SCRIPT IS NOT ATTACHED TO AN OBJECT IN THE SCENE!!!


	void Start() {
		string csvString = identityCardsCSV.text; //this is the content as a string
		string[] identities = csvString.Split (','); //Splits the string into many strings (array elements) at each comma and puts them into a string array
		foreach (string identity in identities) {  //Loops over each string in the string array
			Debug.Log (identity);
		} 
	}
}
