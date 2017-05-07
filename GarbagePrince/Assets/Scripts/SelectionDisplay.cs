using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionDisplay : MonoBehaviour {

	public IngredientUI item      = null;
	public Animator garbagePrince = null;

	public void SetIngredient(Ingredient ingredient)
	{
		this.item.ClearAndInstantiateCell(ingredient);
	}

	public void TriggerPrinceAnimation()
	{
		if (this.item.data.categories.Contains("Chicken")) {
			this.garbagePrince.SetTrigger("Fail");
		} else {
			this.garbagePrince.SetTrigger("Win");
		}
	}

}
