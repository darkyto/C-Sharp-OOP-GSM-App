using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSM
{
    public class Display
    {
        #region fileds
        private const double minSize = 0;   //display size in inches
        private const double maxSize = 100;

        private double? size;
        private long colors;
        #endregion

        #region constructors
        public Display(double size, long colors)
        {
            this.size = size;
            this.colors = colors;
        }
        #endregion

        #region properties
        public double? Size
        {
            get { return size; }
            set
            {
                if (value < minSize || value > maxSize)
                {
                    throw new ArgumentOutOfRangeException("Display size value is out of range!");
                }
                else
                {
                    size = value;
                }
            }
        }

        public long Colors 
        {
            get { return colors; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Number of display colors value can not be negative number!");
                }
                else
                {
                    colors = value;
                }
            }
        }
        #endregion
    }
}
