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
        public UILabel txtMpByScreen;
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
        public UISlider sliExp;
        public UILabel txtATK;
        public UILabel txtDEF;

        public UILabel txtEnergy_Cur;
        public UILabel txtGold;
        public UILabel txtDiamond;

        private string maxHealth;
        private string maxMagic;
        private string maxEnergy;
        private string maxExp;

        private void Awake()
        {
            Model_PlayerKernalData.playerKernalEvent += DisplayHp;
            Model_PlayerKernalData.playerKernalEvent += DisplayMaxHp;
            Model_PlayerKernalData.playerKernalEvent += DisplayMp;
            Model_PlayerKernalData.playerKernalEvent += DisplayMaxMp;
            Model_PlayerKernalData.playerKernalEvent += DisplayATK;
            Model_PlayerKernalData.playerKernalEvent += DisplayDEF;
            Model_PlayerKernalData.playerKernalEvent += DisplayExp;
            Model_PlayerKernalData.playerKernalEvent += DisplayMaxExp;
            Model_PlayerKernalData.playerKernalEvent += DisplayLevel;
            Model_PlayerKernalData.playerKernalEvent += DisplayEnergy;
            Model_PlayerKernalData.playerKernalEvent += DisplayGold;
            Model_PlayerKernalData.playerKernalEvent += DisplayDiamond;

        }

        private void Start()
        {
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
                if (txtHp_Cur && sliHp)
                {
                    txtHp_Cur.text = kvu.Value.ToString();
                    txtHpByScreen.text = kvu.Value.ToString();

                    txtHpByScreen.text = kvu.Value.ToString() + "/" + maxHealth;
                    sliHp.value = float.Parse(kvu.Value.ToString()) / float.Parse(maxHealth);
                }
                //死亡
                if (((float)kvu.Value) <= 0)
                {

                }
            }
        }

        private void DisplayMaxHp(KeyValueUpdate kvu)
        {
            if (kvu.Key.Equals("MaxHealth") && txtHp_Max)
            {
                txtHp_Max.text = kvu.Value.ToString();
                maxHealth = txtHp_Max.text;
            }
        }

        private void DisplayMp(KeyValueUpdate kvu)
        {
            if (kvu.Key.Equals("Magic") && txtMp_Cur)
            {
                txtMp_Cur.text = kvu.Value.ToString();

                txtMpByScreen.text = kvu.Value.ToString() + "/" + maxMagic;
                sliMp.value = float.Parse(kvu.Value.ToString()) / float.Parse(maxMagic);
            }
        }

        private void DisplayMaxMp(KeyValueUpdate kvu)
        {
            if (kvu.Key.Equals("MaxMagic") && txtMp_Max)
            {
                txtMp_Max.text = kvu.Value.ToString();
                maxMagic = txtMp_Max.text;
            }
        }

        private void DisplayATK(KeyValueUpdate kvu)
        {
            if (kvu.Key.Equals("MaxAttack") && txtATK)
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
            if(kvu.Key.Equals("Experience") && txtExp_Cur)
            {
                txtExp_Cur.text = kvu.Value.ToString() + "/" + maxExp;

                sliMp.value =  float.Parse(kvu.Value.ToString()) / float.Parse(maxMagic) ;
            }
        }

        private void DisplayMaxExp(KeyValueUpdate kvu)
        {
            if (kvu.Key.Equals("MaxExperience") && sliExp)
            {
                maxExp = kvu.Value.ToString();
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
                txtEnergy_Cur.text = kvu.Value.ToString()+ "/" + float.Parse(maxEnergy);
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

