using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StageInfo
{
    enum StageName
    {
        Proscenium, CentralStage, ThrustStage, 
    }

    public class StageList
    {
        // Stage names
        public string[] Name = new string[3] {
            "演唱會舞台", "開放式舞台", "其他"};

        // Stage images
        public RawImage []rawImage = new RawImage[3];
        
        public int GetLength()
        {
            return Name.Length;
        }
        
        public string GetStageName(int index)
        {
            return Name[index];
        }
    }

    public class Lighting
    {
        public string []Name = new string[3] {
            "前照燈", "側照燈", "後照燈"
        };

        public RawImage []rawImage = new RawImage[3];

        public int GetLength()
        {
            return Name.Length;
        }
    }

    public class Music
    {
        public string []Name = new string[3] {
            "音樂1", "音樂2", "音樂3"
        };

        public RawImage []rawImage = new RawImage[3];

        // 音樂長度
        public int []TimeInSeconds = new int[3] {
            60, 90, 120
        };

        public int []TimesPractice = new int[3] {
            1, 2, 3
        };

        public int GetLength()
        {
            return Name.Length;
        }
    }

    public class EventMode
    {
        public string []Name = new string[] {
            "評審模式", "閃光燈模式", "熱情模式", "尷尬模式"
        };

        public RawImage []rawImage = new RawImage[3];

        public int GetLength()
        {
            return Name.Length;
        }
    }
}