using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace ControlExs
{
    public partial class WDCheckBoxPNG : CheckBox
    {
        /*
         * 设置paint
        Archor: Top, Bottom, Left, Right
        Appearance: Button
        AutoSize: False
        Size: 25,25
        TextAlign: MiddleCenter
         */

        private QQControlState _state = QQControlState.Normal;
        private Image _checkImg = RenderHelper.GetImageFormResourceStream("ControlExs.QQControls.WDCheckBoxPNG.Image.check.png");
        private Image _uncheckImg = RenderHelper.GetImageFormResourceStream("ControlExs.QQControls.WDCheckBoxPNG.Image.uncheck.png");
        private Font _defaultFont = new Font("Arial", 11);

        private Size defaultSize = new Size(21,21);
        private Size bigSize = new Size(25, 25);
        private Size smallSize = new Size(18, 18);

        private static readonly ContentAlignment RightAlignment = ContentAlignment.TopRight | ContentAlignment.BottomRight | ContentAlignment.MiddleRight;
        private static readonly ContentAlignment LeftAlignment = ContentAlignment.TopLeft | ContentAlignment.BottomLeft | ContentAlignment.MiddleLeft;

        private void SetPNGStyle(){
            this.BackColor = Color.Transparent;
            this.Font = _defaultFont;
            this.Size = defaultSize;
            this.AutoSize = false;

            this.Appearance = System.Windows.Forms.Appearance.Button;
            this.Anchor = AnchorStyles.Top & AnchorStyles.Bottom & AnchorStyles.Left & AnchorStyles.Right;
            this.CheckAlign = ContentAlignment.MiddleCenter;
            this.TextAlign = ContentAlignment.MiddleCenter;
        }
        public WDCheckBoxPNG()
        {
            //InitializeComponent();
            SetStyles();
            SetPNGStyle();
        }

        [Description("获取WDCheckBoxPNG左边正方形的宽度")]
        protected virtual int CheckRectWidth
        {
            get { return 30; }
        }

        protected virtual int CheckRectHeight
        {
            get { return 30; }
        }

        public WDCheckBoxPNG(IContainer container)
        {
            //container.Add(this);
            //InitializeComponent();
        }


        protected override void OnMouseEnter(EventArgs e)
        {
            _state = QQControlState.Highlight;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _state = QQControlState.Normal;
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            if (mevent.Button == MouseButtons.Left)
            {
                _state = QQControlState.Down;
            }
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            if (mevent.Button == MouseButtons.Left)
            {
                if (ClientRectangle.Contains(mevent.Location))
                {
                    _state = QQControlState.Highlight;
                }
                else
                {
                    _state = QQControlState.Normal;
                }
            }
            base.OnMouseUp(mevent);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (Enabled)
            {
                _state = QQControlState.Normal;
            }
            else
            {
                _state = QQControlState.Disabled;
            }
            base.OnEnabledChanged(e);
        }

        private Image PictureBoxZoom(Image img, Size size)
        {
            Bitmap bm = new Bitmap(img, Convert.ToInt32(img.Width * size.Width), Convert.ToInt32(img.Height * size.Height));
            Graphics grap = Graphics.FromImage(bm);
            grap.InterpolationMode = InterpolationMode.HighQualityBicubic;
            return bm;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
           
            base.OnPaint(pevent);
            base.OnPaintBackground(pevent);
              
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.Low;

            Rectangle checkRect, textRect;
            CalculateRect(out checkRect, out textRect);

            ForeColor = Color.Black;

            //this.Appearance = System.Windows.Forms.Appearance.Button;

            //SetPNGStyle();
            //this.Font = _defaultFont;
            //this.Size = defaultSize;
            //this.AutoSize = false;

            if (Enabled == false)
            {
                _state = QQControlState.Disabled;
            }

            // 大小
            textRect.Width = this.Size.Width;
            textRect.Height = textRect.Width;
            // 位置
            textRect.X = 0;
            textRect.Y = 0;

            
            switch (_state)
            {
                case QQControlState.Highlight:
                    /*
                    g.FillEllipse(new SolidBrush(Color.FromArgb(245, 245, 230)), 0, 0, textRect.Width, textRect.Height);
                    //g.FillEllipse(new SolidBrush(Color.FromArgb(245, 245, 230)), 0, 0, textRect.Width / 3, textRect.Height / 3);
                    using (Pen borderPen = new Pen(Brushes.Black))
                    {
                        g.DrawEllipse(borderPen, 0, 0, textRect.Width - 1, textRect.Height - 1);
                    }
                     */
                    
                    // 放大
                    /*
                    Image temp = PictureBoxZoom(_checkImg, new Size(2, 2));
                    this.Size = new Size(this.Size.Width * 2, this.Size.Height * 2);
                    g.DrawImage(temp, new Rectangle(0, 0, _checkImg.Width, _checkImg.Height), 0, 0, _checkImg.Width, _checkImg.Height, GraphicsUnit.Pixel);
                    */

                    /*
                    using (Bitmap youPicture = new Bitmap(_checkImg))
                    {
                        //g.DrawImage(_checkImg, 0, 0, 300, 100); //set the desired size

                        //Now you need to create a matrix object to apply transformation on your graphic
                        Matrix mat = new Matrix();
                        mat.Scale(1.5f, 1.5f, MatrixOrder.Append); //zoom to 150%
                        g.Transform = mat;

                        this.Size = new Size(this.Size.Width * 2, this.Size.Height * 2);

                        //g.DrawImage(_checkImg, new Rectangle(0, 0, _checkImg.Width, _checkImg.Height), -(int)(_checkImg.Width / 2), -(int)(_checkImg.Height/2), _checkImg.Width, _checkImg.Height, GraphicsUnit.Pixel);
                        g.DrawImage(_checkImg, new Rectangle(0, 0, _checkImg.Width, _checkImg.Height), 0, 0, _checkImg.Width, _checkImg.Height, GraphicsUnit.Pixel);

                    }
                    */
                    
                    g.DrawImage(_checkImg, new Rectangle(0, 0, _checkImg.Width, _checkImg.Height), 0, 0, _checkImg.Width, _checkImg.Height, GraphicsUnit.Pixel);
                    break;
                case QQControlState.Down:
                    //g.FillEllipse(Brushes.Red, textRect);
                    //g.DrawImage(_checkImg, checkRect, 0, 0, _checkImg.Width, _checkImg.Height, GraphicsUnit.Pixel);
                    g.DrawImage(_checkImg, new Rectangle(0, 0, _checkImg.Width, _checkImg.Height), 0, 0, _checkImg.Width, _checkImg.Height, GraphicsUnit.Pixel);
                    break;
                case QQControlState.Disabled:
                    ForeColor = Color.Gray;
                    g.FillEllipse(new SolidBrush(Color.FromArgb(245, 245, 230)), 0, 0, textRect.Width, textRect.Height);
                    using (Pen borderPen = new Pen(Brushes.Gray))
                    {
                        g.DrawEllipse(borderPen, 0, 0, textRect.Width - 1, textRect.Height - 1);
                    }
                    
                    break;
                default:
                    /*
                    g.FillEllipse(new SolidBrush(Color.FromArgb(245, 245, 230)), 0, 0, textRect.Width, textRect.Height);
                    using (Pen borderPen = new Pen(Brushes.White))
                    {
                        g.DrawEllipse(borderPen, 0, 0, textRect.Width - 1, textRect.Height - 1);
                    }
                     */
                    //this.ForeColor = Color.Black;
                    g.DrawImage(_uncheckImg, new Rectangle(0, 0, _checkImg.Width, _checkImg.Height), 0, 0, _uncheckImg.Width, _uncheckImg.Height, GraphicsUnit.Pixel);
                    break;
            }
        

            if (Checked)
            {
                /*
                // Create a path that consists of a single ellipse. 
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, textRect.Width - 1, textRect.Height - 1);

                // Use the path to construct a brush. 
                PathGradientBrush pthGrBrush = new PathGradientBrush(path);

                // Set the color at the center of the path to blue. 
                pthGrBrush.CenterColor = Color.White;

                // Set the color along the entire boundary  
                // of the path to aqua. Color.FromArgb(255, 226, 133, 125)
                Color[] colors = { Color.Salmon };
                pthGrBrush.SurroundColors = colors;

                g.FillEllipse(pthGrBrush, 0, 0, textRect.Width - 1, textRect.Height - 1);
                 */
                //this.ForeColor = Color.White;
                ForeColor = Color.White;
                g.DrawImage(_checkImg, new Rectangle(0, 0, _checkImg.Width, _checkImg.Height), 0, 0, _checkImg.Width, _checkImg.Height, GraphicsUnit.Pixel);
            }

            /* g.FillEllipse(Brushes.Red, textRect);
             using (Pen borderPen = new Pen(ColorTable.QQBorderColor))
             {
                 g.DrawRectangle(borderPen, checkRect);
             }
             */
            /*
            ForeColor = (Checked) ? Color.White : Color.Black;

            Color textColor = (Enabled == true) ? ForeColor : Color.Gray;
            */
            TextRenderer.DrawText(
                g,
                Text,
                Font,
                textRect,
                ForeColor,
                GetTextFormatFlags(TextAlign, RightToLeft == RightToLeft.Yes));


        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            //base.OnForeColorChanged(e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_checkImg != null)
                {
                    _checkImg.Dispose();
                }
                if (_defaultFont != null)
                {
                    _defaultFont.Dispose();
                }
            }

            _checkImg = null;
            _defaultFont = null;
            base.Dispose(disposing);
        }

        private void DrawNormalCheckRect(Graphics g, Rectangle checkRect)
        {
            g.FillRectangle(Brushes.White, checkRect);
            using (Pen borderPen = new Pen(ColorTable.QQBorderColor))
            {
                g.DrawRectangle(borderPen, checkRect);
            }
            if (Checked)
            {
                //g.DrawImage(_checkImg,checkRect, 0,0,_checkImg.Width, _checkImg.Height,GraphicsUnit.Pixel);
            }
        }

        private void DrawHighLightCheckRect(Graphics g, Rectangle checkRect)
        {
            DrawNormalCheckRect(g, checkRect);
            using (Pen p = new Pen(ColorTable.QQHighLightInnerColor))
            {
                g.DrawRectangle(p, checkRect);

                checkRect.Inflate(1, 1);
                p.Color = ColorTable.QQHighLightColor;

                g.DrawRectangle(p, checkRect);
            }


        }

        private void DrawDisabledCheckRect(Graphics g, Rectangle checkRect)
        {
            g.DrawRectangle(SystemPens.ControlDark, checkRect);
            if (Checked)
            {
                //g.DrawImage(_checkImg, checkRect, 0, 0, _checkImg.Width, _checkImg.Height, GraphicsUnit.Pixel);
            }
        }

        private void SetStyles()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            UpdateStyles();
        }

        private void CalculateRect(out Rectangle checkRect, out Rectangle textRect)
        {
            checkRect = new Rectangle(
                0, 0, CheckRectWidth, CheckRectWidth);
            textRect = Rectangle.Empty;
            bool bCheckAlignLeft = (int)(LeftAlignment & CheckAlign) != 0;
            bool bCheckAlignRight = (int)(RightAlignment & CheckAlign) != 0;
            bool bRightToLeft = (RightToLeft == RightToLeft.Yes);

            if ((bCheckAlignLeft && !bRightToLeft) ||
                (bCheckAlignRight && bRightToLeft))
            {
                switch (CheckAlign)
                {
                    case ContentAlignment.MiddleCenter:
                        //checkRect.X = (Width - CheckRectHeight) / 2;
                        //checkRect.Y = (Height - CheckRectWidth) / 2;
                        break;
                    case ContentAlignment.TopRight:
                    case ContentAlignment.TopLeft:
                        checkRect.Y = 2;
                        break;
                    case ContentAlignment.MiddleRight:
                    case ContentAlignment.MiddleLeft:
                        checkRect.Y = (Height - CheckRectWidth) / 2;
                        break;
                    case ContentAlignment.BottomRight:
                    case ContentAlignment.BottomLeft:
                        checkRect.Y = Height - CheckRectWidth - 2;
                        break;
                }

                checkRect.X = 1;

                textRect = new Rectangle(
                    checkRect.Right + 2,
                    0,
                    Width - checkRect.Right - 4,
                    Height);
            }
            else if ((bCheckAlignRight && !bRightToLeft)
                || (bCheckAlignLeft && bRightToLeft))
            {
                switch (CheckAlign)
                {
                    case ContentAlignment.TopLeft:
                    case ContentAlignment.TopRight:
                        checkRect.Y = 2;
                        break;
                    case ContentAlignment.MiddleLeft:
                    case ContentAlignment.MiddleRight:
                        checkRect.Y = (Height - CheckRectWidth) / 2;
                        break;
                    case ContentAlignment.BottomLeft:
                    case ContentAlignment.BottomRight:
                        checkRect.Y = Height - CheckRectWidth - 2;
                        break;
                }

                checkRect.X = Width - CheckRectWidth - 1;

                textRect = new Rectangle(
                    2, 0, Width - CheckRectWidth - 6, Height);
            }
            else
            {
                switch (CheckAlign)
                {
                    case ContentAlignment.TopCenter:
                        checkRect.Y = 2;
                        textRect.Y = checkRect.Bottom + 2;
                        textRect.Height = Height - CheckRectWidth - 6;
                        break;
                    case ContentAlignment.MiddleCenter:
                        checkRect.Y = (Height - CheckRectWidth) / 2;
                        //checkRect.X = (Width - CheckRectWidth) / 2;
                        textRect.Y = 0;
                        textRect.X = this.Size.Width / 2;
                        textRect.Height = Height;
                        break;
                    case ContentAlignment.BottomCenter:
                        checkRect.Y = Height - CheckRectWidth - 2;
                        textRect.Y = 0;
                        textRect.Height = Height - CheckRectWidth - 6;
                        break;
                }

                //checkRect.X = (Width - CheckRectWidth) / 2;

                //textRect.X = 2;
                //textRect.Width = Width - 4;
            }
        }

        private static TextFormatFlags GetTextFormatFlags(ContentAlignment alignment, bool rightToleft)
        {
            TextFormatFlags flags = TextFormatFlags.WordBreak |
                TextFormatFlags.SingleLine;
            if (rightToleft)
            {
                flags |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
            }

            switch (alignment)
            {
                case ContentAlignment.BottomCenter:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.BottomLeft:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.Left;
                    break;
                case ContentAlignment.BottomRight:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.Right;
                    break;
                case ContentAlignment.MiddleCenter:
                    flags |= TextFormatFlags.HorizontalCenter |
                        TextFormatFlags.VerticalCenter;
                    break;
                case ContentAlignment.MiddleLeft:
                    flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Left;
                    break;
                case ContentAlignment.MiddleRight:
                    flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Right;
                    break;
                case ContentAlignment.TopCenter:
                    flags |= TextFormatFlags.Top | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.TopLeft:
                    flags |= TextFormatFlags.Top | TextFormatFlags.Left;
                    break;
                case ContentAlignment.TopRight:
                    flags |= TextFormatFlags.Top | TextFormatFlags.Right;
                    break;
            }
            return flags;
        }

    }
}