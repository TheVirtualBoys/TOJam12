using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class StaticData : MonoBehaviour
{
	private static StaticData staticData       = null;
	private List<string> categories            = null;
	private List<List<Ingredient>> ingredients = null; // first index is tier.

	public void Start()
	{
		if (!staticData) {
			GameObject.DontDestroyOnLoad(this);
			staticData = this;
		} else {
			GameObject.Destroy(this);
			return;
		}
		string json = System.IO.File.ReadAllText(System.IO.Path.Combine(Application.dataPath, "Data.json"));
		JsonData data = JsonMapper.ToObject(json);

		// load categories
		this.categories = new List<string>();
		this.categories = data["categories"].ToArrayString();

		// load ingredients by [tier][ingredient]
		this.ingredients = new List<List<Ingredient>>();
		for (int i = 0 ; i < data["ingredients"].Count; ++i) {
			this.ingredients.Add(new List<Ingredient>(data["ingredients"].Count));
			for (int j = 0; j < data["ingredients"][i].Count; ++j) {
				this.ingredients[i].Add(new Ingredient(data["ingredients"][i][j]));
			}
		}
	}

	public static StaticData GetData()
	{
		if (staticData)
			return staticData;
		return null;
	}

	public List<Ingredient> IngredientTier(int tier)
	{
		if (tier >= 0 && tier < this.ingredients.Count) {
			return this.ingredients[tier];
		}
		return null;
	}

	public Ingredient GetIngredient(string name)
	{
		for (int i = 0; i < this.ingredients.Count; ++i) {
			for (int j = 0; j < this.ingredients[i].Count; ++j) {
				if (this.ingredients[i][j].ingredientName == name) {
					return this.ingredients[i][j];
				}
			}
		}
		return null;
	}
}