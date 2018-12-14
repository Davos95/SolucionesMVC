using PracticasMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticasMVC.Helper
{
    public class HelperVideos
    {
        List<Videos> videos { get; set; }

        public HelperVideos()
        {
            videos = new List<Videos>();
        }

        public List<Videos> GetVideos()
        {
            String[] nombres = { "Pilgrims on a Long Journey", "Aurora's Theme", "Magna's Heart", "Jupiter's Lightning", "Final Breath", "Patches of Sky", "Dark Creatures" };
            String[] codigo = { "u3o5YtTPvJ0", "Byz6960tWxQ", "Wew8kC4tvNQ", "GmwzWYzgoRk", "Bm3tBq7cCcE", "b4CjB-7IT4o", "k5X0v7h5kWQ" };
            this.videos = new List<Videos>();

            for (int i = 0; i < nombres.Length; i++)
            {
                Videos video = new Videos(nombres[i], codigo[i]);
                videos.Add(video);
            }
            return videos;
        }
    }
}