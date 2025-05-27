using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketGIS
{
    // 几何基类
    public abstract class Geometry
    {
        public Color Color { get; set; } = Color.Black;
        public int Layer { get; set; } = 0;
        public abstract void Draw(Graphics g);
        public abstract bool HitTest(Point point);
    }

    // 点类
    public class GeometryPoint : Geometry
    {
        public string PointID { get; set; } = "";      // 点号（必填）
        public PointF Location { get; set; }           // 二维坐标（浮点型，高精度）
        public double Z { get; set; } = 0;             // 高程（三维坐标）
        public DateTime CreationTime { get; set; }     // 创建/导入时间
        public string Description { get; set; } = "";  // 备注信息
        public float SymbolSize { get; set; } = 5f;    // 符号大小
        public string SymbolStyle { get; set; } = "Circle"; // 符号样式（Circle/Star等）
        public bool IsSurveyPoint { get; set; } = true; // 是否为实测点标记

        // 修改原Draw方法，支持符号样式和点号标注
        public override void Draw(Graphics g)
        {
            using (Brush brush = new SolidBrush(Color))
            {
                // 绘制符号
                switch (SymbolStyle.ToLower())
                {
                    case "circle":
                        g.FillEllipse(brush,
                            Location.X - SymbolSize / 2,
                            Location.Y - SymbolSize / 2,
                            SymbolSize, SymbolSize);
                        break;
                    case "square":
                        g.FillRectangle(brush,
                            Location.X - SymbolSize / 2,
                            Location.Y - SymbolSize / 2,
                            SymbolSize, SymbolSize);
                        break;
                        // 可扩展更多样式
                }

                // 绘制点号（若存在）
                if (!string.IsNullOrEmpty(PointID))
                {
                    using (Font font = new Font("宋体", 8f)) // 创建字体对象
                    {
                        g.DrawString(PointID, font, Brushes.Black,
                            Location.X + SymbolSize / 2,
                            Location.Y + SymbolSize / 2);
                    }
                }
            }
        }
        public override bool HitTest(Point point)
        {
            return Math.Pow(point.X - Location.X, 2) +
            Math.Pow(point.Y - Location.Y, 2) <=
            Math.Pow(SymbolSize, 2);
        }
    }

    // 直线类
    public class GeometryLine : Geometry
    {
        public bool FirstPointSet { get; set; } = false;
        public Point Start { get; set; }
        public Point End { get; set; }
        public float Width { get; set; } = 2f;

        public override void Draw(Graphics g)
        { 
            using (Pen pen = new Pen(Color, Width))
            {
                g.DrawLine(pen, Start, End);
            }
        }

        public override bool HitTest(Point point)
        {
            // 简单的点击测试，可能需要更精确的算法
            double distance = DistanceFromPointToLine(point, Start, End);
            return distance <= Width + 2;
        }

        private double DistanceFromPointToLine(Point point, Point lineStart, Point lineEnd)
        {
            double numerator = Math.Abs((lineEnd.Y - lineStart.Y) * point.X -
                                       (lineEnd.X - lineStart.X) * point.Y +
                                       lineEnd.X * lineStart.Y - lineEnd.Y * lineStart.X);
            double denominator = Math.Sqrt(Math.Pow(lineEnd.Y - lineStart.Y, 2) +
                                          Math.Pow(lineEnd.X - lineStart.X, 2));
            return numerator / denominator;
        }
    }
}
