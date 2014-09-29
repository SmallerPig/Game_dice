using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Game_dice.Class
{
    public class Track : Interface.IRuinable, Interface.IDrawable
    {
        /// <summary>
        /// 起始点
        /// </summary>
        public Point StartPoint { get; set; }

        /// <summary>
        /// 结束点
        /// </summary>
        public Point EndPoint { get; set; }

        /// <summary>
        /// 长度，实体长度
        /// </summary>
        public int Length { get; set; }

        private int width = 4;

        public Track(Point startPoint, Point endPoint , int length)
        {
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
            this.Length = length;
        }



        public void Ruin()
        {
            throw new NotImplementedException();
        }

        public void Draw(Canvas canvas)
        {
            Line myLine = new Line();
            myLine.Stroke = System.Windows.Media.Brushes.Red;
            myLine.X1 = StartPoint.X * Length -2;
            myLine.X2 = EndPoint.X * Length -2;
            myLine.Y1 = StartPoint.Y * Length -4;
            myLine.Y2 = EndPoint.Y * Length-4;
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 4;
            canvas.Children.Add(myLine);
        }
    }



    
}
