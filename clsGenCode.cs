using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace gencode
{
	/// <summary>
	/// Summary description for clsGenCode.
	/// </summary>
	public class clsGenCode
	{
		private static int imagewidth = 180;
		private static int imageheight = 50;
		private static int fontsize = 36;
		

		public Color ForeColor = Color.Brown;
		public Color BackColor = Color.White;

		public clsGenCode()
		{
			// nothing
		}
		
		public byte[] GenerateBytes(string textcode)
		{
			SizeF textSize ;
			Graphics g ;

			Brush myBrush ;
			Font myFont = new Font("Times new Roman", Convert.ToSingle(fontsize), FontStyle.Regular);
			
			Image bmp = new Bitmap(imagewidth, imageheight);

			g = Graphics.FromImage(bmp);
			g.Clear(this.BackColor);

			// Find the Size required to draw the Sample Text
			textSize = g.MeasureString(textcode, myFont);
			// Create the required brush

			// Create a HatchBrush. In this case, simply a Diagonal Brick
			myBrush = new HatchBrush(HatchStyle.ZigZag   ,
					this.ForeColor, this.BackColor);

			// Draw the text
			g.DrawString(textcode, myFont, myBrush,
					(bmp.Width - textSize.Width) / 2,
					(bmp.Height - textSize.Height) / 2);
					
			MemoryStream s = new MemoryStream();
			bmp.Save(s, ImageFormat.Png);
			byte[] buffer = s.ToArray();
			s.Close();
			bmp.Dispose();
			return buffer;
		}
		
		public void GenerateFile(string filename, string textcode)
		{
			SizeF textSize ;
			Graphics g ;

			Brush myBrush ;
			Font myFont = new Font("Times new Roman", Convert.ToSingle(fontsize), FontStyle.Regular);
			
			Image bmp = new Bitmap(imagewidth, imageheight);
			
			g = Graphics.FromImage(bmp);
			g.Clear(this.BackColor);

			// Find the Size required to draw the Sample Text
			textSize = g.MeasureString(textcode, myFont);
			// Create the required brush

				// Create a HatchBrush. In this case, simply a Diagonal Brick
				myBrush = new HatchBrush(HatchStyle.ZigZag,
					this.ForeColor, this.BackColor);
				//myBrush = new HatchBrush(HatchStyle.DiagonalBrick,
				//	Color.Brown, Color.White);

			// Draw the text
			g.DrawString(textcode, myFont, myBrush,
					(bmp.Width - textSize.Width) / 2,
					(bmp.Height - textSize.Height) / 2);
	                
			bmp.Save("filename",ImageFormat.Bmp);
			bmp.Dispose();
			}
		}
	}

