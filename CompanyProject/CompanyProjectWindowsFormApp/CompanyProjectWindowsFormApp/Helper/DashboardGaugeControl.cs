using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class DashboardGaugeControl : Control
{
    private string title;
    private decimal value;
    private decimal maximum;

    public DashboardGaugeControl(
        string title,
        decimal value,
        decimal maximum)
    {
        this.title = title;
        this.value = value;
        this.maximum = maximum;

        Size = new Size(250, 160);

        BackColor =
            Color.FromArgb(30, 41, 59);

        DoubleBuffered = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics graphics = e.Graphics;

        graphics.SmoothingMode =
            SmoothingMode.AntiAlias;

        Rectangle gaugeRectangle =
            new Rectangle(
                25,
                15,
                Width - 50,
                110);

        using (Pen backgroundPen =
            new Pen(
                Color.FromArgb(71, 85, 105),
                14))
        {
            graphics.DrawArc(
                backgroundPen,
                gaugeRectangle,
                180,
                180);
        }

        decimal percentage =
            maximum <= 0
                ? 0
                : value / maximum;

        if (percentage > 1)
            percentage = 1;

        float sweepAngle =
            (float)(180 * percentage);

        using (Pen valuePen =
            new Pen(
                Color.FromArgb(37, 99, 235),
                14))
        {
            graphics.DrawArc(
                valuePen,
                gaugeRectangle,
                180,
                sweepAngle);
        }

        string valueText =
            value.ToString("N0");

        using (Font valueFont =
            new Font(
                "Segoe UI",
                20,
                FontStyle.Bold))
        {
            SizeF valueSize =
                graphics.MeasureString(
                    valueText,
                    valueFont);

            graphics.DrawString(
                valueText,
                valueFont,
                Brushes.White,
                (Width - valueSize.Width) / 2,
                65);
        }

        using (Font titleFont =
            new Font(
                "Segoe UI",
                9,
                FontStyle.Regular))
        {
            SizeF titleSize =
                graphics.MeasureString(
                    title,
                    titleFont);

            using (SolidBrush titleBrush =
                new SolidBrush(
                    Color.FromArgb(
                        203,
                        213,
                        225)))
            {
                graphics.DrawString(
                    title,
                    titleFont,
                    titleBrush,
                    (Width - titleSize.Width) / 2,
                    105);
            }
        }

        string maximumText =
            value.ToString("N0") +
            " / " +
            maximum.ToString("N0");

        using (Font maximumFont =
            new Font(
                "Segoe UI",
                8,
                FontStyle.Regular))
        {
            SizeF maximumSize =
                graphics.MeasureString(
                    maximumText,
                    maximumFont);

            using (SolidBrush maximumBrush =
                new SolidBrush(
                    Color.FromArgb(
                        148,
                        163,
                        184)))
            {
                graphics.DrawString(
                    maximumText,
                    maximumFont,
                    maximumBrush,
                    (Width - maximumSize.Width) / 2,
                    128);
            }
        }
    }
}