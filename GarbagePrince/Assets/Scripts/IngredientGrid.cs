using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientGrid : MonoBehaviour {

	public int ingredientCount = 0;

	public void AddIngredient(Ingredient data)
	{
		// create new ingredientui and add it to the gridview
	}

	public void InitGrid()
	{
		// always populate with all tier 1 ingredients
		List<Ingredient> tier = StaticData.Instance.IngredientTier(0);
		GameObject parent = GameObject.Find("Grid");
		for (int i = 0; i < parent.transform.childCount; ++i) {
			Transform child = parent.transform.GetChild(i);
			IngredientUI prefab = Resources.Load<IngredientUI>(tier[i].prefabName);
			Instantiate<IngredientUI>(prefab, child);
			this.ingredientCount++;
		}
	}
}
