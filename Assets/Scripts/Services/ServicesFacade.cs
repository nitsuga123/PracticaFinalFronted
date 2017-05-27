using System;
using System.Collections.Generic;
using CharacterSelection;
using UnityEngine;
using UnityRest;

namespace Services
{
    public class ServicesFacade: MonoBehaviour
    {
        public Characters.CharacterCatalog catalog;
        private UnityRestManager api;
        public static ServicesFacade Instance
        {
            get; private set;
        }
        [HideInInspector]
        public static int userId;
        bool assignGold=false;
        private Action<int> changGoldMethod = null;
         bool assignData=false;
        private Action GetDataMethod = null;

        public List<Characters.CharacterData> characters_purchased = new List<Characters.CharacterData>();
        private void Awake ()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy (gameObject);
        }

        private void Start(){
        }

        private void FetchGold(int gold)
        {
            Players.Player.Instance.SetGold(gold);
        }

        public void Login (LoginPlayer[] user_data)
        {
            // TODO: Call login service using username, if successful invoke callback and set userId            
            int id = user_data[0].user_id;
           UserId.user_id = id.ToString();
            FetchGold(user_data[0].gold);
        }

        public void FetchTeam (GetCharactersToUse[] characters)
        {
            Team activeTeam = new Team();
            Team allCharacters = new Team();

            Characters.CharacterData[] active_characters = new Characters.CharacterData[3];

            List <Characters.CharacterData> parsedAllCharacters = new  List <Characters.CharacterData>();

            for( int user_character = 0 ; user_character< characters.Length; user_character++)
            {
                for( int catalog_character = 0 ; catalog_character< catalog.characters.Length; catalog_character++)
                {
                    if(characters[user_character].character_id == int.Parse(catalog.characters[catalog_character].id))
                    {
                        if(characters[user_character].is_active == true)
                        {
                            active_characters[user_character] = catalog.characters[catalog_character];
                            activeTeam.AddCharacter(active_characters[user_character]);
                        }
                        parsedAllCharacters.Add(catalog.characters[catalog_character]);
                        allCharacters.AddCharacter(parsedAllCharacters[user_character]);
                    }
                }
            }       
           
            GetAvailableCharacters(allCharacters);
            TeamManager.Instance.SetCurrentTeam(activeTeam);
            for( int i = 0 ; i < active_characters.Length; i++)
            {
                active_characters[i] = null;
            }
        }

        public void SaveTeam (Team team)
        {
            int id1 = int.Parse(team.characters[0].id);
            int id2 = int.Parse(team.characters[1].id);
            int id3 = int.Parse(team.characters[2].id);
            int newGold = Players.Player.Instance.Gold;

            ConnectionManager.instance.UpdateTeam(id1,id2,id3, newGold, int.Parse(UserId.user_id));
            
        }

        public void GetAvailableCharacters (Team team)//    9999999999 Characters
        {
            List<ObjectId> ids = new List<ObjectId>();
            for( int i =0 ; i< team.characters.Count; i++)
            {
                ids.Add(team.characters[i].id);
            }
            AvailableCharactersPanel.Instance.SetAvailableCharacters(ids);
        }

        public void PurchaseCharacter (ObjectId id)
        {
            // TODO: Call purchasing service.
        }
    }
}