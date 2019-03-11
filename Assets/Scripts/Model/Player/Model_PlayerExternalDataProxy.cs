using Global;
using UnityEngine;

namespace Model {
    /// <summary>
    /// 玩家外部数值扩展代理类
    ///     代码设计模式的应用。（本类必须设计为带有构造函数的单例模式）
    /// </summary>
    public class Model_PlayerExternalDataProxy : Model_PlayerExternalData
    {
        private static Model_PlayerExternalDataProxy _instance = null;

        public Model_PlayerExternalDataProxy() { }

        public Model_PlayerExternalDataProxy(int level, int exp, int energy, int gold, int diamond, int maxExp,int maxEnergy)
            : base(level,exp,energy,gold,diamond,maxExp,maxEnergy)

        {
            if (_instance == null)
                _instance = this;
            else
                Debug.Log("'playerExternalDataProxy'不允许构造函数重复实例化");
        }

        public static Model_PlayerExternalDataProxy GetInstance()
        {
            if (_instance != null)
                return _instance;
            else
            {
                Debug.LogWarning("请先调用当前构造函数，再使用GetInstance()");
                return null;
            }
        }

        #region 等级
        public void AddLevel()
        {
            Level++;
            Model_UpgradeRule.GetInstance().UpdradeOperation((LevelName)Level);
            //升级后将经验值清零
            DecreaseExp(MaxExperience);
        }

        public int GetLevel()
        {
            return Level;
        }
        #endregion

        #region 经验值
        public void IncreaseExp(int increaseValue)
        {
            Experience += Mathf.Abs(increaseValue);
            Model_UpgradeRule.GetInstance().UpgradeCondition(Experience);
        }

        public void DecreaseExp(int decreaseValue)
        {
            Experience -= Mathf.Abs(decreaseValue);
        }
        public int GetExp()
        {
            return Experience;
        }
        #endregion

        #region 最大经验值（升级需要的总经验）
        public void AddMaxExp(int addValue)
        {
            MaxExperience += Mathf.Abs(addValue);
        }

        public int GetMaxExp()
        {
            return MaxExperience;
        }

        #endregion

        #region 金币
        public void AddGold(int addValue)
        {
            Gold += Mathf.Abs(addValue);
        }

        /// <summary>
        /// 使用金币，金币足够返回true，不够返回false
        /// </summary>
        /// <param name="subValue"></param>
        /// <returns></returns>
        public bool SubGold(int subValue)
        {
            if(Gold - Mathf.Abs(subValue) >= 0)
            {
                Gold -= Mathf.Abs(subValue);
                return true;
            }
            return false;
        }

        public int GetGold()
        {
            return Gold;
        }
        #endregion

        #region 钻石
        public void AddDiamond(int addValue)
        {
            Diamond += Mathf.Abs(addValue);
        }

        /// <summary>
        /// 使用钻石，足够返回true，不够返回false
        /// </summary>
        /// <param name="subValue"></param>
        /// <returns></returns>
        public bool SubDiamond(int subValue)
        {
            if (Diamond - Mathf.Abs(subValue) >= 0)
            {
                Diamond -= Mathf.Abs(subValue);
                return true;
            }
            return false;
        }

        public int GetDiamond()
        {
            return Diamond;
        }
        #endregion

        public void DisplayAllOriginalValue()
        {
            MaxExperience = MaxExperience;
            MaxEnergy = MaxEnergy;
            Experience = Experience;
            Level = Level;
            Gold = Gold;
            Diamond = Diamond;
            Energy = Energy;
        }
    }
}
