
using SHMClassLibrary;

using System;
using System.Collections.Generic;
using System.Data;

namespace SHMClassLibrary
{
    public class RoomLogic
    {
        private SmartHotelDb dalObject = new SmartHotelDb();

        #region RoomTable
        public int InsertRoom(Room_New room)
        {
            string insertQuery = @"INSERT INTO [dbo].[Room_New]
                                    (
                                    [HotelID]
                                    ,[Type]
                                    ,[Price]
                                    ,[Availability]
                                    ,[Features]
                                    ,[IsActive])
                                    VALUES                                     
                                    (
                                    @HotelID
                                    ,@Type
                                    ,@Price
                                    ,@Availability
                                    ,@Features
                                    ,@IsActive)";

            nameValuePairList nvp = new nameValuePairList();
            nvp.Add(new nameValuePair("@HotelID", room.HotelID));
            nvp.Add(new nameValuePair("@Type", room.Type));
            nvp.Add(new nameValuePair("@Price", room.Price));
            nvp.Add(new nameValuePair("@Availability", room.Availability));
            nvp.Add(new nameValuePair("@Features", room.Features));
            nvp.Add(new nameValuePair("@IsActive", room.IsActive));

            int insertStatus = 0;

            try
            {
                insertStatus = dalObject.InsertUpdateOrDelete(insertQuery, nvp, false);
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error: " + exp.Message);
            }

            return insertStatus;
        }

        public int UpdateRoom(Room_New room)
        {
            string updateQuery = @"UPDATE [dbo].[Room_New]
                                    SET
                                    [HotelID]=@HotelID,
                                    [Type] = @Type
                                    ,[Price] = @Price
                                    ,[Availability] = @Availability
                                    ,[Features] = @Features
                                    ,[IsActive] = @IsActive
                                    WHERE [RoomID] = @RoomID";

            nameValuePairList nvp = new nameValuePairList();
            nvp.Add(new nameValuePair("@HotelID", room.HotelID));
            nvp.Add(new nameValuePair("@Type", room.Type));
            nvp.Add(new nameValuePair("@Price", room.Price));
            nvp.Add(new nameValuePair("@Availability", room.Availability));
            nvp.Add(new nameValuePair("@Features", room.Features));
            nvp.Add(new nameValuePair("@IsActive", room.IsActive));
            nvp.Add(new nameValuePair("@RoomID", room.RoomID));

            int updateStatus = 0;

            try
            {
                updateStatus = dalObject.InsertUpdateOrDelete(updateQuery, nvp, false);
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error: " + exp.Message);
            }

            return updateStatus;
        }

        public DataTable DeleteRoom(Room_New room)
        {
            string deleteRoomQuery = @"UPDATE [dbo].[Room_New]
                                SET [IsActive] = 0
                                WHERE [RoomID] = @RoomID";

            nameValuePairList nvp = new nameValuePairList();
            nvp.Add(new nameValuePair("@RoomID", room.RoomID));

            int deleteStatus = 0;

            try
            {
                deleteStatus = dalObject.InsertUpdateOrDelete(deleteRoomQuery, nvp, false);
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error: " + exp.Message);
            }

            if (deleteStatus > 0)
            {
                string fetchRoomsQuery = @"SELECT
                                     [RoomID],
                                     [HotelID],
                                     [Type],
                                     [Price],
                                     [Availability],
                                     [Features],
                                     [IsActive]
                                    FROM [dbo].[Room_New]
                                    WHERE [IsActive] = 1";

                DataTable dt = dalObject.FetchData(fetchRoomsQuery);
                return dt;
            }
            else
            {
                return null;
            }
        }

        public DataTable SearchRoom(string type)
        {
            string searchRoomQuery = @"SELECT [RoomID],
                                           [HotelID],
                                           [Type],
                                           [Price],
                                           [Availability],
                                           [Features],
                                           [IsActive]
                               FROM [dbo].[Room_New] 
                               WHERE [Type] LIKE '%' + @Type + '%'";

            nameValuePairList nvp = new nameValuePairList();
            nvp.Add(new nameValuePair("@Type", type));

            DataTable dt = dalObject.FillAndReturnDataTable(searchRoomQuery, nvp);
            return dt;
        }

        public DataTable UpdateFeatures(Room_New room)
        {
            string updateFeaturesQuery = @"UPDATE [dbo].[Room_New]
                                    SET [Features] = @Features
                                    WHERE [RoomID] = @RoomID and IsActive = 1";

            nameValuePairList nvp = new nameValuePairList();
            nvp.Add(new nameValuePair("@Features", room.Features));
            nvp.Add(new nameValuePair("@RoomID", room.RoomID));

            DataTable dt = dalObject.FillAndReturnDataTable(updateFeaturesQuery, nvp);
            return dt;
        }

        public DataTable FetchAllActiveRooms()
        {
            string fetchAllActiveRoomsQuery = @"SELECT
                                                 [RoomID],
                                                 [HotelID],
                                                 [Type],
                                                 [Price],
                                                 [Availability],
                                                 [Features],
                                                 [IsActive]
                                                FROM [dbo].[Room_New]
                                                WHERE [IsActive] = 1";

            DataTable dt = null;

            try
            {
                dt = dalObject.FetchData(fetchAllActiveRoomsQuery);
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error: " + exp.Message);
            }

            return dt;
        }
        #endregion


        public DataTable FetchRoomsByHotel(int hotelID)
        {
            string fetchRoomsQuery = @"
        SELECT RoomID, HotelID, Type, Price, Availability, Features, IsActive
        FROM Room_New
        WHERE HotelID = @HotelID AND IsActive = 1";

            nameValuePairList nvp = new nameValuePairList();
            nvp.Add(new nameValuePair("@HotelID", hotelID));

            DataTable dt = null;

            try
            {
                dt = dalObject.FillAndReturnDataTable(fetchRoomsQuery, nvp);
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error: " + exp.Message);
            }

            return dt;
        }


        public List<Room_New> ConvertDataTableToList(DataTable dataTable)
        {
            var roomList = new List<Room_New>();

            foreach (DataRow row in dataTable.Rows)
            {
                try
                {
                    var room = new Room_New
                    {
                        RoomID = row.Field<int?>("RoomID") ?? 0,
                        HotelID = row.Field<int?>("HotelID") ?? 0,
                        Type = row.Field<string>("Type") ?? string.Empty,
                        Price = (float)(row.Field<double?>("Price") ?? 0),
                        Availability = row.Field<string>("Availability") ?? string.Empty,
                        Features = row.Field<string>("Features") ?? string.Empty,
                        IsActive = row.Field<bool?>("IsActive") ?? false
                    };

                    roomList.Add(room);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error converting DataRow to Room_New: {ex.Message}", ex);
                }
            }

            return roomList;
        }





    }
}