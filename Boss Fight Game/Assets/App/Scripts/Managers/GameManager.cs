using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BossFightGame.GameManager
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance { get => _instance;}      

        [Header("Character List")]
        [SerializeField] private List<CharacterDataSO> characterDataBase;
        public List<CharacterDataSO> CharacterDataBase { get => characterDataBase; }

        private void Awake()
        {
            DontDestroyOnLoad(this);

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


    }
}

