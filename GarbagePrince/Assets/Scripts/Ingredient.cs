using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{

	private string name;
	private int tier;
	private LitJson.JsonData categories; // gotta cast to string on use :(
	private LitJson.JsonData blueprint;
	public Animation anim;

	public void Deserialize(string json)
	{
		Deserialize(LitJson.JsonMapper.ToObject(json));
	}

	public void Deserialize(LitJson.JsonData data)
	{
		this.name = (string)data["name"];
		this.tier = (int)data["tier"];
		this.categories = data["categories"];
	}

}
