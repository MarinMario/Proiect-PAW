using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.Text.RegularExpressions;

namespace Biblioteca.Forms
{
    public partial class BarChart : UserControl
    {
        public Dictionary<string, int> DataSource { get; set; } = new Dictionary<string, int>();

        public BarChart()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (DataSource == null || DataSource.Count == 0)
                return;

            var g = e.Graphics;
            var font = new Font("Arial", 10);
            var brush = new SolidBrush(Color.Black);
            var barBrush = new SolidBrush(Color.CornflowerBlue);

            float maxVal = 0;
            foreach (var val in DataSource.Values)
                if (val > maxVal) maxVal = val;

            if (maxVal == 0)
                return;


            var i = 0;
            var spacing = 30;
            var textWidth = 100;
            var barWidth = 50;
            var maxBarHeight = 300;
            foreach (var item in DataSource) 
            {
                var rectX = i * textWidth + spacing;
                var barHeight = item.Value / maxVal * maxBarHeight;
                var rectY = maxBarHeight - barHeight + spacing;
                g.FillRectangle(barBrush, rectX, rectY, barWidth, barHeight);
                g.DrawString(item.Key, font, brush, i * textWidth + spacing, maxBarHeight + spacing);
                i += 1;
            }

            for(int j = 0; j <= maxVal; j++)
            {
                var y = maxBarHeight - (j / maxVal * maxBarHeight) + spacing;
                g.DrawLine(Pens.LightGray, spacing, y, this.Width, y);
                g.DrawString(j.ToString(), font, brush, 0, y - font.Height / 2);
            }
        }
    }

}
