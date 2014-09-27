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
        int x = 8;
        int y = 8;

        IList<IList<Class.Box>> boxs;


        public MainWindow()
        {
            InitializeComponent();
            boxs = initRectangle();
            initLife();
            DrawCanvas();
        }

        private void DrawCanvas()
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
            //throw new NotImplementedException();
        }


        /// <summary>
        /// 初始化8*8的格子
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
        
    }
}
