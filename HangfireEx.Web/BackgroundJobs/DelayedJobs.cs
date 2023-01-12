using System.Drawing;
using System.IO;

namespace HangfireExample.Web.BackgroundJobs
{
    public class DelayedJobs
    {
        public static string AddWaterMarkJob(string filename, string watermarkText)
        {
          return  Hangfire.BackgroundJob.Schedule(()=> ApplyWatermark(filename,watermarkText),TimeSpan.FromSeconds(30));
        }
        public static void ApplyWatermark(string filename,string watermarkText)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/pictures",filename);
            using (var bitmap=Bitmap.FromFile(path))
            {
                using (Bitmap tempBitMap=new Bitmap(bitmap.Width,bitmap.Height))
                {
                    using (Graphics grp=Graphics.FromImage(tempBitMap))
                    {

                        grp.DrawImage(bitmap,0,0);
                        var font = new Font(FontFamily.GenericSansSerif, 25, FontStyle.Bold);
                        var color=Color.FromArgb(255,0,0,255);  
                        var brush= new SolidBrush(color);
                        var point= new Point(20,bitmap.Height-50);
                        grp.DrawString(watermarkText,font,brush,point);
                        tempBitMap.Save(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/pictures/watermarks",filename));


                    }

                }
            }
        }
    }
}
