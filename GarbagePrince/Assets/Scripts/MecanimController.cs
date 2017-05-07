using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MecanimController : MonoBehaviour {

	private Animator animator                  = null;
	private static GameplayController gameplay = null;

	private void Start()
	{
		this.animator = this.GetComponent<Animator>();
		if (gameplay == null) {
			gameplay = GameObject.Find("Canvas").GetComponent<GameplayController>();
		}
	}

	/************
	 * Combotron
	 ***********/
	public void AddItemToGrid()
	{
		IngredientGrid.AddIngredient(Combotron.newItem);
	}
}
