using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionDisplay : MonoBehaviour {

	public GameplayController gameplay = null;
	public IngredientUI item           = null;
	public Animator garbagePrince      = null;

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
		this.StartCoroutine(this.AutoAdvance(3.0f));
	}

	public IEnumerator AutoAdvance(float delay)
	{
		yield return new WaitForSeconds(delay);
		this.gameplay.FinalPresentDoneDisplay();
	}

}
