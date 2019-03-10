
using Global;

namespace Model {
    /// <summary>
    /// 升级规则
    /// </summary>
    public class Model_UpgradeRule {
        private int currentExp;
        private int currentMaxExp;
        private bool upgrade;
        private int currentLevel;
        private static Model_UpgradeRule _instance;

        private Model_UpgradeRule() { }

        public static Model_UpgradeRule GetInstance()
        {
            if (_instance == null)
                _instance = new Model_UpgradeRule();

            return _instance;
        }

        public void UpgradeCondition(int exp)
        {
            currentExp = Model_PlayerExternalDataProxy.GetInstance().GetExp(); ;
            currentMaxExp = Model_PlayerExternalDataProxy.GetInstance().GetMaxExp();

            upgrade = (currentExp - currentMaxExp) >= 0 ? true : false;

            currentLevel = Model_PlayerExternalDataProxy.GetInstance().GetLevel();

            if (upgrade)
                Model_PlayerExternalDataProxy.GetInstance().AddLevel();

        }

        public void UpdradeOperation(LevelName lvName)
        {
            switch(lvName)
            {
                case LevelName.Level_2:
                    UpgradePlayerProperty(10, 10, 10, 1,100);
                    break;
                case LevelName.Level_3:
                    UpgradePlayerProperty(20, 20, 20, 2,200);
                    break;
                case LevelName.Level_4:
                    UpgradePlayerProperty(30, 30, 30, 3,300);
                    break;
                case LevelName.Level_5:
                    UpgradePlayerProperty(40, 40, 40, 4,400);
                    break;
                case LevelName.Level_6:
                    UpgradePlayerProperty(50, 50, 50, 5,500);
                    break;
                case LevelName.Level_7:
                    UpgradePlayerProperty(60, 60, 60, 6,600);
                    break;
                case LevelName.Level_8:
                    UpgradePlayerProperty(70, 70, 70, 7,700);
                    break;
                case LevelName.Level_9:
                    UpgradePlayerProperty(80, 80, 80, 8,800);
                    break;
                case LevelName.Level_10:
                    UpgradePlayerProperty(90, 90, 90, 9,900);
                    break;
                case LevelName.Level_11:
                    UpgradePlayerProperty(100, 100, 100, 10, 1000);
                    break;
                case LevelName.Level_12:
                    UpgradePlayerProperty(110,110, 110, 11, 1100);
                    break;
            }
        }

        public void UpgradePlayerProperty(float maxhp,float maxmp,float ATK, float DEF,int maxExp) {
            Model_PlayerKernalDataProxy.GetInstance().IncreaseMaxHealth(maxhp);
            Model_PlayerKernalDataProxy.GetInstance().IncreaseMaxMagic(maxmp);
            Model_PlayerKernalDataProxy.GetInstance().IncreaseATK(ATK);
            Model_PlayerKernalDataProxy.GetInstance().IncreaseDEF(DEF);
            Model_PlayerExternalDataProxy.GetInstance().AddMaxExp(maxExp);
            //升级加血和魔法
            Model_PlayerKernalDataProxy.GetInstance().IncreaseHealthValue(Model_PlayerKernalDataProxy.GetInstance().GetMaxHealth());
            Model_PlayerKernalDataProxy.GetInstance().IncreaseMagicValue(Model_PlayerKernalDataProxy.GetInstance().GetMaxMagic());
        }
    }
}

