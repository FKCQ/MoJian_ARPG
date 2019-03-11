using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;
using Kernal;
using UnityEngine.SceneManagement;

namespace Controller
{

    public class BaseController : MonoBehaviour {
    
        protected void EnterNextScenes(Global.Scenes scenesEnumName)
        {
            GlobalParaMgr.NextSceneName = scenesEnumName;
            SceneManager.LoadScene(ConvertEnumToString.GetInstance().GetStrByEnumScene(Global.Scenes.BattleScene));
        }

        /// <summary>
        /// 生成敌人（使用对象缓冲池技术）
        /// </summary>
        /// <param name="enemyPrefab"></param>
        /// <param name="createEnemyNum"></param>
        /// <param name="enemySpawnPos"></param>
        /// <param name="isCreateHpBar"></param>
        /// <returns></returns>
        protected IEnumerator SpawnEnemy(GameObject enemyPrefab, int createEnemyNum, Transform[] enemySpawnPos, bool isCreateHpBar = false)
        {
            yield return new WaitForSeconds(0.5f);

            for(int i = 0; i <= createEnemyNum; i++)
            {
                Vector3 enemySpawnPosition = GetRandomEnemySpawnPosition(enemySpawnPos).position;

                enemyPrefab.transform.position = enemySpawnPosition;
                GameObject enemyClone = PoolManager.poolDic["_Enemys"].GetGameObjectByPool(enemyPrefab, enemyPrefab.transform.position, Quaternion.identity);

                if(isCreateHpBar)
                {
                    GameObject goHPBar = ResourcesMgr.GetInstance().LoadAsset("Prefabs/UI/EnemyHPBar", true);
                    goHPBar.transform.parent = GameObject.FindGameObjectWithTag("UIPlayerInfo").transform;
                }
            }
        }
        /// <summary>
        /// 获取敌人随机生成位置
        /// </summary>
        /// <param name="enemyCreatePos"></param>
        /// <returns></returns>
        public Transform GetRandomEnemySpawnPosition(Transform[] enemyCreatePos)
        {
            int randomNum = Random.Range(0, enemyCreatePos.Length - 1);
            return enemyCreatePos[randomNum];
        }
    }
}

