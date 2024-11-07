﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MyDrawing.graphics
{
    public class FormGraphicAdapter : IGraphics
    {
        Graphics graphics;

        public FormGraphicAdapter(Graphics graphics)
        {
            this.graphics = graphics;
            this.graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        public void ClearAll()
        {
            // windows form 的 paint 在被呼叫時自動清理，所以這裡不用寫
        }

        public void DrawArc(double x, double y, double width, double height, double startAngle, double sweepAngle)
        {
            this.graphics.DrawArc(Pens.Black, (float)x, (float)y, (float)width, (float)height, (float)startAngle, (float)sweepAngle);
        }

        public void DrawEllipse(double x, double y, double width, double height)
        {
            this.graphics.DrawEllipse(Pens.Black, (float)x, (float)y, (float)width, (float)height);
        }

        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            this.graphics.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        public void DrawPolygon(double[] x, double[] y)
        {
            if (x.Length != y.Length)
                throw new ArgumentException("x and y length is different");
            PointF[] pointFs = new PointF[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                pointFs[i].X = (float)x[i];
                pointFs[i].Y = (float)y[i];
            }
            this.graphics.DrawPolygon(Pens.Black, pointFs);
        }

        public void DrawRectangle(double x, double y, double width, double height)
        {
            this.graphics.DrawRectangle(Pens.Black, (float)x, (float)y, (float)width, (float)height);
        }

        public void DrawString(string s, double x, double y)
        {
            // graphics.DrawString 會把 x y 當成左上角繪製文字
            this.graphics.DrawString(s, new Font("Arial", 7), Brushes.Black, (float)x, (float)y);
        }
    }
}
