using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniHelper;
using System.IO;
using csDmc2410;

namespace 工程案例
{
    /// <summary>
    /// 轴类
    /// </summary>
    public class Axis
    {
        /// <summary>
        /// 控制卡卡号
        /// </summary>
        public ushort Axis_CardNo { get; set; }

        /// <summary>
        /// 轴号
        /// </summary>
        public ushort Axis_Num { get; set; }

        /// <summary>
        /// 轴名
        /// </summary>
        public string Axis_Name { get; set; }

        /// <summary>
        /// 初始速度(单位：mm/s)
        /// </summary>
        public double Speed_JogStart { get; set; }

        /// <summary>
        /// 点动高速(运行速度mm/s)
        /// </summary>
        public double Speed_JogHigh { get; set; }

        /// <summary>
        /// 点动低速(单位：mm/s)
        /// </summary>
        public double Speed_JogLow { get; set; }

        /// <summary>
        /// 点动加速时间(单位：秒)
        /// </summary>
        public double Speed_JogAcc { get; set; }

        /// <summary>
        /// 点动减速时间(单位：秒)
        /// </summary>
        public double Speed_JogDec { get; set; }


        /// <summary>
        /// 自动起始速度(单位：mm/s)
        /// </summary>
        public double  Speed_autoStart { get; set; }

        /// <summary>
        /// 自动最大速度(单位：mm/s)
        /// </summary>
        public double Speed_autoMax { get; set; }

        /// <summary>
        /// 自动加速时间(单位：秒)
        /// </summary>
        public double Speed_autoAcc { get; set; }

        /// <summary>
        /// 自动减速时间(单位：秒)
        /// </summary>
        public double Speed_autoDec { get; set; }

        /// <summary>
        /// 回原点起始速度(单位：mm/s)
        /// </summary>
        public double Speed_homeStart { get; set; }

        /// <summary>
        /// 回原点最大速度(单位：mm/s)
        /// </summary>
        public double Speed_homeMax { get; set; }

        /// <summary>
        /// 回原点加速时间(单位：秒)
        /// </summary>
        public double Speed_homeAcc { get; set; }

        /// <summary>
        /// 回原点减速时间(单位：秒)
        /// </summary>
        public double Speed_homeDec { get; set; }

        /// <summary>
        ///当XY移动时， Z轴允许高度(单位：mm)
        /// </summary>
        public double ZpingYiPos { get; set; }

        /// <summary>
        /// 回原点方向
        /// </summary>
        public ushort Home_dir { get; set; }

        /// <summary>
        /// 回原点速度选择
        /// </summary>
        public ushort Home_speedSel { get; set; }

        /// <summary>
        /// 回原点模式
        /// </summary>
        public ushort Home_Mode { get; set; }

        /// <summary>
        /// 轴的脉冲当量(pluse/mm    mm/pluse)
        /// </summary>
        public double PulseEquivalent { get; set; }

        /// <summary>
        /// 正向软限位(单位：mm)
        /// </summary>
        public double SoftLimit_P { get; set; }

        /// <summary>
        /// 负向软限位(单位：mm)
        /// </summary>
        public double SoftLimit_N { get; set; }

        /// <summary>
        /// Z轴安全位置
        /// </summary>
        public double ZsafePosition { get; set; }

        /// <summary>
        /// Z轴工作速度(单位：mm/s)
        /// </summary>
        public double ZWorkSpeed { get; set; }

        /// <summary>
        /// 轴异常停止
        /// </summary>
        public bool ExceptionStop { get; set; }


        /// <summary>
        /// 回原点完成标志
        /// </summary>
        public bool OverGoHomeMark { get; set; }


        /// <summary>
        /// 轴的构造函数
        /// </summary>
        /// <param name="CarNo">卡号</param>
        /// <param name="axisNum"></param>
        /// <param name="axisName"></param>
        public Axis(ushort CarNo,ushort axisNum,string axisName)
        {        
            Axis_CardNo = CarNo;

            Axis_Num = axisNum;

            Axis_Name = axisName;

            ParamInitial();//从ini配置文件中读取轴参数
        }

        /// <summary>
        /// 执行更新参数
        /// </summary>
        public void DoParamUpdate()
        {
            ParamInitial();
        }
        /// <summary>
        /// 初始化轴参数
        /// </summary>
        private void ParamInitial()
        {
            string path = Environment.CurrentDirectory + @"\Config.ini";

            IniFiles Config = new IniFiles("Config.ini");
            //脉冲当量   p/mm
            PulseEquivalent = double.Parse(Config.ReadString(Axis_Name, "PulseEquivalent", "0"));

            //手动参数设置
            Speed_JogStart = double.Parse(Config.ReadString(Axis_Name, "Speed_JogStart", "0"));
            Speed_JogHigh = double.Parse(Config.ReadString(Axis_Name, "Speed_JogHigh", "0"));
            Speed_JogLow = double.Parse(Config.ReadString(Axis_Name, "Speed_JogLow", "0"));
            Speed_JogAcc = double.Parse(Config.ReadString(Axis_Name, "Speed_JogAcc", "0"));
            Speed_JogDec = double.Parse(Config.ReadString(Axis_Name, "Speed_JogDec", "0"));

            //自动参数设置
            Speed_autoStart = double.Parse(Config.ReadString(Axis_Name, "Speed_autoStart", "0"));
            Speed_autoMax = double.Parse(Config.ReadString(Axis_Name, "Speed_autoMax", "0"));
            Speed_autoAcc = double.Parse(Config.ReadString(Axis_Name, "Speed_autoAcc", "0"));
            Speed_autoDec = double.Parse(Config.ReadString(Axis_Name, "Speed_autoDec", "0"));

            //回原点参数设置
            Speed_homeStart = double.Parse(Config.ReadString(Axis_Name, "Speed_homeStart", "0"));
            Speed_homeMax = double.Parse(Config.ReadString(Axis_Name, "Speed_homeMax", "0"));
            Speed_homeAcc = double.Parse(Config.ReadString(Axis_Name, "Speed_homeAcc", "0"));
            Speed_homeDec = double.Parse(Config.ReadString(Axis_Name, "Speed_homeDec", "0"));

            //Z轴安全位置
            ZsafePosition = double.Parse(Config.ReadString(Axis_Name, "ZsafePosition", "0"));

            //Z轴工作速度
            ZWorkSpeed = double.Parse(Config.ReadString(Axis_Name, "ZWorkSpeed", "0"));

            //软限位设置
            SoftLimit_P=double.Parse(Config.ReadString(Axis_Name, "SoftLimit_P","0"));
            SoftLimit_N = double.Parse(Config.ReadString(Axis_Name, "SoftLimit_N", "0"));
            SoftLimitSet();
        }

        /// <summary>
        /// 软限位设置方法
        /// </summary>
        /// <param name="softLimitEnable">软限位使能状态，0：禁止，1：允许</param>
        public void SoftLimitSet(ushort softLimitEnable=0) //默认禁止软限位
        {
            //这是雷赛卡的软限位设置方法，不同卡设置不一样！！！！
            //ON_OFF 使能状态，0：禁止，1：允许
            Dmc2410.d2410_config_softlimit(Axis_Num, softLimitEnable, 0, 1,(int)(SoftLimit_N* PulseEquivalent), (int)(SoftLimit_P*PulseEquivalent));
        }
     
    }
}
