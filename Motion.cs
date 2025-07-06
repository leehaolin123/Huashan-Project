using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using csDmc2410;
using System.Threading;
 

namespace 工程案例
{
    /// <summary>
    /// 运动控制
    /// </summary>
  public abstract class Motion
    {
        /// <summary>
        /// 是否按下急停
        /// </summary>
        public bool IsPressEms { get; set; }

        /// <summary>
        /// 初始化运动控制卡
        /// </summary>
        public abstract void OpenCard(params Axis[] axs);

        /// <summary>
        /// 关闭运动控制卡
        /// </summary>
        public abstract void CloseCard();
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
        /// <summary>
        /// 点动运动
        /// </summary>
        /// <param name="ax">轴</param>
        /// <param name="dir">方向</param>
        /// <param name="highorlow">高速或低速</param>
        public abstract void AxisDirMove(Axis ax, ushort dir,bool highorlow);

        /// <summary>
        /// 轴停止
        /// </summary>
        /// <param name="ax">轴</param>
        public abstract void AxisStop(Axis ax);


        /// <summary>
        /// 获取轴位置
        /// </summary>
        /// <param name="ax">轴</param>
        /// <returns></returns>
        public abstract double  AxisPosGet(Axis ax);

        /// <summary>
        /// 回原点
        /// </summary>
        /// <param name="ax">轴</param>
        public abstract void GoHome(Axis ax,int mode);

        /// <summary>
        /// 相对_绝对运动
        /// </summary>
        /// <param name="ax">轴</param>
        /// <param name="dist">距离</param>
        /// <param name="posMod">模式：相对_绝对</param>
        public abstract void PtPMove(Axis ax, double  dist, ushort posMod);

        /// <summary>
        /// 三轴直线插补
        /// </summary>
        /// <param name="Axis">轴</param>
        /// <param name="dst1">轴1位置</param>
        /// <param name="dst2">轴2位置</param>
        /// <param name="dst3">轴3位置</param>
        /// <param name="posiMode">模式：相对_绝对</param>
        public abstract void Line3InterPolationMove(Axis[] Axis, double  dst1, double  dst2,double  dst3, ushort posiMode);

        /// <summary>
        /// 两轴直线插补运动
        /// </summary>
        /// <param name="Ax1">轴1</param>
        /// <param name="dst1">轴1位置</param>
        /// <param name="Ax2">轴2</param>
        /// <param name="dst2">轴2位置</param>
        /// <param name="posiMode">模式：相对_绝对</param>
        public abstract void Line2Move(Axis Ax1, double  dst1, Axis Ax2, double  dst2, ushort posiMode);

        /// <summary>
        /// 轴状态检测
        /// </summary>
        /// <param name="axNum">轴号</param>
        /// <returns>轴状态数值</returns>
        public abstract ushort RunningStatus(ushort  axNum);

        /// <summary>
        /// 读取输入位状态
        /// </summary>
        /// <param name="bitNo">输入位号</param>
        /// <returns></returns>
        public abstract int  readInbit(Axis ax,  ushort bitNo);

        /// <summary>
        /// 控制位输出信号
        /// </summary>
        /// <param name="bitNo">输出位号</param>
        /// <param name="val">通_断</param>
        public abstract void  writeOutBit(Axis ax,ushort bitNo,ushort val);

        /// <summary>
        /// 专用IO信号的读取
        /// </summary>
        /// <param name="ax">轴</param>
        /// <param name="bitNo">位号</param>
        /// <returns>状态值</returns>
        public abstract int Io_status_read(Axis ax, int bitNo); 

        /// <summary>
        /// 急停
        /// </summary>
        public abstract void Estop();

        /// <summary>
        /// 脉冲输出模式设置
        /// </summary>
        /// <param name="ax">脉冲轴</param>
        public abstract void PulseModeSet(params Axis[] axs);

        /// <summary>
        /// 读取输出位状态
        /// </summary>
        /// <param name="ax">轴</param>
        /// <param name="bitNo">位号</param>
        /// <returns>0：通，1：断</returns>
        public abstract int ReadOutBit(Axis ax, ushort bitNo);
        
    }
   
}
