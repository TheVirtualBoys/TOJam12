using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientGrid : MonoBehaviour {

	public Transform gridParent = null;
	public Combotron combotron = null;
	private int ingredientCount = 0;

	public void Start()
	{
		this.InitGrid();
	}

	public IngredientUI AddIngredient(Ingredient data)
	{
		// create new ingredientui and add it to the gridview
		Transform cell = this.gridParent.GetChild(this.ingredientCount++);
		return ClearAndInstantiateCell(cell, data);
	}

	public void InitGrid()
	{
		this.ingredientCount = 0;
		// always populate with all tier 1 ingredients
		List<Ingredient> tier = StaticData.Instance.IngredientTier(0);
		for (int i = 0; i < tier.Count; ++i) {
			this.AddIngredient(tier[i]);
		}
	}

	public static IngredientUI ClearAndInstantiateCell(Transform parent, Ingredient ingredient)
	{
		if (parent.childCount > 0) {
			GameObject.Destroy(parent.GetChild(0));
		}
		IngredientUI prefab = Resources.Load<IngredientUI>(ingredient.prefabName);
		IngredientUI obj = Instantiate<IngredientUI>(prefab, parent);
		obj.data = ingredient;
		return obj;
	}
}
