using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Data {
    public static class CsvLoader {
        public static List<LectureData> LoadCurriculum(TextAsset chart) {
            var sr = new StringReader(chart.text);
            sr.ReadLine();
            var dataList = new List<LectureData>();
            while (sr.Peek() > -1) {
                var line = sr.ReadLine();
                var datas = line.Split(',');
                var id = int.Parse(datas[0]);
                var semester = int.Parse(datas[1]);
                var name = datas[2];
                var description = datas[3];
                var area = (AreaName) (int.TryParse(datas[4], out var a) ? a : 0);
                var temp = datas[5].Split('$');
                var relatedIds = temp.Where(x => int.TryParse(x, out _))
                    .Select(int.Parse)
                    .ToArray();

                var data = new LectureData(id, semester, name, description, area, relatedIds);
                dataList.Add(data);
            }
            return dataList;
        }
    }
}
