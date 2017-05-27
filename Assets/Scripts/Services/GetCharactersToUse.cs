using System;
using System.ComponentModel;
using System.Collections.Generic;

[Serializable]
[Description ("get_characters")]
public class GetCharactersToUse
{
	public int character_id;
	public bool is_active;

	public GetCharactersToUse (int character_id, bool is_active)
	{
		this.character_id = character_id;
		this.is_active = is_active;
	}
}
