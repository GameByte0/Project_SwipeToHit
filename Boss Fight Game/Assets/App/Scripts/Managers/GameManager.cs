using BossFightGame.Events;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BossFightGame.GameManager
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;//SINGLETONE
        public static GameManager Instance { get => _instance; } //SINGLETONE PROPERTY     

        [Header("Character List")]
        [SerializeField] private List<CharacterDataSO> characterDataBase;//All Characters' DB
        public List<CharacterDataSO> CharacterDataBase { get => characterDataBase; }//All Characters' DB PROPERTY


        private void OnEnable()
        {
            GameEvents.OnGameEndedEvent += OnGameEndedEventHandler;
        }
        private void OnDisable()
        {
            GameEvents.OnGameEndedEvent -= OnGameEndedEventHandler;
        }
        private void Awake()
        {
            DontDestroyOnLoad(this);

            Singletone();

            Time.timeScale = 1.0f;
        }

        private void Singletone()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(_instance.gameObject);
            }
            _instance = this;
        }

        public void StartGame()
        {
            SceneManager.LoadScene("GamePlay");
        }
        public CharacterDataSO GetCharacterData()
        {
            int index = PlayerPrefs.GetInt("SelectedCharacterIndex");
            return characterDataBase[index];
        }

        private void OnGameEndedEventHandler()
        {
            Time.timeScale= 0.1f;
        }


    }
}

