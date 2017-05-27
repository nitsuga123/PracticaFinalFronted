using Characters;
using Services;
using UnityEngine;
using UnityRest;
using Utils;

namespace CharacterSelection
{
	public class TeamManager : MonoBehaviour
	{
		[SerializeField]
		private int size;
		[SerializeField]
		private GameObjectHorizontalLayout layout;
		private Team team;

		public static TeamManager Instance
		{
			get; private set;
		}

		private void Awake ()
		{
			Instance = this;
		}

		private void Start () 
		{
			ConnectionManager.instance.GetAllCharacters();
		}

		public void AddCharacter (CharacterData character)
		{
			if (team == null || team.characters.Count == size || HasSameCharacter (character.id)) return;
			team.AddCharacter (character);
			AddToLayout (character);
		}

        private bool HasSameCharacter(ObjectId id)
        {
			return team.characters.Find (character => character.id == id) != null;
        }

        public void RemoveCharacter (CharacterData character)
		{
			if (team == null || team.characters.Count == 0) return;
			team.RemoveCharacter (character);
			layout.Remove ((gameObject) => gameObject.GetComponent<SelectableCharacter> ().character.id == character.id);
		}

		public void SaveTeam ()
		{
			if (team == null && team.characters.Count != 3) {Debug.Log ("Can't saved"); return;}
				ServicesFacade.Instance.SaveTeam (team);
		}

		public void SetCurrentTeam (Team team)
		{
			this.team = team;
			foreach (CharacterData character in team.characters)
				AddToLayout (character);
		}

		private void AddToLayout(CharacterData character)
        {
            SelectableCharacter selectable = Instantiate<SelectableCharacter> (character.prefab, transform);
			selectable.character = character;
			layout.Add (selectable.gameObject);
        }
	}
}