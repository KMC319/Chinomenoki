namespace Data {
    public struct LectureData {
        public readonly int Id;
        public readonly int SemesterNumber;
        public readonly string Name;
        public readonly string Description;
        public readonly AreaName AreaName;
        public readonly int[] RelatedIds;
        public LectureData(int id, int semesterNumber, string name, string description, AreaName areaName, int[] relatedId) {
            Id = id;
            SemesterNumber = semesterNumber;
            Name = name;
            Description = description;
            AreaName = areaName;
            RelatedIds = relatedId;
        }
    }
}
