using Global;

namespace Model
{
    /// <summary>
    /// 玩家外部数值扩展类
    /// 1、玩家资产
    /// 2、玩家等级相关
    /// </summary>
    public class Model_PlayerExternalData{
        public static event playerExternalDataEventHandler playerExternalDataEvent;

        private int _level;
        private int _experience;
        private int _energy;
        private int _gold;
        private int _diamond;
        private int _maxExperience;
        private int _maxEnergy;

        #region 属性
        public int Level {
            get {
                return _level;
            }

            set {
                int old = _level;
                _level = value;

                if(playerExternalDataEvent != null)
                {
                    KeyValueUpdate kvu = new KeyValueUpdate("Level", Level);
                    playerExternalDataEvent(kvu);

                    if (old < _level)
                    {
                        KeyValueUpdate newKvu = new KeyValueUpdate("LevelUp", Level);
                        playerExternalDataEvent(newKvu);
                    }
                }
            }
        }

        public int Experience {
            get {
                return _experience;
            }

            set {
                _experience = value;

                if (playerExternalDataEvent != null)
                {
                    KeyValueUpdate kvu = new KeyValueUpdate("Experience", Experience);
                    playerExternalDataEvent(kvu);
                }
            }
        }

        public int Energy {
            get {
                return _energy;
            }

            set {
                _energy = value;

                if (playerExternalDataEvent != null)
                {
                    KeyValueUpdate kvu = new KeyValueUpdate("Energy", Energy);
                    playerExternalDataEvent(kvu);
                }
            }
        }

        public int Gold {
            get {
                return _gold;
            }

            set {
                _gold = value;

                if (playerExternalDataEvent != null)
                {
                    KeyValueUpdate kvu = new KeyValueUpdate("Gold", Gold);
                    playerExternalDataEvent(kvu);
                }
            }
        }

        public int Diamond {
            get {
                return _diamond;
            }

            set {
                _diamond = value;

                if (playerExternalDataEvent != null)
                {
                    KeyValueUpdate kvu = new KeyValueUpdate("Diamond", Diamond);
                    playerExternalDataEvent(kvu);
                }
            }
        }

        public int MaxExperience {
            get {
                return _maxExperience;
            }

            set {
                _maxExperience = value;

                if (playerExternalDataEvent != null)
                {
                    KeyValueUpdate kvu = new KeyValueUpdate("MaxExperience", MaxExperience);
                    playerExternalDataEvent(kvu);
                }
            }
        }

        public int MaxEnergy {
            get {
                return _maxEnergy;
            }

            set {
                _maxEnergy = value;

                if(playerExternalDataEvent != null)
                {
                    KeyValueUpdate kvu = new KeyValueUpdate("MaxEnergy",MaxEnergy);
                    playerExternalDataEvent(kvu);
                }
            }
        }
        #endregion

        public Model_PlayerExternalData() { }

        public Model_PlayerExternalData(int level,int exp,int energy, int gold,int diamond,int maxExp,int maxEnergy) {
            _level = level;
            _experience = exp;
            _energy = energy;
            _gold = gold;
            _diamond = diamond;
            _maxEnergy = maxEnergy;
            _maxExperience = maxExp;
        }
    }

}


