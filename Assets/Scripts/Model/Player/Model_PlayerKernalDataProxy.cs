using UnityEngine;

namespace Model {
    /// <summary>
    /// 玩家战斗数值代理类
    /// 1、生成数据
    /// 2、数据计算
    /// </summary>
    public class Model_PlayerKernalDataProxy : Model_PlayerKernalData
    {
        //敌人造成的最小伤害
        public const int ENEMY_MIN_ATK = 1;
        private static Model_PlayerKernalDataProxy _instance = null;

        public Model_PlayerKernalDataProxy(float health, float magic, float ATK, float DEF, float maxHealth,
            float maxMagic, float ATKByProp, float DEFByProp)
        : base(health, magic, ATK, DEF, maxHealth, maxMagic, ATKByProp, DEFByProp)
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Debug.LogError(GetType() + "'PlayerKernalDataProxy'不允许构造函数重复实例化");
            }
        }

        public static Model_PlayerKernalDataProxy GetInstance()
        {
            if (_instance != null)
                return _instance;
            else
            {
                Debug.LogWarning("请先调用当前构造函数");
                return null;
            }
        }


        #region 生命值
        public void DecreaseHealthValue(float enemyAttackValue)
        {
            //公式：Health  = Health - (敌人攻击力 - 主角防御力 - 主角装备防御力)

            //敌人造成的真实伤害：敌人攻击力 - 主角防御力 - 主角装备防御力
            var enemyReallyATK = enemyAttackValue - Defence - DefenceByPro;
            //避免玩家防御过高而敌人无法造成伤害
            enemyReallyATK = enemyReallyATK > 0 ? enemyReallyATK : ENEMY_MIN_ATK;
            //如果造成的伤害大于生命值，生命值降为0
            Health = Health - enemyReallyATK > 0 ? Mathf.RoundToInt(Health - enemyReallyATK) : 0;
        }

        public void IncreaseHealthValue(float healthValue)
        {
            //避免healthValue为负值，造成加血变成减血
            var resHealth = Health + Mathf.Abs(healthValue);
            //避免血量超出最大值
            resHealth = resHealth < MaxHealth ? resHealth : MaxHealth;
            //resHealth +了一个float，所以需要将resHealth转为int
            Health = Mathf.RoundToInt(resHealth);
        }


        public float GetCurrentHealth()
        {
            return Health;
        }

        public void IncreaseMaxHealth(float increaseValue)
        {
            MaxHealth = Mathf.RoundToInt(MaxHealth + Mathf.Abs(increaseValue));
        }

        public float GetMaxHealth()
        {
            return MaxHealth;
        }
        #endregion

        #region 魔法值
        public void DecreaseMagicValue(float magicValue)
        {
            //公式：Magic = Magic - 释放一次技能的消耗(magicValue)
            var resMagic = Magic - Mathf.Abs(magicValue);
            resMagic = resMagic > 0 ? resMagic : 0;
            Magic = Mathf.RoundToInt(resMagic);
        }

        public void IncreaseMagicValue(float magicValue)
        {
            var resMagic = Magic + magicValue;
            resMagic = resMagic < MaxMagic ? resMagic : MaxMagic;
            Magic = resMagic;

        }

        public float GetCurrentMagic()
        {
            return Magic;
        }

        public void IncreaseMaxMagic(float increaseValue)
        {
            MaxMagic = Mathf.RoundToInt(MaxMagic + Mathf.Abs(increaseValue));
        }

        public float GetMaxMagic()
        {
            return MaxMagic;
        }

        #endregion

        #region 攻击力
        public void UpdateATKValue(float newWeaponATK = 0)
        {
            AttackByPro = newWeaponATK > 0 ? newWeaponATK : 0;

            Attack += Mathf.RoundToInt(AttackByPro);
        }

        public float GetCurrentATK()
        {
            return Attack;
        }

        public void IncreaseATK(float increaseValue)
        {
            Attack += Mathf.RoundToInt(increaseValue);
        }
        #endregion

        #region 防御力
        public void UpdateDEFValue(float newArmorDEFValue = 0)
        {
            DefenceByPro = newArmorDEFValue > 0 ? newArmorDEFValue : 0;

            Defence += Mathf.RoundToInt(DefenceByPro);
        }

        public float GetCurrentDEF()
        {
            return Defence;
        }

        public void IncreaseDEF(float increaseValue)
        {
            Defence += Mathf.RoundToInt(increaseValue);
        }
        #endregion

        public void DisplayAllOriginalValue()
        {
            Health = Health;
            Magic = Magic;
            Attack = Attack;
            Defence = Defence;
            DefenceByPro = DefenceByPro;
            AttackByPro = AttackByPro;
        }
    }
}


