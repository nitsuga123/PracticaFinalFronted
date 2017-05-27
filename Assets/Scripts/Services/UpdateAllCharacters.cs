using System;
using System.ComponentModel;
using System.Collections.Generic;

[Serializable]
[Description ("get_characters")]
public class UpdateAllCharacters {

	public Characters.CharacterData character_purchased;
	public int character_id;
	public UpdateAllCharacters (Characters.CharacterData character_purchased, int character_id)
	{
		this.character_purchased =  character_purchased;
		this.character_id = character_id;
	}

}
