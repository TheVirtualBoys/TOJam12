using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MecanimController : MonoBehaviour {

	private Animator animator = null;

	private void Start()
	{
		this.animator = this.GetComponent<Animator>();
	}

	/*************
	 * Combotron
	 ************/
	public void AddItemToGrid()
	{
		IngredientGrid.AddIngredient(Combotron.newItem);
	}

}
