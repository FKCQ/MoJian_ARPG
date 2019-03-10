using Global;

namespace Model
{
    /// <summary>
    /// 玩家战斗数值
    /// </summary>
    public class Model_PlayerKernalData {
        public static event playerKernalDataEventHandler playerKernalEvent;

        private float _health;
        private float _magic;
        private float _attack;
        private float _defence;
        private float _maxHealth;
        private float _maxMagic;
        private float _attackByPro; 
        private float _defenceByPro;

        #region 属性

        public float Health {
            get {
                return _health;
            }

            set {
                _health = value;
            
                if(playerKernalEvent != null)
                {
                    KeyValueUpdate kvu = new KeyValueUpdate("Health", Health);
                    playerKernalEvent(kvu);
                }
            }
        }

        public float Magic {
            get {
                return _magic;
            }

            set {
                _magic = value;

                if (playerKernalEvent != null)
                {
                    KeyValueUpdate kvu = new KeyValueUpdate("Magic", Magic);
                    playerKernalEvent(kvu);
                }
            }
        }

        public float Defence {
            get {
                return _defence;
            }

            set {
                _defence = value;

                if (playerKernalEvent != null)
                {
                    KeyValueUpdate kvu = new KeyValueUpdate("Defence", Defence);
                    playerKernalEvent(kvu);
                }
            }
        }

        public float MaxHealth {
            get {
                return _maxHealth;
            }

            set {
                _maxHealth = value;

                if (playerKernalEvent != null)
                {
                    KeyValueUpdate kvu = new KeyValueUpdate("MaxHealth", MaxHealth);
                    playerKernalEvent(kvu);
                }
            }
        }

        public float MaxMagic {
            get {
                return _maxMagic;
            }

            set {
                _maxMagic = value;

                if (playerKernalEvent != null)
                {
                    KeyValueUpdate kvu = new KeyValueUpdate("MaxMagic", MaxMagic);
                    playerKernalEvent(kvu);
                }
            }
        }

        public float Attack {
            get {
                return _attack;
            }

            set {
                _attack = value;

                if (playerKernalEvent != null)
                {
                    KeyValueUpdate kvu = new KeyValueUpdate("Attack", Attack);
                    playerKernalEvent(kvu);
                }
            }
        }
        

        public float AttackByPro {
            get {
                return _attackByPro;
            }

            set {
                _attackByPro = value;

                if (playerKernalEvent != null)
                {
                    KeyValueUpdate kvu = new KeyValueUpdate("AttackByPro", AttackByPro);
                    playerKernalEvent(kvu);
                }
            }
        }

        public float DefenceByPro {
            get {
                return _defenceByPro;
            }

            set {
                _defenceByPro = value;

                if (playerKernalEvent != null)
                {
                    KeyValueUpdate kvu = new KeyValueUpdate("DefenceByPro", DefenceByPro);
                    playerKernalEvent(kvu);
                }
            }
        }


        #endregion

        public Model_PlayerKernalData() { }

        public Model_PlayerKernalData( float health,float magic, float attack,float defence,float maxHealth, 
            float maxMagic, float attackByPro, float defenceByPro)
        {
            _health = health;
            _magic = magic;
            _attack = attack;
            _defence = defence;
            _maxHealth = maxHealth;
            _attackByPro = attackByPro;
            _defenceByPro = defenceByPro;
        }
    }
}

