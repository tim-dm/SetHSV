// Name: Set HSV
// Submenu:
// Author: DataMine
// Title: Set HSV
// Version:
// Desc: Allows for setting the HSV of selected pixels to specific values 
// Keywords:
// URL:
// Help:
#region UICode
TextboxControl Hue = ""; // [360] Enter Hue
TextboxControl Saturation = ""; // [100] Enter Saturation
TextboxControl Value = ""; // [100] Enter Value
#endregion

void Render(Surface dst, Surface src, Rectangle rect)
{ 
    ColorBgra currentPixel;

    for (int y = rect.Top; y < rect.Bottom; y++)
    {
        if (IsCancelRequested) return;

        for (int x = rect.Left; x < rect.Right; x++)
        {
            currentPixel = src[x,y];

            HsvColor hsv = HsvColor.FromColor(currentPixel.ToColor());
        
            int newH = string.IsNullOrEmpty(Hue) ? hsv.Hue : Convert.ToInt32(Hue);
            int newS = string.IsNullOrEmpty(Saturation) ? hsv.Saturation : Convert.ToInt32(Saturation);
            int newV = string.IsNullOrEmpty(Value) ? hsv.Value : Convert.ToInt32(Value);
            byte A = currentPixel.A;

            currentPixel = ColorBgra.FromColor(new HsvColor(newH, newS, newV).ToColor());
            currentPixel.A = A;

            dst[x,y] = currentPixel;
        }
    }
}
