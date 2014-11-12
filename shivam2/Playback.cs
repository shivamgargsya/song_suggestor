using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shivam2
{
    class Playback
    {
        public Playback()
        {
            currentindex = 0;
            totalsongs = 0;
        }
        public int currentindex { get; set; }
        public int totalsongs { get; set; }
        public List<song> playlist = new List<song>();
        public void sort()
        {
            for (int i = 0; i < this.totalsongs; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if ((this.playlist[j].count) > (this.playlist[j - 1].count))
                    {
                        song c = this.playlist[j];
                        this.playlist[j] = this.playlist[j - 1];
                        this.playlist[j] = c;
                    }
                }
            }
        }

    }
}
