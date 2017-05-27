using System;
using System.Collections.Generic;
using Characters;

namespace CharacterSelection
{
	[Serializable]
	public class Team 
	{
		public List<CharacterData> characters;

		public Team ()
		{
			characters = new List<CharacterData> ();
		}

		public void AddCharacter (CharacterData character)
		{
			characters.Add (character);
		}

		public void RemoveCharacter (CharacterData character)
		{
			characters.Remove (character);
		}
	}
}