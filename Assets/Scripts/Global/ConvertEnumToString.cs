using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Global {
    public class ConvertEnumToString {
        private static ConvertEnumToString _instance;
        private Dictionary<Scenes, string> _scenesDic;

        private ConvertEnumToString()
        {
            _scenesDic = new Dictionary<Scenes, string>();
            _scenesDic.Add(Scenes.StartScene, "1_StartScene");
            _scenesDic.Add(Scenes.MainScene, "2_MainScene");
            _scenesDic.Add(Scenes.BattleScene, "3_BattleScene");
        }

        public static ConvertEnumToString GetInstance()
        {
            if(_instance == null)
            {
                _instance = new ConvertEnumToString();
            }
            return _instance;
        }

        public string GetStrByEnumScene(Scenes scene)
        {
            if(_scenesDic != null && _scenesDic.Count >= 1)
            {
                return _scenesDic[scene];
            }
            else
            {
                Debug.LogWarning("'GetStrByEnumScene'-scenesDic.count <= 0");
                return null;
            }
        }
    }
}


