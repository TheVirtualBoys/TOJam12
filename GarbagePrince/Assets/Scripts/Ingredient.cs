using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient
{
	public string ingredientName { get; private set; }
	public string prefabName { get; private set; }
	public int tier { get; private set; }
	public List<string> categories { get; private set; } // gotta cast to string on use :(
	public List<string> blueprint { get; private set; }

	public Ingredient(LitJson.JsonData data)
	{
		this.ingredientName = (string)data["name"];
		this.prefabName     = (string)data["prefabName"];
		this.tier           = (int)data["tier"];
		this.categories     = data["categories"].ToArrayString();
		this.blueprint      = null;
		if (data.Contains("blueprint")) {
			this.blueprint = data["blueprint"].ToArrayString();
		}
	}

}
