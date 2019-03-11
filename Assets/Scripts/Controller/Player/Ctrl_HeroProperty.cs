using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;

namespace Controller {
    public class Ctrl_HeroProperty : MonoBehaviour
    {
        public static Ctrl_HeroProperty _instance;

        //玩家核心数值
        public float HP_Cur = 100f;
        public float HP_Max = 100f;
        public float MP_Cur = 100f;
        public float MP_Max = 100f;
        public float ATK = 10f;
        public float DEF = 5f;

        public float ATKByProp = 0f;
        public float DEFByProp = 0f;

        //玩家扩展数值 
        public int EXP = 0;
        public int MaxExp = 100;
        public int Level = 0;
        public int Energy = 150;
        public int MaxEnergy = 150;
        public int Gold = 0;
        public int Diamonds = 0;

        private void Awake()
        {
            _instance = this;
        }

        private void Start()
        {
            Model_PlayerKernalDataProxy playerKernalDataObject = new Model_PlayerKernalDataProxy(HP_Cur,MP_Cur,ATK,DEF,HP_Max,MP_Max,ATKByProp,DEFByProp);
            Model_PlayerExternalDataProxy playerExternalDataObject = new Model_PlayerExternalDataProxy(Level,EXP,Energy,Gold,Diamonds,MaxExp,MaxEnergy);
        }

        #region 生命值处理
        public void DecreaseHealthValue(float enemyAttackValue)
        {
            if (HP_Cur <= 0)
                return;

            if (enemyAttackValue > 0)
            {
                Model_PlayerKernalDataProxy.GetInstance().DecreaseHealthValue(enemyAttackValue);
            }
        }

        public void IncreaseHealthValue(float healthValue)
        {
            if (healthValue > 0)
            {
                Model_PlayerKernalDataProxy.GetInstance().IncreaseHealthValue(healthValue);
            }
        }

        public float GetCurrentHealth()
        {
            return Model_PlayerKernalDataProxy.GetInstance().GetCurrentHealth();
        }

        public void IncreaseMaxHealth(float increaseMaxHealth)
        {
            if (increaseMaxHealth > 0)
            {
                Model_PlayerKernalDataProxy.GetInstance().IncreaseMaxHealth(increaseMaxHealth);
            }
        }

        public float GetMaxHealth()
        {
            return Model_PlayerKernalDataProxy.GetInstance().GetMaxHealth();
        }
        #endregion

        #region 魔法值处理
        public void DecreaseMagicValue(float magicValue)
        {
            if (magicValue > 0)
            {
                Model_PlayerKernalDataProxy.GetInstance().DecreaseMagicValue(magicValue);
            }
        }

        public void IncreaseMagicValues(float MagicValue)
        {
            if (MagicValue > 0)
            {
                Model_PlayerKernalDataProxy.GetInstance().IncreaseMagicValue(MagicValue);
            }
        }

        public float GetCurrentMagic()
        {
            return Model_PlayerKernalDataProxy.GetInstance().GetCurrentMagic();
        }

        public void IncreaseMaxMagic(float increaseMagic)
        {
            if (increaseMagic > 0)
            {
                Model_PlayerKernalDataProxy.GetInstance().IncreaseMaxMagic(increaseMagic);
            }
        }

        public float GetMaxMagic()
        {
            return Model_PlayerKernalDataProxy.GetInstance().GetMaxMagic();
        }
        #endregion

        #region 攻击力处理
        public void UpdateATKValue(float newWeaponValue = 0)
        {
            Model_PlayerKernalDataProxy.GetInstance().UpdateATKValue(newWeaponValue);
        }

        public float GetCurrentATK()
        {
            return Model_PlayerKernalDataProxy.GetInstance().GetCurrentATK();
        }
        #endregion

        #region 防御力处理
        public void UpdateDEFValue(float newArmorDEFValue = 0)
        {
            Model_PlayerKernalDataProxy.GetInstance().UpdateDEFValue(newArmorDEFValue);
        }

        public float GetCurrentDEF()
        {
            return Model_PlayerKernalDataProxy.GetInstance().GetCurrentDEF();
        }

        #endregion

        #region 等级处理
        public void AddLevel()
        {
            Model_PlayerExternalDataProxy.GetInstance().AddLevel();
        }

        public int GetLevel()
        {
            return Model_PlayerExternalDataProxy.GetInstance().GetLevel();
        }
        #endregion

        #region 金币处理
        public void AddGold(int goldValue)
        {
            if(goldValue > 0)
            {
                Model_PlayerExternalDataProxy.GetInstance().AddGold(goldValue);
            }
        }

        public int GetGold()
        {
            return Model_PlayerExternalDataProxy.GetInstance().GetGold();
        }
        #endregion

        #region 钻石处理
        public void AddDiamond(int diamondValue)
        {
            if(diamondValue > 0)
            {
                Model_PlayerExternalDataProxy.GetInstance().AddDiamond(diamondValue);
            }
        }

        public int GetDiamond()
        {
            return Model_PlayerExternalDataProxy.GetInstance().GetDiamond();
        }
        #endregion

        //复活
        public void RecoverLife()
        {
            IncreaseHealthValue(GetMaxHealth());
            IncreaseMagicValues(GetMaxMagic());
        }
    }
}

