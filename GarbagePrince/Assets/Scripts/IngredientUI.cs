using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientUI : MonoBehaviour {

	private static Combotron combotron = null;
	public Ingredient data = null;
	private bool selected = false;

	public void Start() {
		if (combotron == null) {
			combotron = GameObject.Find("ItemHolder").GetComponent<Combotron>();
		}
	}

	public void Clicked()
	{
		if (!this.selected) {
			// try to select it
			if (combotron.AddIngredient(this.data)) {
				this.selected = true;
			}
		} else {
			// try to deselect it.
			if (combotron.RemoveIngredient(this.data)) {
				this.selected = false;
			}
		}
	}
}
