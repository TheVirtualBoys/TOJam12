using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combotron : MonoBehaviour {

	public IngredientUI item1                 = null;
	public IngredientUI item2                 = null;
	public IngredientUI combinedItem          = null;
	public Animator combineItemAnim           = null;
	public static Ingredient newItem          = null;
	public UnityEngine.UI.Text revealItemText = null;

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
		if (item == null) return false;
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
		int tier = Mathf.Min(Mathf.Max(this.item1.data.tier, this.item2.data.tier), 4);
		List<Ingredient> nextTier = StaticData.Instance.IngredientTier(tier);
		if (this.item1.data.categories.Contains("Chicken") ||
		    this.item2.data.categories.Contains("Chicken")) {
			newItem = nextTier[nextTier.Count - 1];
		} else {
			for (int i = 0; i < nextTier.Count; ++i) {
				if (nextTier[i].blueprint != null && nextTier[i].blueprint.Count == 2 &&
					((nextTier[i].blueprint[0] == this.item1.data.prefabName &&
					 nextTier[i].blueprint[1] == this.item2.data.prefabName) ||
					(nextTier[i].blueprint[0] == this.item2.data.prefabName &&
					 nextTier[i].blueprint[1] == this.item1.data.prefabName))) {
					newItem = nextTier[i];
					break;
				}
			}
		}

		if (newItem == null) {
			newItem = nextTier[Random.Range(0, nextTier.Count)];
		}

		this.revealItemText.text = newItem.ingredientName;
		this.RemoveIngredient(item1);
		this.RemoveIngredient(item2);
		IngredientGrid.RefreshSelectedStates();
		return newItem;
	}

	public void StartCombineAnimation()
	{
		Ingredient ingredient = Combine();
		this.combinedItem.ClearAndInstantiateCell(ingredient);
		this.combineItemAnim.SetTrigger("RevealItem");
	}
}
