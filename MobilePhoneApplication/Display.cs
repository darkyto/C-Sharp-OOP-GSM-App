using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneApplication
{
    public class Display
    {
        // *** Fields *** \\ task 1,2,4
        private const double minSize = 0;    // inches double
        private const double maxSize = 1000; // inches

        private double? size;
        private long colors;

        // *** Constructors *** \\
        public Display(double size, long colors)
        {
            this.Size = size;
            this.Colors = colors;
        }

        // *** Properties *** \\
        public double? Size
        {
            get { return size; }
            set
            {
                if (value > minSize && value < maxSize )
                {
                    size = value;
                }
                else
                {
                    throw new Exception(string.Format("Value for 'size' must be a positive number withint {0} and {1} (inches)!", minSize, maxSize));
                }
            }
        }


        public long Colors
        {
            get { return colors; }
            set
            {
                if (value > 0)
                {
                    colors = value;
                }
                else
                {
                    throw new Exception("Value for number of colors must be a positive number!");
                }
            }
        }
    }
}
