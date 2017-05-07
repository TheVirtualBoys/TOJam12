using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientGrid : MonoBehaviour {

	public static Transform gridParent        = null;
	public static Combotron combotron         = null;
	public static GameplayController gameplay = null;
	private static int ingredientCount        = 0;

	public void Start()
	{
		gridParent = this.transform;
		if (combotron == null) {
			combotron = GameObject.Find("ItemHolder").GetComponent<Combotron>();
		}
		if (gameplay == null) {
			gameplay = GameObject.Find("Canvas").GetComponent<GameplayController>();
		}
		this.InitGrid();
	}

	public static IngredientUI AddIngredient(Ingredient data)
	{
		// create new ingredientui and add it to the gridview
		IngredientUI cell = gridParent.GetChild(ingredientCount++).GetComponent<IngredientUI>();
		cell.ClearAndInstantiateCell(data);
		if (ingredientCount == 12) {
			// we've got a full grid. It's time to decide.
			gameplay.OnFinalCombination();
		}
		return cell;
	}

	public void InitGrid()
	{
		ingredientCount = 0;
		// always populate with all tier 1 ingredients
		List<Ingredient> tier = StaticData.Instance.IngredientTier(0);
		for (int i = 0; i < tier.Count; ++i) {
			AddIngredient(tier[i]);
		}
	}
}
