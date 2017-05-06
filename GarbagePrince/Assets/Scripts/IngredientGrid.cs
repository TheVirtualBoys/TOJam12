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
		IngredientUI cell = this.gridParent.GetChild(this.ingredientCount++).GetComponent<IngredientUI>();
		cell.ClearAndInstantiateCell(data);
		return cell;
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
}
