using System;
using System.ComponentModel;
using System.Collections.Generic;

[Serializable]
[Description ("login")]
public class LoginPlayer
{
	public string name;
	public int gold;
	public int user_id;

	public LoginPlayer (string name, int gold, int user_id)
	{
		this.name = name;
		this.gold = gold;
		this.user_id = user_id;
	}
}
