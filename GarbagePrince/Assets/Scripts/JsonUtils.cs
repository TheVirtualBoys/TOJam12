using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public static class JsonUtils
{
	public static List<string> ToArrayString(this JsonData data)
	{
		if (!data.IsArray) return null;
		List<string> retval = new List<string>();
		for (int i = 0; i < data.Count; ++i) {
			retval.Add((string)data[i]);
		}
		return retval;
	}

	public static bool Contains(this JsonData data, string key)
	{
		return data.EnsureDictionary().Contains(key);
	}
}
