using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combotron : MonoBehaviour {

	public IngredientUI item1        = null;
	public IngredientUI item2        = null;
	public IngredientUI combinedItem = null;
	public Animator combineItemAnim  = null;
	public static Ingredient newItem = null;

	// try and add an ingredient
	public bool AddIngredient(Ingredient item)
	{
		if (item1.data == null) {
			item1.data = item;
			item1.ClearAndInstantiateCell(item);
		} else if (item2.data == null) {
			item2.data = item;
			item2.ClearAndInstantiateCell(item2.data);
		} else {
			// play a bad sound
			return false;
		}
		return true;
	}

	public bool IsSelected(Ingredient item)
	{
		return (item1.data != null && item1.data.prefabName == item.prefabName) ||
		       (item2.data != null && item2.data.prefabName == item.prefabName);
	}

	public bool RemoveIngredient(IngredientUI item)
	{
		if (item1 == item) {
			item.data = null;
			item.ClearCell();
		} else if (item2 != null && item2 == item) {
			item2.data = null;
			item2.ClearCell();
		} else {
			return false;
		}
		return true;
	}

	public Ingredient Combine()
	{
		if (this.item1 == null || this.item2 == null) return null;
		newItem = null;

		// logic to combine ingredients
		int tier = Mathf.Max(this.item1.data.tier, this.item2.data.tier);
		List<Ingredient> nextTier = StaticData.Instance.IngredientTier(tier);
		for (int i = 0; i < nextTier.Count; ++i) {
			if (nextTier[i].blueprint.Contains(this.item1.data.prefabName) && nextTier[i].blueprint.Contains(this.item2.data.prefabName)) {
				newItem = nextTier[i];
				break;
			}
		}

		if (newItem == null) {
			newItem = nextTier[nextTier.Count - 1];
		}

		this.RemoveIngredient(item1);
		this.RemoveIngredient(item2);
		return newItem;
	}

	public void StartCombineAnimation()
	{
		Ingredient ingredient = Combine();
		this.combinedItem.ClearAndInstantiateCell(ingredient);
		this.combineItemAnim.SetTrigger("RevealItem");
	}

	public void EndCombineAnimation()
	{
		
	}

	public void RevealNewIngredient(Ingredient ingredient)
	{
		// get art data from ingredient and unwrap/display it nice and big.
	}

}
