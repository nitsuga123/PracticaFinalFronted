using System;
using System.ComponentModel;
using System.Collections.Generic;

[Serializable]
[Description ("team")]
public class Teams
{
	public int character_id_1;
	public int character_id_2;
	public int character_id_3;
	public int gold;
	public int player_id;

	public Teams (int characterId_1, int characterId_2, int characterId_3, int gold, int player_id)
	{
		this.character_id_1 = characterId_1;
		this.character_id_2 = characterId_2;
		this.character_id_3 = characterId_3;
		this.gold = gold;
		this.player_id = int.Parse(UserId.user_id);
	}
}
