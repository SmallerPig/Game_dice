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

        public MainWindow()
        {
            InitializeComponent();
            initRectangle();
            initLife();


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
        void initRectangle(){
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Interface.IDrawable box = new Class.Box(10, 5, i, j);
                    box.Draw(this.MainCanvas);
                }
            }
        }

        /// <summary>
        /// 初始化轨迹线
        /// </summary>
        void initLine()
        {

        }

    }
}
