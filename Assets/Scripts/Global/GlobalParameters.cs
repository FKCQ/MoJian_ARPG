/*
 *  1、定义整个项目的枚举类型
 *  2、定义整个项目的委托
 *  3、定义整个项目的系统常量
 * */
namespace Global
{
    //项目的系统常量
    public class GlobalParameters {
    

    }

    #region 项目枚举
    public enum LevelName
    {
        Level_2 = 2,
        Level_3 = 3,
        Level_4 = 4,
        Level_5 = 5,
        Level_6 = 6,
        Level_7 = 7,
        Level_8 = 8,
        Level_9 = 9,
        Level_10 = 10,
        Level_11 = 11,
        Level_12 = 12

    }


    public enum Scenes
    {
        StartScene,
        MainScene,
        BattleScene
    }


    public enum PlayerType
    {
        Kuangzhanshi,
        Cike
    }

    #endregion

    #region 项目的委托
    //玩家数据
    public delegate void playerExternalDataEventHandler(KeyValueUpdate kvu);
    public delegate void playerKernalDataEventHandler(KeyValueUpdate kvu);
    #endregion
    /// <summary>
    /// 使用键值类更新玩家数据
    /// </summary>
    public class KeyValueUpdate
    {
        private string _key;
        private object _value;

        public KeyValueUpdate(string key, object value)
        {
            _value = value;
            _key = key;
        }

        public string Key {
            get {
                return _key;
            }

            set {
                _key = value;
            }
        }

        public object Value {
            get {
                return _value;
            }

            set {
                _value = value;
            }
        }
    }
}
