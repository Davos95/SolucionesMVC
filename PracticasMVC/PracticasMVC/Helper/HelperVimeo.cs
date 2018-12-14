using PracticasMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticasMVC.Helper
{
    public class HelperVimeo
    {
        List<Videos> videos;
        public HelperVimeo()
        {
            videos = new List<Videos>();
        }

        public void GetVideos()
        {
            List<Videos> v = new List<Videos>();
            String[] nombre = { "Shaun of the Dead “the Z word” / Arte", "Little HORT portrait for ARTE creative" };
            String[] codigo = { "228802947", "23635345" };
            for (int i = 0; i < nombre.Length; i++)
            {
                Videos video = new Videos(nombre[i], codigo[i]);
                v.Add(video);
            }
            videos = v;
        }

    }
}