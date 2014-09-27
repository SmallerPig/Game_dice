using Game_dice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Game_dice.Class
{
    public class Box : Shape, IRuinable,IDrawable
    {
        int RedBeginNum;
        int GreenBeginNum;
        int LocationX;
        int LocationY;
        int R = 50;

        public Box(int redBeginNum,int greenBeginNum, int x,int y)
        {
            RedBeginNum = redBeginNum;
            GreenBeginNum = greenBeginNum;
            this.LocationX = x;
            this.LocationY = y;
        }

        private BoxStatus Status { get; set; }


        private int countDownNum =10;
        public int CountDownNum { get { return this.countDownNum; } }


        /// <summary>
        /// 销毁自己
        /// </summary>
        public void Ruin()
        {
            this.Status = BoxStatus.Normal;
        }

        /// <summary>
        /// 画图
        /// </summary>
        /// <param name="canvas"></param>
        public void Draw(Canvas canvas)
        {
            System.Windows.Shapes.Rectangle myRect = new System.Windows.Shapes.Rectangle();
            if (this.Status != BoxStatus.Normal)
            {
                TextBlock text = new TextBlock();
                text.Text = countDownNum.ToString();
                Canvas.SetLeft(text, LocationX * R + 20);
                Canvas.SetTop(text, LocationY * R + 20);
                canvas.Children.Add(text);
            }

            myRect.Stroke = System.Windows.Media.Brushes.Black;
            myRect.Fill = GetBrushes(); 
            myRect.RadiusX = 5;
            myRect.RadiusY = 5;
            Canvas.SetLeft(myRect, LocationX * R);
            Canvas.SetTop(myRect, LocationY * R);
            myRect.Height = R-5;
            myRect.Width = R-5;
            canvas.Children.Add(myRect);
        }


        /// <summary>
        /// 获取小球颜色
        /// </summary>
        /// <returns></returns>
        private System.Windows.Media.Brush GetBrushes()
        {
            switch (this.Status){
                case BoxStatus.Green:
                    return System.Windows.Media.Brushes.Green;
                case BoxStatus.Red:
                    return System.Windows.Media.Brushes.Red;
                case BoxStatus.Normal:
                default:
                    return System.Windows.Media.Brushes.SkyBlue;
            }

        }

        /// <summary>
        /// 成熟了
        /// </summary>
        private void Mature()
        {
            this.Status = BoxStatus.Green;
        }

        /// <summary>
        /// 倒计时操作
        /// </summary>
        public void CountDown()
        {
            countDownNum--;
            if (countDownNum == 0)
            {
                LowerStatus();
            }
        }

        private void LowerStatus()
        {
            switch (this.Status) {
                case BoxStatus.Green:
                    this.Status = BoxStatus.Normal;
                    break;
                case BoxStatus.Red:
                    this.Status = BoxStatus.Green;
                    break;
                case BoxStatus.Normal:
                default:
                    break;
            }
        }

    }


    public enum BoxStatus{
        Normal,
        Red,
        Green,
        //Ruin
    }
}
