using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiemNet
{
    public class Custom
    {

        public void SetRoundedTextBox(TextBox txt, int radius)
        {
            Rectangle rect = new Rectangle(0, 0, txt.Width, txt.Height);
            GraphicsPath path = new GraphicsPath();

            int d = radius * 2;
            if (d > txt.Height) d = txt.Height;
            if (d > txt.Width) d = txt.Width;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            txt.Region = new Region(path);
            txt.BorderStyle = BorderStyle.None; // bỏ viền mặc định

            // Vẽ viền bo góc đẹp bằng Panel bọc ngoài
            Panel pnl = new Panel();
            pnl.BackColor = Color.Blue; // màu viền
            pnl.Size = txt.Size;
            pnl.Location = txt.Location;
            pnl.Region = new Region(path);

            txt.Parent.Controls.Add(pnl);
            txt.BringToFront();
        }

        public void SetRoundedButton(Button btn, int radius)
        {
            Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);
            GraphicsPath path = new GraphicsPath();

            int d = radius * 2;

            // Nếu radius lớn hơn, thì ép nó thành bo tròn hoàn toàn
            if (d > btn.Height) d = btn.Height;
            if (d > btn.Width) d = btn.Width;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            btn.Region = new Region(path);

            // Vẽ viền đẹp
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0; // bỏ viền mặc định
            //btn.BackColor = Color.DodgerBlue;  // nền
            btn.ForeColor = Color.White;       // chữ
        }

    }
}
