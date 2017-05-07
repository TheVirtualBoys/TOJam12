using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionDisplay : MonoBehaviour {

	public IngredientUI item = null;

	public void SetIngredient(Ingredient ingredient)
	{
		this.item.ClearAndInstantiateCell(ingredient);
	}

}
