using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combotron : MonoBehaviour {

	public Transform parentItem1 = null;
	public Transform parentItem2 = null;
	Ingredient item1            = null;
	Ingredient item2            = null;

	// try and add an ingredient
	public bool AddIngredient(Ingredient item)
	{
		if (item1 == null) {
			item1 = item;
			IngredientGrid.ClearAndInstantiateCell(this.parentItem1.transform, item1);
		} else if (item2 == null) {
			item2 = item;
			IngredientGrid.ClearAndInstantiateCell(this.parentItem2.transform, item2);
		} else {
			// play a bad sound
			return false;
		}
		return true;
	}

	public bool RemoveIngredient(Ingredient item)
	{
		if (item1.prefabName == item.prefabName) {
			item1 = null;
			GameObject.Destroy(parentItem1.transform.GetChild(0).gameObject);
		} else if (item2.prefabName == item.prefabName) {
			item2 = null;
			GameObject.Destroy(parentItem2.transform.GetChild(0).gameObject);
		} else {
			return false;
		}
		return true;
	}

	public Ingredient Combine()
	{
		if (this.item1 == null || item2 == null) return null;
		// todo: logic to combine ingredients
		return null;
	}

	public void StartCombineAnimation()
	{

	}

	public void EndCombineAnimation()
	{

	}

	public void RevealNewIngredient(Ingredient ingredient)
	{
		// get art data from ingredient and unwrap/display it nice and big.
	}

}
