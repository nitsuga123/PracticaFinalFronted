using System;
using System.ComponentModel;
using System.Collections.Generic;

[Serializable]
[Description ("disable_character")]
public class DisableCharacter {

	public bool is_active;
	public int character_id;
	public DisableCharacter (bool is_active, int character_id)
	{
		this.is_active = is_active;
		this.character_id = character_id;
	}

}
