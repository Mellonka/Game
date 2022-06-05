using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MagicWorld
{
    public class HealthBar
    {
        Color ForeColor { get; }
        //Color BackColor { get; }

        Point location;
        Size Size { get; }
        float Maximum { get; }
        float mValue;
        public float Value { 
            get
            {
                return mValue;
            }
            set
            {
                if (value > Maximum)
                    mValue = Maximum;
                mValue = value;
            }
        }

        public HealthBar(float HP, int width, int height, Point location)
        {
            this.location = location;
            Size = new Size(width, height);
            Maximum = HP;
            Value = HP;
            ForeColor = Color.Red;
            //BackColor = Color.White;
        }

        public void Move(int dx, int dy)
        {
            location.X += dx;
            location.Y += dy;
        }

        public void OnPaint(Graphics g)
        {
            var lifeRec = new RectangleF(location.X, location.Y, Size.Width * Value / Maximum, Size.Height);
            var formRec = new Rectangle(location, Size);
            //g.FillRectangle(new SolidBrush(BackColor), formRec);
            g.FillRectangle(new SolidBrush(ForeColor), lifeRec);
            g.DrawRectangle(new Pen(Color.Black), formRec);
        }
    }
}
