namespace SHMClassLibrary.Entities
{
    public class Review
    {
       // ReviewID, UserID, HotelID, Rating, Comment, Timestamp
        public int ReviewID { get; set; }
        public int UserID { get; set; }
        public int HotelID { get; set; }
        public double Rating { get; set; }
        public string Comment { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool IsFlagged { get; set; }
    }
}
