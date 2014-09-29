using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Game_dice
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        int x = 8;//横向格子数
        int y = 8;//竖向格子数

        int interal = 50;
        IList<IList<Class.Box>> boxs;//盒子集合
        //Class.Point prePoint;
        //Class.Point currentPoint;



        IList<Class.Track> lins;//线集合

        Class.Point life;

        public MainWindow()
        {
            InitializeComponent();
            boxs = initRectangle();
            DrawBoxs();

            initLife();
            life.Draw(this.MainCanvas);
            //Class.Point p1 = new Class.Point(4, 4, 50);
            //Class.Point p2 = new Class.Point(5, 4, 50);
            //Class.Track t = new Class.Track(p1,p2,50);
            //t.Draw(this.MainCanvas);




        }

        private void DrawBoxs()
        {
            foreach (var column in boxs) 
            {
                foreach (var box in column)
                {
                    box.Draw(this.MainCanvas);
                }
            }
        }


        /// <summary>
        /// 初始化生命点
        /// </summary>
        private void initLife()
        {
            life = new Class.Point(4, 4, interal);
        }



        /// <summary>
        /// 初始化X*Y的格子
        /// </summary>
        IList<IList<Class.Box>> initRectangle()
        {
            IList<IList<Class.Box>> result = new List<IList<Class.Box>>();
            for (int i = 0; i < x; i++)
            {
                IList<Class.Box> column = new List<Class.Box>();
                for (int j = 0; j < y; j++)
                {
                    Class.Box box = new Class.Box(10, 5, i, j);
                    column.Add(box);
                }
                result.Add(column);
            }
            return result;
        }

        /// <summary>
        /// 初始化轨迹线
        /// </summary>
        void initLine()
        {

        }

        /// <summary>
        /// 清除画布中所有元素
        /// </summary>
        void ClearCanvas()
        {
            this.MainCanvas.Children.Clear();
        }

        /// <summary>
        /// 键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Up)
            {
                StepUp();
            }
            if (e.Key == Key.Down)
            {
                StepDown();
            }
            if (e.Key == Key.Left)
            {
                StepLeft();
            }

            if (e.Key == Key.Right)
            {
                StepRight();
            }
        }

        private void StepRight()
        {
            Class.Point prePoint = new Class.Point(life.X,life.Y);
            Class.Point currentPoint = new Class.Point(life.X+1, life.Y);
            if (AddLine(prePoint, currentPoint))
            {
                life.X++;

                ReDraw();
            }
        }

        private bool AddLine(Class.Point prePoint,Class.Point current)
        {
            if (prePoint.X > current.X)
            {
                var tmp = prePoint;
                prePoint = current;
                current = tmp;
            }
            if (prePoint.Y > current.Y)
            {
                var tmp = prePoint;
                prePoint = current;
                current = tmp;
            }
           


            Class.Track t = new Class.Track(prePoint, current, interal);

            if (lins != null)
            {
                foreach (var l in lins)
                {
                    if (l.StartPoint.X == prePoint.X && l.StartPoint.Y == prePoint.Y && l.EndPoint.X == current.X && l.EndPoint.Y == current.Y) return false;
                }
                lins.Add(t);
            }
            else
            {
                lins = new List<Class.Track>() { t };
            }
            return true;
        }



        private void StepLeft()
        {
            Class.Point prePoint = new Class.Point(life.X, life.Y);
            Class.Point currentPoint = new Class.Point(life.X - 1, life.Y);
            if (AddLine(prePoint, currentPoint))
            {
                life.X--;

                ReDraw();
            }
        }

        private void StepDown()
        {
            Class.Point prePoint = new Class.Point(life.X, life.Y);
            Class.Point currentPoint = new Class.Point(life.X, life.Y + 1);
            if (AddLine(prePoint, currentPoint))
            {
                life.Y++;

                ReDraw();
            }
        }

        private void StepUp()
        {
            Class.Point prePoint = new Class.Point(life.X, life.Y);
            Class.Point currentPoint = new Class.Point(life.X, life.Y - 1);            
            if (AddLine(prePoint, currentPoint))
            {
                life.Y--;
                ReDraw();
            }
        }

        /// <summary>
        /// 重新画图
        /// </summary>
        private void ReDraw()
        {
            ClearCanvas();
            DrawBoxs();
            life.Draw(this.MainCanvas);
            DrawLine();
        }

        /// <summary>
        /// 画当前的轨迹线
        /// </summary>
        private void DrawLine()
        {
            for (int i = 0; i < lins.Count(); i++)
            {
                lins[i].Draw(this.MainCanvas);
            }
        }
    }
}
