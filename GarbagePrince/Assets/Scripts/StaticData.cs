using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class StaticData : MonoBehaviour
{
	private static StaticData staticData       = null;
	private List<string> categories            = null;
	private List<List<Ingredient>> ingredients = null; // first index is tier.

	public void Awake()
	{
		if (!staticData) {
			GameObject.DontDestroyOnLoad(this);
			staticData = this;
		} else {
			GameObject.Destroy(this);
			return;
		}
		string json = Resources.Load<TextAsset>("Data").text;
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

	public static StaticData Instance
	{
		get {
			return staticData;
		}
	}

	public List<Ingredient> IngredientTier(int tier)
	{
		if (tier >= 0 && tier < this.ingredients.Count) {
			return this.ingredients[tier];
		}
		return null;
	}

	public Ingredient GetIngredient(string prefabName)
	{
		for (int i = 0; i < this.ingredients.Count; ++i) {
			for (int j = 0; j < this.ingredients[i].Count; ++j) {
				if (this.ingredients[i][j].prefabName == prefabName) {
					return this.ingredients[i][j];
				}
			}
		}
		return null;
	}
}