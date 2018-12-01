using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Design;
using System.Globalization;
using System.Text;
public partial class Captcha1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string[] fonts = { "Arial Black", "Lucida Sans Unicode", "Comic Sans MS" };

        const byte LENGTH = 5;

        // chuỗi để lấy các kí tự sẽ sử dụng cho captcha

        const string chars = "0123456789";

        using (Bitmap bmp = new Bitmap(120, 30))
        {

            using (Graphics g = Graphics.FromImage(bmp))
            {

                // Tạo nền cho ảnh dạng sóng

                HatchBrush brush = new HatchBrush(HatchStyle.Wave, Color.White, Color.Wheat);

                g.FillRegion(brush, g.Clip);

                // Lưu chuỗi captcha trong quá trình tạo

                StringBuilder strCaptcha = new StringBuilder();

                Random rand = new Random();

                for (int i = 0; i < LENGTH; i++)
                {

                    // Lấy kí tự ngẫu nhiên từ mảng chars

                    string str = chars[rand.Next(chars.Length)].ToString();

                    strCaptcha.Append(str);

                    // Tạo font với tên font ngẫu nhiên chọn từ mảng fonts

                    Font font = new Font(fonts[rand.Next(fonts.Length)], 12, FontStyle.Strikeout | FontStyle.Italic);

                    // Lấy kích thước của kí tự

                    SizeF size = g.MeasureString(str, font);

                    // Vẽ kí tự đó ra ảnh tại vị trí tăng dần theo i, vị trí top ngẫu nhiên

                    g.DrawString(str, font,

                    Brushes.Chocolate, i * size.Width + 3, rand.Next(2, 10));

                    font.Dispose();

                }

                // Lưu captcha vào session

                Session["captcha"] = strCaptcha.ToString();

                // Ghi ảnh trực tiếp ra luồng xuất theo định dạng gif

                Response.ContentType = "image/GIF";

                bmp.Save(Response.OutputStream, ImageFormat.Gif);

            }

        }
    }
}
