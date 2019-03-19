using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;
using Global;
namespace View
{
    public class View_PlayerInfoDisplay : MonoBehaviour
    {
        //玩家屏幕信息
        public UILabel txtHpByScreen;
        public UILabel txtHpMaxByScreen;
        public UILabel txtMpByScreen;
        public UILabel txtMpMaxByScreen;
        public UILabel txtLevelByScreen;
        public UISlider sliHp;
        public UISlider sliMp;
        public UISprite sprPlayerHead;
        public UIButton btnPlayer;
        //玩家详细信息
        public UILabel txtPlayerName;
        public UILabel txtLevel;
        public UILabel txtHp_Cur;
        public UILabel txtHp_Max;
        public UILabel txtMp_Cur;
        public UILabel txtMp_Max;
        public UILabel txtExp_Cur;
        public UILabel txtExp_Max;
        public UISlider sliExp;
        public UILabel txtATK;
        public UILabel txtDEF;

        public UILabel txtEnergy_Cur;
        public UILabel txtEnergy_Max;
        public UILabel txtGold;
        public UILabel txtDiamond;

        private int health;
        private int magic;
        private int energy;
        private int exp;
        private int maxHealth;
        private int maxMagic;
        private int maxEnergy;
        private int maxExp;
        private void Awake()
        {
            Debug.Log("aaa");
            Model_PlayerKernalData.playerKernalEvent += DisplayMaxHp;
            Model_PlayerKernalData.playerKernalEvent += DisplayHp;
            Model_PlayerKernalData.playerKernalEvent += DisplayMaxMp;
            Model_PlayerKernalData.playerKernalEvent += DisplayMp;
            Model_PlayerKernalData.playerKernalEvent += DisplayATK;
            Model_PlayerKernalData.playerKernalEvent += DisplayDEF;
            Model_PlayerExternalData.playerExternalDataEvent += DisplayExp;
            Model_PlayerExternalData.playerExternalDataEvent += DisplayMaxExp;
            Model_PlayerExternalData.playerExternalDataEvent += DisplayLevel;
            Model_PlayerExternalData.playerExternalDataEvent += DisplayEnergy;
            Model_PlayerExternalData.playerExternalDataEvent += DisplayMaxEnergy;
            Model_PlayerExternalData.playerExternalDataEvent += DisplayGold;
            Model_PlayerExternalData.playerExternalDataEvent += DisplayDiamond;

        }

        private void Start()
        {
            Debug.Log("aa");
            Model_PlayerExternalDataProxy.GetInstance().DisplayAllOriginalValue();
            Model_PlayerKernalDataProxy.GetInstance().DisplayAllOriginalValue();

            if(!string.IsNullOrEmpty(GlobalParaMgr.PlayerName))
            {
                txtPlayerName.text = GlobalParaMgr.PlayerName;
            }
        }
        #region 事件注册方法
        private void DisplayHp(KeyValueUpdate kvu)
        {
            if (kvu.Key.Equals("Health"))
            {
                if (txtHp_Cur)
                {
                    txtHp_Cur.text = kvu.Value.ToString();
                    txtHpByScreen.text = kvu.Value.ToString();

                    health = int.Parse(kvu.Value.ToString());

                    sliHp.value = (float)health / maxHealth;

                }
                //死亡
                if (((float)kvu.Value) <= 0)
                {

                }
            }
        }

        private void DisplayMaxHp(KeyValueUpdate kvu)
        {
            if (kvu.Key.Equals("MaxHealth") && txtHp_Max && sliHp)
            {
                txtHp_Max.text = kvu.Value.ToString();
                txtHpMaxByScreen.text = kvu.Value.ToString();
                maxHealth = int.Parse(kvu.Value.ToString());

            }
        }

        private void DisplayMp(KeyValueUpdate kvu)
        {
            if (kvu.Key.Equals("Magic") && txtMp_Cur)
            {
                txtMp_Cur.text = kvu.Value.ToString();
                txtMpByScreen.text = kvu.Value.ToString();
                magic = int.Parse(kvu.Value.ToString());

                sliMp.value = (float)magic / maxMagic;
            }
        }

        private void DisplayMaxMp(KeyValueUpdate kvu)
        {
            if (kvu.Key.Equals("MaxMagic") && txtMp_Max && sliMp)
            {
                txtMp_Max.text = kvu.Value.ToString();
                txtMpMaxByScreen.text = kvu.Value.ToString();
                maxMagic = int.Parse(txtMp_Max.text);
            }
        }

        private void DisplayATK(KeyValueUpdate kvu)
        {
            if (kvu.Key.Equals("Attack") && txtATK)
            {
                txtATK.text = kvu.Value.ToString();
            }
        }
        private void DisplayDEF(KeyValueUpdate kvu)
        {
            if (kvu.Key.Equals("Defence") && txtDEF)
            {
                txtDEF.text = kvu.Value.ToString();
            }
        }

        private void DisplayExp(KeyValueUpdate kvu)
        {
            if(kvu.Key.Equals("Experience") && txtExp_Cur && sliExp )
            {
                txtExp_Cur.text = kvu.Value.ToString();
                exp = int.Parse(kvu.Value.ToString());

                sliExp.value = (float)exp / maxExp;
            }
        }

        private void DisplayMaxExp(KeyValueUpdate kvu)
        {
            if (kvu.Key.Equals("MaxExperience") && txtExp_Max)
            {
                txtExp_Max.text = kvu.Value.ToString();
                maxExp = int.Parse(kvu.Value.ToString());

            }

        }

        private void DisplayLevel(KeyValueUpdate kvu)
        {
            if(kvu.Key.Equals("Level") && txtLevel && txtLevelByScreen)
            {
                txtLevel.text = kvu.Value.ToString();
                txtLevelByScreen.text = kvu.Value.ToString();

            }
        }

        private void DisplayEnergy(KeyValueUpdate kvu)
        {
            if(kvu.Key.Equals("Energy") && txtEnergy_Cur)
            {
                txtEnergy_Cur.text = kvu.Value.ToString();
            }
        }

        private void DisplayMaxEnergy(KeyValueUpdate kvu)
        {
            if (kvu.Key.Equals("MaxEnergy") && txtEnergy_Max)
            {
                txtEnergy_Max.text = kvu.Value.ToString();
            }
        }

        private void DisplayGold(KeyValueUpdate kvu)
        {
            if(kvu.Key.Equals("Gold") && txtGold)
            {
                txtGold.text = kvu.Value.ToString();
            }
        }

        private void DisplayDiamond(KeyValueUpdate kvu)
        {
            if(kvu.Key.Equals("Diamond") && txtDiamond)
            {
                txtDiamond.text = kvu.Value.ToString();
            }
        }
        #endregion
    }
}

