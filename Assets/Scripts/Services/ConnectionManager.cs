using UnityEngine;
using UnityRest;
using System.Collections.Generic;

namespace Services
{
	public class ConnectionManager : MonoBehaviour 
	{
		private UnityRestManager api;
		public static ConnectionManager instance;

		private void Awake()
		{
			DontDestroyOnLoad(this);
		}
		private void Start ()
		{
			instance = this;
			api = UnityRestManager.Instance;
		}

		private void Update () 
		{
			
		}

		public int GetUserInformation(int user_id) //
		{
			UserId.user_id = user_id.ToString();
			api.Get<LoginPlayer>().WithId(user_id.ToString()). OnResult<LoginPlayer>(ServicesFacade.Instance.Login).Send();
			return user_id;
		}
	
		public void GetTeam() //
		{
			//api.Get<Teams>().WithId(ServicesFacade.Instance.userId.ToString()). OnResult<Teams>(ServicesFacade.Instance.FetchTeam).Send();
		}

		public void GetAllCharacters()
		{
			api.Get<GetCharactersToUse>().WithId(UserId.user_id). OnResult<GetCharactersToUse>(ServicesFacade.Instance.FetchTeam).Send();
		}

		private void LogTeam (Teams team)
		{
			Debug.Log (team);
		}

		private void Log<T> (T post)
		{
			Debug.Log (post);
		}	
		public void UpdateTeam (int characterId_1, int characterId_2, int characterId_3, int gold, int user_id)
		{
			Teams team = new Teams (characterId_1,characterId_2,characterId_3, gold, user_id);
			api.Post<Teams> ().WithBody (team).OnResult (LogOk).Send ();
		}

		public void DisableCharacters(bool is_active, int character_id)
		{
			DisableCharacter disable_character = new DisableCharacter (is_active, character_id);
			api.Post<DisableCharacter> ().WithBody (disable_character).OnResult (LogOk).Send ();
		}

		public void UpdateCharacters (Characters.CharacterData character_purchased, int character_id)
		{
			UpdateAllCharacters new_characters = new UpdateAllCharacters (character_purchased, character_id);
			api.Post<UpdateAllCharacters> ().WithBody (new_characters).OnResult (LogOk).Send ();
		}

		public void PosteameEsta (int characterId_1, int characterId_2, int characterId_3, int gold)
		{
			ChangeTeam team = new ChangeTeam (characterId_1,characterId_2,characterId_3, gold);
			api.Post<ChangeTeam> ().WithBody (team).WithId(UserId.user_id).OnResult (LogOk).Send ();
		}

		private void LogOk ()
		{
			Debug.Log ("Ok");
		}
	}
}
