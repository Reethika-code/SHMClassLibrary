using SHMClassLibrary.Entities;
using System.Linq;
namespace SHMClassLibrary.Repository
{
    public class ReviewsRepository
    { 
        public static void Addvalues(Review review)
        {
            using (var context = new ReviewsDbContext())
            {
                context.Reviews.Add(review);
                context.SaveChanges();
            }
        }
        //public static void AddReview(Review review)
        //{
        //    using (var context = new ReviewsDbContext())
        //    {
        //        var bookingExists = context.Bookings.Any(b => b.UserID == review.UserID && b.HotelID == review.HotelID);
        //        if (bookingExists)
        //        {
        //            context.Reviews.Add(review);
        //            context.SaveChanges();
        //        }
        //        else
        //        {
        //            throw new Exception("User has not stayed in the hotel.");
        //        }
        //    }
        //}
                 public static void UpdateReview(Review review)
                {
                    using (var context = new ReviewsDbContext())
                    {
                        context.Reviews.Update(review);
                        context.SaveChanges();
                    }
                }
                public static void DeleteReview(int id)
                {
                    using (var context = new ReviewsDbContext())
                    {
                        var review = context.Reviews.FirstOrDefault(r => r.ReviewID == id);
                        if (review != null)
                        {
                            context.Reviews.Remove(review);
                            context.SaveChanges();
                        }
                    }
                }
                public static List<Review> GetAllReviews()
                {
                    using (var context = new ReviewsDbContext())
                    {
                        return context.Reviews.ToList();
                    }
                }
                public static double CalculateAverageRating(int hotelID)
                {
                    using (var context = new ReviewsDbContext())
                    {
                        var reviews = context.Reviews.Where(r => r.HotelID == hotelID);
                        if (reviews.Any())
                        {
                            return reviews.Average(r => r.Rating);
                        }
                        return 0;
                    }
                }
                //public static List<Review> GetReviewsByHotelName(string hotelName)
                //{
                //    using (var context = new ReviewsDbContext())
                //    {
                //        var hotel = context.Hotels.FirstOrDefault(h => h.Name == hotelName);
                //        if (hotel != null)
                //        {
                //            var reviews = context.Reviews.Where(r => r.HotelID == hotel.HotelID).ToList();
                //            return reviews;
                //        }
                //        return new List<Review>();
                //    }
                //}
        //public static List<Hotel> GetBestHotelsByLocation(string location)
        //{
        //    using (var context = new ReviewsDbContext())
        //    {
        //        var hotels = context.Hotels.Where(h => h.Location == location).ToList();
        //        foreach (var hotel in hotels)
        //        {
        //            hotel.AverageRating = CalculateAverageRating(hotel.HotelID);
        //        }
        //        return hotels.OrderByDescending(h => h.AverageRating).ToList();
        //    }
        //}
        public static List<Review> GetMostRecentReviews()
        {
            using (var context = new ReviewsDbContext())
            {
                return context.Reviews.OrderByDescending(r => r.TimeStamp).ToList();
            }
        }
        //public static List<Hotel> GetHotelsByRating(double ratingThreshold)
        //{
        //    using (var context = new ReviewsDbContext())
        //    {
        //        var hotels = context.Hotels.ToList();
        //        foreach (var hotel in hotels)
        //        {
        //            hotel.AverageRating = CalculateAverageRating(hotel.HotelID);
        //        }
        //        return hotels.Where(h => h.AverageRating > ratingThreshold).ToList();
        //    }
        //}
        public static List<Review> GetReviewsByMonthAndDate(int month, int day)
        {
            using (var context = new ReviewsDbContext())
            {
                return context.Reviews.Where(r => r.TimeStamp.Month == month && r.TimeStamp.Day == day).ToList();
            }
        }
        public static void FlagInappropriateReview(int reviewID)
        {
            using (var context = new ReviewsDbContext())
            {
                var review = context.Reviews.FirstOrDefault(r => r.ReviewID == reviewID);
                if (review != null)
                {
                    review.IsFlagged = true; // Mark the review as flagged
                    context.SaveChanges();
                }
            }
        }


    }
}