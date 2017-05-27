using System;
using System.ComponentModel;
using System.Collections.Generic;

[Serializable]
[Description ("team/change")]
public class ChangeTeam 
{
	public int characterId_1;
	public int characterId_2;
	public int characterId_3;
	public int gold;

	public ChangeTeam (int characterId_1, int characterId_2, int characterId_3, int gold)
	{
		this.characterId_1 = characterId_1;
		this.characterId_2 = characterId_2;
		this.characterId_3 = characterId_3;
		this.gold = gold;
	}
}
