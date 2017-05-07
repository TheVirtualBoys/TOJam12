using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentSelect : MonoBehaviour {

	public Transform grid = null;

	private void Start() {
		for (int i = 1; i < this.transform.childCount; ++i) {
			IngredientUI ui = this.transform.GetChild(i).gameObject.GetComponent<IngredientUI>();
			Ingredient ing = this.grid.transform.GetChild(i + 5).gameObject.GetComponent<IngredientUI>().data;
			ui.ClearAndInstantiateCell(ing);
		}
	}

}
